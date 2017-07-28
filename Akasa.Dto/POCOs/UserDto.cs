using System;
using Akasa.Dto.Core;

namespace Akasa.Dto.POCOs
{
      public class UserDto : FiniteDataEntityCatalogDto
      {
            public virtual string FacebookID { get; set; }
            public virtual string Email { get; set; }
            public virtual string Phone { get; set; }
            public virtual string EmergencyPhone { get; set; }
            public virtual string Password { get; set; }
            public virtual string PasswordSalt { get; set; }
      }
}
