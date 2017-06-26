using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Akasa.Data.Core
{
    public abstract class EntityToTableBuilder<T> : IEntityTypeBuilder
        where T: class, new()
    {
        public void ConfigureThisEntity(ModelBuilder modelBuilder)
            => modelBuilder.Entity<T>(entity =>
            {
                entity.ToTable(typeof(T).Name);

                ConfigureSpecificEntity(entity);
            });

        protected abstract void ConfigureSpecificEntity(EntityTypeBuilder<T> entity);
    }
}
