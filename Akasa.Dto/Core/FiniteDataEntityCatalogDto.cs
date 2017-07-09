using System.ComponentModel.DataAnnotations;

namespace Akasa.Dto.Core
{
      public abstract class FiniteDataEntityCatalogDto : FiniteDataEntityDto
      {
            [Required]
            public virtual string Name { get; set; }
            public virtual string Description { get; set; }
      }
}
