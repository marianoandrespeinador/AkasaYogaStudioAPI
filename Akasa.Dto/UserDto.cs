using System;
using Akasa.Dto.Core;

namespace Akasa.Dto
{
      public class UserDto : FiniteDataEntityCatalogDto
      {
            public virtual string FacebookID { get; set; }
            public virtual string Email { get; set; }
            public virtual string Password { get; set; }
            public virtual string PasswordSalt { get; set; }
      }
}
