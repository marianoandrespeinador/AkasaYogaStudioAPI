using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Akasa.Model.Core;

namespace Akasa.Model
{
    /// <summary>
    /// Specific fixed lesson on a date. It should be inserted when user confirms assistance.
    /// </summary>
    public partial class LessonItsOn : FiniteDataEntity
    {
        [ForeignKey(nameof(LessonRecurrent))]
        public int? LessonRecurrentId { get; set; }
        [ForeignKey(nameof(LessonDay))]
        public int? LessonDayId { get; set; }

        public DateTime DateItsOn { get; set; }

        public virtual LessonRecurrent LessonRecurrent { get; set; }
        public virtual LessonDay LessonDay { get; set; }
        public virtual List<LessonItsOnXUser> LstLessonItsOnXUser { get; set; } = new List<LessonItsOnXUser>();
    }
}
