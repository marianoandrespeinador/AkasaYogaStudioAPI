
using System.Collections.Generic;
using System.Threading.Tasks;
using Akasa.Dto.POCOs;
using Akasa.Services.Core;

namespace Akasa.Services.Contracts
{
    public interface IPaymentModalityService : IAkasaService<PaymentModalityGetDto, PaymentModalityInsertDto, PaymentModalityUpdateDto>
    {
        Task<List<KeyValuePair<int, string>>> GetDropDown();
    }
}
