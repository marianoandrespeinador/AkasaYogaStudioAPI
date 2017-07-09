using System;
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
            get => _dateCreated == null ? DateTime.Now : _dateCreated.Value.Year < 2017 ? DateTime.Now : _dateCreated.Value;
            set => _dateCreated = value;
        }

        public DateTime? EndDate { get; set; }
    }
}
