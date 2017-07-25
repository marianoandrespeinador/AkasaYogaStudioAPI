using Akasa.Dto.POCOs;
using Akasa.Services.Contracts;
using AkasaYogaStudioAPI.Core;
using Microsoft.AspNetCore.Mvc;

namespace AkasaYogaStudioAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserPaymentController : AkasaController<IUserPaymentService, UserPaymentGetDto, UserPaymentInsertDto, UserPaymentUpdateDto>
    {
        public UserPaymentController(IUserPaymentService userPaymentService)
            : base(userPaymentService)
        {
        }
    }
}
