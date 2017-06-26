using System.ComponentModel.DataAnnotations.Schema;
using Akasa.Model.Core;

namespace Akasa.Model
{
    public partial class UserInjury : FiniteDataEntity
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public string InjuryDescription { get; set; }

        public virtual User User { get; set; }
    }
}
