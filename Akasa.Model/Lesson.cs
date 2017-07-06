using System.Collections.Generic;
using Akasa.Model.Core;

namespace Akasa.Model
{
    public class Lesson : FiniteDataEntityCatalog
    {
        public virtual List<LessonCost> LstLessonCost { get; set; } = new List<LessonCost>();
        public virtual List<LessonDay> LstLessonDay { get; set; } = new List<LessonDay>();
        public virtual List<LessonRecurrent> LstLessonRecurrent { get; set; } = new List<LessonRecurrent>();
    }
}
