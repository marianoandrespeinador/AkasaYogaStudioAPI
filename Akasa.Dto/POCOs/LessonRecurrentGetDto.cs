using Akasa.Dto.Core;

namespace Akasa.Dto.POCOs
{
      public class LessonRecurrentGetDto : LessonRecurrentInsertDto
      {
            public virtual int Id { get; set; }

            [ForceInclude]
            public virtual LessonGetDto Lesson { get; set; }
    }
}
