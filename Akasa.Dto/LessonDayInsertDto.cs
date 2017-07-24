using System;

namespace Akasa.Dto
{
      public class LessonDayInsertDto : LessonDayDto
      {
        //el enddate de lessonday es 2 horas despues de el inicio de la clase (deja de aparecer en las listas)
          public override DateTime? EndDate => DateFixed.AddHours(2);
      }
}
