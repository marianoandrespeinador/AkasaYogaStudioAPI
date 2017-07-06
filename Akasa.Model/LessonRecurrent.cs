using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Akasa.Model.Core;

namespace Akasa.Model
{
    public class LessonRecurrent : FiniteDataEntity
    {
        [ForeignKey(nameof(Lesson))]
        public int LessonId { get; set; }

        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

        public virtual Lesson Lesson { get; set; }
        public virtual List<LessonItsOn> LstLessonItsOn { get; set; } = new List<LessonItsOn>();
        public virtual List<LessonRecurrentException> LstLessonRecurrentException { get; set; } = new List<LessonRecurrentException>();
    }
}
