using System.Collections.Generic;
using System.Threading.Tasks;
using Akasa.Data;
using Akasa.Dto.POCOs;
using Akasa.Dto.Projections;
using Akasa.Model;
using Akasa.Services.Contracts;
using Akasa.Services.Core;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Akasa.Services.Implementations
{
    public class LessonRecurrentService : AkasaService<LessonRecurrent, LessonRecurrentGetPro, LessonRecurrentInsertDto, LessonRecurrentUpdateDto>
        , ILessonRecurrentService
    {
        public LessonRecurrentService(AkasaDBContext context
            , IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}
