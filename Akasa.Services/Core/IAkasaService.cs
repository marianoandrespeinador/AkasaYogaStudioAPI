using System.Collections.Generic;
using System.Threading.Tasks;
using Akasa.Dto.Core;

namespace Akasa.Services.Core
{
    public interface IAkasaService<TGetDto, TInsertDto, TUpdateDto> : IAmAService
        where TGetDto : FiniteDataEntityDto
        where TInsertDto : FiniteDataEntityDto
        where TUpdateDto : FiniteDataEntityDto
    {
        Task<List<TGetDto>> Get();
        Task<TGetDto> Get(int id);
        Task<TGetDto> Insert(TInsertDto toInsert);
        Task Update(int id, TUpdateDto dtoUpdate);
        Task Delete(int id);
        Task<List<KeyValuePair<int, string>>> GetDropDown();
    }
}
