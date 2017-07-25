using Akasa.Dto.POCOs;
using Akasa.Services.Contracts;
using AkasaYogaStudioAPI.Core;
using Microsoft.AspNetCore.Mvc;

namespace AkasaYogaStudioAPI.Controllers
{
    [Route("api/[controller]")]
    public class PaymentModalityController : AkasaController<IPaymentModalityService, PaymentModalityGetDto, PaymentModalityInsertDto, PaymentModalityUpdateDto>
    {
        public PaymentModalityController(IPaymentModalityService paymentModalityService)
            : base(paymentModalityService)
        {
        }
    }
}
