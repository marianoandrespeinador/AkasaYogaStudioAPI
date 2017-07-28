using System;
using Akasa.Dto.Core;

namespace Akasa.Dto.POCOs
{
      public class PaymentModalityDto : FiniteDataEntityDto
      {
            public virtual int LessonQuantityAvailable { get; set; }
            public virtual int LessonAvailabilityDays { get; set; }
            public virtual decimal Cost { get; set; }
      }
}
