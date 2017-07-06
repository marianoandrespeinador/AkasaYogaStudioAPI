using Akasa.Dto;
using Akasa.Services.Core;

namespace Akasa.Services.Contracts
{
    public interface ILessonService: IAkasaService<LessonGetDto, LessonInsertDto, LessonUpdateDto>
    {
    }
}
