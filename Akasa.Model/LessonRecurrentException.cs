using System;
using System.ComponentModel.DataAnnotations.Schema;
using Akasa.Model.Core;

namespace Akasa.Model
{
    public class LessonRecurrentException : FiniteDataEntity
    {
        [ForeignKey(nameof(LessonRecurrent))]
        public int LessonRecurrentId { get; set; }
        public DateTime DateException { get; set; }
        public string Description { get; set; }

        public virtual LessonRecurrent LessonRecurrent { get; set; }
    }
}
