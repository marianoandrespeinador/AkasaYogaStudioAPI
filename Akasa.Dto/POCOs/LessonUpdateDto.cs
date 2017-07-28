using System;

namespace Akasa.Dto.POCOs
{
      public class LessonUpdateDto : LessonInsertDto
      {
            public virtual int Id { get; set; }
      }
}
