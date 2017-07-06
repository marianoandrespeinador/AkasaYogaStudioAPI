using Akasa.Data.Core;
using Akasa.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Akasa.Data.ModelBuilders
{
    public class LessonItsOnXUserBuilder : EntityToTableBuilder<LessonItsOnXUser>
    {
        protected override void ConfigureSpecificEntity(EntityTypeBuilder<LessonItsOnXUser> entity)
        {
            entity.HasKey(e => new {e.UserId, e.LessonItsOnId});
        }
    }
}
