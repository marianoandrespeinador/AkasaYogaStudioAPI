using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Akasa.Dto.POCOs;
using Akasa.Services.Contracts;
using AkasaYogaStudioAPI.Core;
using Microsoft.AspNetCore.Mvc;

namespace AkasaYogaStudioAPI.Controllers
{
    [Route("api/[controller]")]
    public class PaymentModalityController : AkasaController<IPaymentModalityService, PaymentModalityGetDto,
        PaymentModalityInsertDto, PaymentModalityUpdateDto>
    {
        /// <summary>
        /// Modes or types of payment for Akasa Yoga Studio
        /// </summary>
        /// <param name="paymentModalityService"></param>
        public PaymentModalityController(IPaymentModalityService paymentModalityService)
            : base(paymentModalityService)
        {
        }
    }
}
