using Akasa.Data;
using Akasa.Dto.POCOs;
using Akasa.Model;
using Akasa.Services.Contracts;
using Akasa.Services.Core;
using AutoMapper;

namespace Akasa.Services.Implementations
{
    public class UserService : AkasaService<User, UserGetDto, UserInsertDto, UserUpdateDto>
        , IUserService
    {
        public UserService(AkasaDBContext context
            , IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}
