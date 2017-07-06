using System;

namespace Akasa.Dto.Core
{
      public abstract class FiniteDataEntityCatalogDto : FiniteDataEntityDto
      {
            public virtual string Name { get; set; }
            public virtual string Description { get; set; }
      }
}
