using Akasa.Dto;
using Akasa.Services.Contracts;
using AkasaYogaStudioAPI.Core;
using Microsoft.AspNetCore.Mvc;

namespace AkasaYogaStudioAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : AkasaController<IUserService, UserGetDto, UserInsertDto, UserUpdateDto>
    {
        public UserController(IUserService UserService) 
            : base(UserService)
        {
        }
    }
}
