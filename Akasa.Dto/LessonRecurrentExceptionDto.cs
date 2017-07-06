using System;
using Akasa.Dto.Core;

namespace Akasa.Dto
{
      public class LessonRecurrentExceptionDto : FiniteDataEntityDto
      {
            public virtual int LessonRecurrentId { get; set; }
            public virtual DateTime DateException { get; set; }
            public virtual string Description { get; set; }
      }
}
