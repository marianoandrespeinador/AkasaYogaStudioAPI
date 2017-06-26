using Microsoft.EntityFrameworkCore;

namespace Akasa.Data.Core
{
    public interface IEntityTypeBuilder
    {
        void ConfigureThisEntity(ModelBuilder modelBuilder);
    }
}
