using Akasa.Dto.Core;

namespace Akasa.Dto.POCOs
{
      public class UserInjuryDto : FiniteDataEntityDto
      {
            public virtual int UserId { get; set; }
            public virtual string InjuryDescription { get; set; }
      }
}
