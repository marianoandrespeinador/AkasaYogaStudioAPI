using Akasa.Dto;
using Akasa.Services.Core;

namespace Akasa.Services.Contracts
{
    public interface ILessonDayService: IAkasaService<LessonDayGetDto, LessonDayInsertDto, LessonDayUpdateDto>
    {
    }
}
