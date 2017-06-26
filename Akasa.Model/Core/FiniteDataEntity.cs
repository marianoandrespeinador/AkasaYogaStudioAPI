using System;
using System.ComponentModel.DataAnnotations;

namespace Akasa.Model.Core
{
    public abstract class FiniteDataEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
