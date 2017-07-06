using Akasa.Dto;
using Akasa.Services.Contracts;
using AkasaYogaStudioAPI.Core;
using Microsoft.AspNetCore.Mvc;

namespace AkasaYogaStudioAPI.Controllers
{
    [Route("api/[controller]")]
    public class LessonCostController : AkasaController<ILessonCostService, LessonCostGetDto, LessonCostInsertDto, LessonCostUpdateDto>
    {
        public LessonCostController(ILessonCostService LessonCostService) 
            : base(LessonCostService)
        {
        }
    }
}
