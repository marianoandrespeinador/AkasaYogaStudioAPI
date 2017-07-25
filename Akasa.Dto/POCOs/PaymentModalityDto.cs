using Akasa.Dto.Core;

namespace Akasa.Dto.POCOs
{
      public class PaymentModalityDto : FiniteDataEntityDto
      {
            public virtual int LessonQuantityAvailable { get; set; }
            public virtual System.TimeSpan LessonAvailabilityPeriod { get; set; }
            public virtual decimal Cost { get; set; }
      }
}
