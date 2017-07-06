using System.ComponentModel.DataAnnotations.Schema;
using Akasa.Model.Core;

namespace Akasa.Model
{
    public class LessonCost : FiniteDataEntity
    {
        [ForeignKey(nameof(Lesson))]
        public int LessonId { get; set; }
        public int VKPaymentType { get; set; }
        public decimal Price { get; set; }

        public virtual Lesson Lesson { get; set; }
    }
}
