using System;
using Akasa.Dto.Core;

namespace Akasa.Dto.POCOs
{
      public class LessonItsOnDto : FiniteDataEntityDto
      {
            public virtual int? LessonRecurrentId { get; set; }
            public virtual int? LessonDayId { get; set; }
            public virtual DateTime DateItsOn { get; set; }
      }
}
