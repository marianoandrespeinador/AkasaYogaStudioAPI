using Akasa.Data;
using Akasa.Dto;
using Akasa.Model;
using Akasa.Services.Contracts;
using Akasa.Services.Core;
using AutoMapper;

namespace Akasa.Services.Implementations
{
    public class LessonItsOnService : AkasaService<LessonItsOn, LessonItsOnGetDto, LessonItsOnInsertDto, LessonItsOnUpdateDto>
        , ILessonItsOnService
    {
        public LessonItsOnService(AkasaDBContext context
            , IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}
