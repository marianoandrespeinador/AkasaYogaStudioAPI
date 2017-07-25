using Akasa.Dto.POCOs;
using Akasa.Services.Core;

namespace Akasa.Services.Contracts
{
    public interface ILessonService: IAkasaService<LessonGetDto, LessonInsertDto, LessonUpdateDto>
    {
    }
}
