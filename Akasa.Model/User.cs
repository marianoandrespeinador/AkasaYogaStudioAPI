using System.Collections.Generic;
using Akasa.Model.Core;

namespace Akasa.Model
{
    public partial class User : FiniteDataEntityCatalog
    {
        public string FacebookID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }

        public virtual List<LessonItsOnXUser> LstLessonItsOnXUser { get; set; } = new List<LessonItsOnXUser>();
        public virtual List<UserInjury> LstUserInjury { get; set; } = new List<UserInjury>();
        public virtual List<UserXRole> LstUserXRole { get; set; } = new List<UserXRole>();
    }
}
