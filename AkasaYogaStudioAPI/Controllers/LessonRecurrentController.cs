using System.Collections.Generic;
using System.Threading.Tasks;
using Akasa.Dto.POCOs;
using Akasa.Services.Contracts;
using AkasaYogaStudioAPI.Core;
using Microsoft.AspNetCore.Mvc;

namespace AkasaYogaStudioAPI.Controllers
{
    [Route("api/[controller]")]
    public class LessonRecurrentController : AkasaController<ILessonRecurrentService, LessonRecurrentGetDto, LessonRecurrentInsertDto, LessonRecurrentUpdateDto>
    {
        public LessonRecurrentController(ILessonRecurrentService lessonService) 
            : base(lessonService)
        {
        }

    }
}
