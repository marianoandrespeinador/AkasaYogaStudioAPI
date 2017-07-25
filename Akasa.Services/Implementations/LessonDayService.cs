using Akasa.Data;
using Akasa.Dto.POCOs;
using Akasa.Model;
using Akasa.Services.Contracts;
using Akasa.Services.Core;
using AutoMapper;

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
