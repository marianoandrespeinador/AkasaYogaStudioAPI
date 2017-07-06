using Akasa.Dto;
using Akasa.Services.Core;

namespace Akasa.Services.Contracts
{
    public interface ILessonCostService: IAkasaService<LessonCostGetDto, LessonCostInsertDto, LessonCostUpdateDto>
    {
    }
}
