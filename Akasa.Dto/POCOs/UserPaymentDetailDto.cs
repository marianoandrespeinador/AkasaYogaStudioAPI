using Akasa.Dto.Core;

namespace Akasa.Dto.POCOs
{
      public class UserPaymentDetailDto : FiniteDataEntityDto
      {
            public virtual int UserPaymentId { get; set; }
            public virtual decimal AmountPayed { get; set; }
      }
}
