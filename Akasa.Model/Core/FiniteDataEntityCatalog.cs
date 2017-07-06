using System.ComponentModel.DataAnnotations;

namespace Akasa.Model.Core
{
    public abstract class FiniteDataEntityCatalog : FiniteDataEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
