using Akasa.Dto.POCOs;
using Akasa.Services.Core;

namespace Akasa.Services.Contracts
{
    public interface ILessonRecurrentService: IAkasaService<LessonRecurrentGetDto, LessonRecurrentInsertDto, LessonRecurrentUpdateDto>
    {
    }
}
