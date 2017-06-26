using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Akasa.Model.Core;

namespace Akasa.Model
{
    public partial class LessonDay : FiniteDataEntity
    {
        [ForeignKey(nameof(Lesson))]
        public int LessonId { get; set; }

        public DateTime DateFixed { get; set; }

        public virtual Lesson Lesson { get; set; }
        public ICollection<LessonItsOn> LstLessonItsOn { get; set; } = new List<LessonItsOn>();
    }
}
