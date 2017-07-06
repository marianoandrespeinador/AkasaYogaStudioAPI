using System;
using Akasa.Dto.Core;

namespace Akasa.Dto
{
      public class UserRoleDto : FiniteDataEntityDto
      {
            public virtual int UserId { get; set; }
            public virtual int VKRole { get; set; }
      }
}
