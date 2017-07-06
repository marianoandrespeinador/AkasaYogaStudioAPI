using Akasa.Data;
using Akasa.Dto;
using Akasa.Model;
using Akasa.Services.Contracts;
using Akasa.Services.Core;
using AutoMapper;

namespace Akasa.Services.Implementations
{
    public class LessonCostService : AkasaService<LessonCost, LessonCostGetDto, LessonCostInsertDto, LessonCostUpdateDto>
        , ILessonCostService
    {
        public LessonCostService(AkasaDBContext context
            , IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}
