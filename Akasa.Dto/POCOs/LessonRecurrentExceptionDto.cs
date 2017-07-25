using Akasa.Dto.Core;

namespace Akasa.Dto.POCOs
{
      public class LessonRecurrentExceptionDto : FiniteDataEntityDto
      {
            public virtual int LessonRecurrentId { get; set; }
            public virtual System.DateTime DateException { get; set; }
            public virtual string Description { get; set; }
      }
}
