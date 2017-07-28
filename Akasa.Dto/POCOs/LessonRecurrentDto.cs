using System;
using Akasa.Dto.Core;

namespace Akasa.Dto.POCOs
{
      public class LessonRecurrentDto : FiniteDataEntityDto
      {
            public virtual int LessonId { get; set; }
            public virtual bool Monday { get; set; }
            public virtual bool Tuesday { get; set; }
            public virtual bool Wednesday { get; set; }
            public virtual bool Thursday { get; set; }
            public virtual bool Friday { get; set; }
            public virtual bool Saturday { get; set; }
            public virtual bool Sunday { get; set; }
      }
}
