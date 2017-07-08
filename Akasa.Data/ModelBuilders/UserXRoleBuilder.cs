using Akasa.Data.Core;
using Akasa.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Akasa.Data.ModelBuilders
{
    public class UserXRoleBuilder : EntityToTableBuilder<UserXRole>
    {
        protected override void ConfigureSpecificEntity(EntityTypeBuilder<UserXRole> entity)
        {
            entity.HasKey(e => new {e.UserId, e.VKRole});
        }
    }
}
