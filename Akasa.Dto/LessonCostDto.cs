using System;
using Akasa.Dto.Core;

namespace Akasa.Dto
{
      public class LessonCostDto : FiniteDataEntityDto
      {
            public virtual int LessonId { get; set; }
            public virtual int VKPaymentType { get; set; }
            public virtual decimal Price { get; set; }
      }
}
