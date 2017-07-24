using System.Threading.Tasks;
using Akasa.Dto;
using Akasa.Services.Contracts;
using AkasaYogaStudioAPI.Core;
using Microsoft.AspNetCore.Mvc;

namespace AkasaYogaStudioAPI.Controllers
{
    [Route("api/[controller]")]
    public class LessonDayController : AkasaController<ILessonDayService, LessonDayGetDto, LessonDayInsertDto, LessonDayUpdateDto>
    {
        public LessonDayController(ILessonDayService LessonDayService) 
            : base(LessonDayService)
        {
        }
    }
}
