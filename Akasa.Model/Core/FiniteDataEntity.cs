using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Akasa.Model.Core
{
    public abstract class FiniteDataEntity
    {
        private DateTime? _dateCreated;

        [Key]
        public int Id { get; set; }

        public DateTime StartDate
        {
            get => _dateCreated ?? DateTime.Now;
            set => _dateCreated = value;
        }

        public DateTime? EndDate { get; set; }
    }
}
