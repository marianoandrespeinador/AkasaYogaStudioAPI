using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Akasa.Model.Core;

namespace Akasa.Model
{
    public class Lesson : FiniteDataEntityCatalog
    {
        public ICollection<LessonCost> LstLessonCost { get; set; } = new List<LessonCost>();
        public ICollection<LessonDay> LstLessonDay { get; set; } = new List<LessonDay>();
        public ICollection<LessonRecurrent> LstLessonRecurrent { get; set; } = new List<LessonRecurrent>();
    }
}
