using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akasa.Data;
using Akasa.Dto.POCOs;
using Akasa.Model;
using Akasa.Services.Contracts;
using Akasa.Services.Core;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Akasa.Services.Implementations
{
    public class PaymentModalityService : AkasaService<PaymentModality, PaymentModalityGetDto, PaymentModalityInsertDto, PaymentModalityUpdateDto>
        , IPaymentModalityService
    {
        public PaymentModalityService(AkasaDBContext context
            , IMapper mapper)
            : base(context, mapper)
        {
        }

        protected override KeyValuePair<int, string> GetAsKeyValue(PaymentModality record)
        {
            var period = record.LessonAvailabilityDays % 30 == 0
                ? $" en {record.LessonAvailabilityDays / 30} meses"
                : "";

            return new KeyValuePair<int, string>(record.Id, $"₡{record.Cost} - {record.LessonQuantityAvailable} clases{period}");
        }

    }
}

