using System;

namespace Akasa.Dto
{
      public class LessonUpdateDto : LessonInsertDto
      {
            public virtual int Id { get; set; }
      }
}
