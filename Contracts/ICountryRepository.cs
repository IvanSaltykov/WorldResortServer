using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetCountriesAsync(bool trackChanges);
        Task<Country> GetCountryAsync(Guid countryId, bool trackChanges);
        Task<List<Country>> getCountryByPartworldAsync(Guid partworldId, bool trackChanges);
    }
}
