using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPartWorldRepository
    {
        Task<List<PartWorld>> GetPartWorldsAsync(bool trackChanges);
        Task<PartWorld> GetPartWorldAsync(Guid partWorldId, bool trackChanges);
    }
}
