using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akasa.Data;
using Akasa.Dto;
using Akasa.Model;
using Akasa.Services.Contracts;
using Akasa.Services.Core;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Akasa.Services.Implementations
{
    public class LessonDayService : AkasaService<LessonDay, LessonDayGetDto, LessonDayInsertDto, LessonDayUpdateDto>
        , ILessonDayService
    {
        public LessonDayService(AkasaDBContext context
            , IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
