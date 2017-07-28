using System.ComponentModel.DataAnnotations.Schema;
using Akasa.Model.Core;

namespace Akasa.Model
{
    public partial class LessonItsOnXUser : FiniteDataEntity
    {
        [ForeignKey(nameof(LessonItsOn))]
        public int LessonItsOnId { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        [ForeignKey(nameof(UserPayment))]
        public int? UserPaymentId { get; set; }
        public bool IsPresent { get; set; }

        public virtual User User { get; set; }
        public virtual LessonItsOn LessonItsOn { get; set; }
        public virtual UserPayment UserPayment { get; set; }
    }
}
