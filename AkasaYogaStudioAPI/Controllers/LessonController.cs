using Akasa.Dto.POCOs;
using Akasa.Services.Contracts;
using AkasaYogaStudioAPI.Core;
using Microsoft.AspNetCore.Mvc;

namespace AkasaYogaStudioAPI.Controllers
{
    [Route("api/[controller]")]
    public class LessonController : AkasaController<ILessonService, LessonGetDto, LessonInsertDto, LessonUpdateDto>
    {
        public LessonController(ILessonService lessonService) 
            : base(lessonService)
        {
        }
    }
}
