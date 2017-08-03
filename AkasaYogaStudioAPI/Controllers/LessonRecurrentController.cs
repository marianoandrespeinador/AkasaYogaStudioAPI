using Akasa.Dto.POCOs;
using Akasa.Dto.Projections;
using Akasa.Services.Contracts;
using AkasaYogaStudioAPI.Core;
using Microsoft.AspNetCore.Mvc;

namespace AkasaYogaStudioAPI.Controllers
{
    [Route("api/[controller]")]
    public class LessonRecurrentController : AkasaController<ILessonRecurrentService, LessonRecurrentGetPro, LessonRecurrentInsertDto, LessonRecurrentUpdateDto>
    {
        public LessonRecurrentController(ILessonRecurrentService lessonService) 
            : base(lessonService)
        {
        }

    }
}
