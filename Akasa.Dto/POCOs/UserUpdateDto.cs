using System;

namespace Akasa.Dto.POCOs
{
      public class UserUpdateDto : UserInsertDto
      {
            public virtual int Id { get; set; }
      }
}
