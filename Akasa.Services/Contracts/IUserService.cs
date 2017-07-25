using Akasa.Dto.POCOs;
using Akasa.Services.Core;

namespace Akasa.Services.Contracts
{
    public interface IUserService : IAkasaService<UserGetDto, UserInsertDto, UserUpdateDto>
    {
        
    }
}
