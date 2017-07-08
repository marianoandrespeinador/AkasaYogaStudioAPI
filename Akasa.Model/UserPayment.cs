
using System.ComponentModel.DataAnnotations.Schema;
using Akasa.Model.Core;

namespace Akasa.Model
{
    public class UserPayment : FiniteDataEntity
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        [ForeignKey(nameof(PaymentModality))]
        public int PaymentModalityId { get; set; }

        public decimal TotalAmountPayed { get; set; }
        public decimal TotalAmountToPay { get; set; }

        public virtual User User { get; set; }
        public virtual PaymentModality PaymentModality { get; set; }
    }
}
