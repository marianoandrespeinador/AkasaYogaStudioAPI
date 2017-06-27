using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Akasa.Model.Core;

namespace Akasa.Services.Core
{
    public interface IService<TDataEntity>
        where TDataEntity : FiniteDataEntity
    {
        Task<TDataEntity> Get(int id);
    }
}
