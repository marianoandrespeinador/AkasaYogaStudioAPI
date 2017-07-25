using Akasa.Dto.POCOs;
using Akasa.Services.Contracts;
using AkasaYogaStudioAPI.Core;
using Microsoft.AspNetCore.Mvc;

namespace AkasaYogaStudioAPI.Controllers
{
    [Route("api/[controller]")]
    public class LessonItsOnController : AkasaController<ILessonItsOnService, LessonItsOnGetDto, LessonItsOnInsertDto, LessonItsOnUpdateDto>
    {
        public LessonItsOnController(ILessonItsOnService lessonItsOnService) 
            : base(lessonItsOnService)
        {
        }
    }
}
