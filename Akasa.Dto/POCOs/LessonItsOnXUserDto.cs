using System;
using Akasa.Dto.Core;

namespace Akasa.Dto.POCOs
{
      public class LessonItsOnXUserDto : FiniteDataEntityDto
      {
            public virtual int LessonItsOnId { get; set; }
            public virtual int UserId { get; set; }
            public virtual int? UserPaymentId { get; set; }
            public virtual bool IsPresent { get; set; }
      }
}
