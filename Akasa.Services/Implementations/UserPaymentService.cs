using Akasa.Data;
using Akasa.Dto.POCOs;
using Akasa.Model;
using Akasa.Services.Contracts;
using Akasa.Services.Core;
using AutoMapper;

namespace Akasa.Services.Implementations
{
    public class UserPaymentService : AkasaService<UserPayment, UserPaymentGetDto, UserPaymentInsertDto, UserPaymentUpdateDto>
        , IUserPaymentService
    {
        public UserPaymentService(AkasaDBContext context
            , IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}
