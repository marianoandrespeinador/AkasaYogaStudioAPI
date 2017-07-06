using System.Collections.Generic;
using System.Threading.Tasks;
using Akasa.Data;
using Akasa.Dto;
using Akasa.Model;
using Akasa.Services;
using Akasa.Services.Contracts;
using Akasa.Services.Core;
using Akasa.Services.Implementations;
using AkasaYogaStudioAPI.Core;
using AutoMapper;
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
