using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Akasa.Model
{
    public partial class LessonItsOnXUser
    {
        [ForeignKey(nameof(LessonItsOn))]
        public int LessonItsOnId { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual LessonItsOn LessonItsOn { get; set; }
    }
}
