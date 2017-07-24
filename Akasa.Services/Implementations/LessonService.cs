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
    public class LessonService : AkasaService<Lesson, LessonGetDto, LessonInsertDto, LessonUpdateDto>
        , ILessonService
    {
        public LessonService(AkasaDBContext context
            , IMapper mapper)
            : base(context, mapper)
        {
        }
        
        public override async Task<List<LessonGetDto>> Get()
        {
            var rawList = await _thisDbSet
                .AsNoTracking()
                .WhereIsValid()
                .Include(l => l.LstLessonDay)
                .Include(l => l.LstLessonRecurrent)
                .ToListAsync();

            return _mapperService.Map<List<LessonGetDto>>(rawList);
        }

    }
}
