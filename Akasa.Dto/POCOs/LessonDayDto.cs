using Akasa.Dto.Core;

namespace Akasa.Dto.POCOs
{
      public class LessonDayDto : FiniteDataEntityDto
      {
            public virtual int LessonId { get; set; }
            public virtual System.DateTime DateFixed { get; set; }
      }
}
