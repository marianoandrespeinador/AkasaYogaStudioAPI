using System;

namespace Akasa.Dto.Core
{
    public abstract class FiniteDataEntityDto
    {
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
    }
}
