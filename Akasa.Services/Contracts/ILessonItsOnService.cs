using Akasa.Dto.POCOs;
using Akasa.Services.Core;

namespace Akasa.Services.Contracts
{
    public interface ILessonItsOnService: IAkasaService<LessonItsOnGetDto, LessonItsOnInsertDto, LessonItsOnUpdateDto>
    {
    }
}
