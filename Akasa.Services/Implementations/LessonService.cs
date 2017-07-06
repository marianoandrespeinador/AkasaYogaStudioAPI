using Akasa.Data;
using Akasa.Dto;
using Akasa.Model;
using Akasa.Services.Contracts;
using Akasa.Services.Core;
using AutoMapper;

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

        //public override async Task<LessonGetDto> Get(int id)
        //{
        //    var lesson = await _thisDbSet
        //        .Where(e => e.Id == id)
        //        .Include(e => e.LstLessonCost)
        //        .FirstAsync();

        //    return _mapperService.Map<LessonGetDto>(lesson);
        //}

    }
}
