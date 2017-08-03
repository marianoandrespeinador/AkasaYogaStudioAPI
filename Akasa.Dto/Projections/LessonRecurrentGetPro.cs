using System;
using Akasa.Dto.Core;
using Akasa.Dto.POCOs;

namespace Akasa.Dto.Projections
{
    public class LessonRecurrentGetPro : LessonRecurrentGetDto
    { 
        public DateTime NextDate
        {
            get
            {
                DayOfWeek day = Monday ? DayOfWeek.Monday
                    : Tuesday ? DayOfWeek.Tuesday
                    : Wednesday ? DayOfWeek.Wednesday
                    : Thursday ? DayOfWeek.Thursday
                    : Friday ? DayOfWeek.Friday
                    : Saturday ? DayOfWeek.Saturday
                    : DayOfWeek.Sunday;

                DateTime nextDate = DateTime.Now;

                while (!nextDate.DayOfWeek.Equals(day))
                { nextDate = nextDate.AddDays(1); }

                return nextDate;
            }
        }

        [ForceInclude]
        public virtual LessonGetDto Lesson { get; set; }
    }
}
