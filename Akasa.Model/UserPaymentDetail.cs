using System.ComponentModel.DataAnnotations.Schema;
using Akasa.Model.Core;

namespace Akasa.Model
{
    public class UserPaymentDetail : FiniteDataEntity
    {
        [ForeignKey(nameof(UserPayment))]
        public int UserPaymentId { get; set; }

        public decimal AmountPayed { get; set; }

        public virtual UserPayment UserPayment { get; set; }
    }
}
