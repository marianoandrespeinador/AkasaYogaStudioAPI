using Akasa.Dto.POCOs;
using Akasa.Services.Core;
using Akasa.Dto.Projections;

namespace Akasa.Services.Contracts
{
    public interface ILessonRecurrentService: IAkasaService<LessonRecurrentGetPro, LessonRecurrentInsertDto, LessonRecurrentUpdateDto>
    {
    }
}
