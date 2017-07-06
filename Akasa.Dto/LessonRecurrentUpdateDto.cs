using System;

namespace Akasa.Dto
{
      public class LessonRecurrentUpdateDto : LessonRecurrentInsertDto
      {
            public virtual int Id { get; set; }
      }
}
