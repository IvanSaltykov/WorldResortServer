using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IDbContext<in TEntity> where TEntity : BaseModel
    {
        Task Create(TEntity model);
        Task Delete(TEntity model);
        Task Update(TEntity model);

    }
}
