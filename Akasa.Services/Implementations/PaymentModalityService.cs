using Akasa.Data;
using Akasa.Dto.POCOs;
using Akasa.Model;
using Akasa.Services.Contracts;
using Akasa.Services.Core;
using AutoMapper;

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

    }
}
