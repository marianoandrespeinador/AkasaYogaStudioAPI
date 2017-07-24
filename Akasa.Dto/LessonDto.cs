using System.Collections.Generic;
using Akasa.Dto.Core;

namespace Akasa.Dto
{
    public class LessonDto : FiniteDataEntityCatalogDto
    {
        public List<LessonRecurrentGetDto> LstLessonRecurrent { get; set; }
        public List<LessonDayGetDto> LstLessonDay { get; set; }
    }
}
