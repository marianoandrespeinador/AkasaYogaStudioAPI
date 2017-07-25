using Akasa.Dto.Core;

namespace Akasa.Dto.POCOs
{
      public class UserPaymentDto : FiniteDataEntityDto
      {
            public virtual int UserId { get; set; }
            public virtual int PaymentModalityId { get; set; }
            public virtual decimal TotalAmountPayed { get; set; }
            public virtual decimal TotalAmountToPay { get; set; }
      }
}
