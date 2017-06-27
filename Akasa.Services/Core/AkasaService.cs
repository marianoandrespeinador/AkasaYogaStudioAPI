using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Akasa.Data;
using Akasa.Model.Core;
using Microsoft.EntityFrameworkCore;

namespace Akasa.Services.Core
{
    public class AkasaService<TDataEntity> : IService<TDataEntity>
        where TDataEntity: FiniteDataEntity
    {
        protected DbSet<TDataEntity> ThisDbSet;

        public AkasaService(AkasaDBContext context)
        {
            ThisDbSet = context.Set<TDataEntity>();
        }

        public virtual async Task<TDataEntity> Get(int id)
        {
            return await ThisDbSet.FirstAsync(e => e.Id == id);
        }

    }
}
