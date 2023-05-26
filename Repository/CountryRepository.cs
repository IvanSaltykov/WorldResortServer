using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<List<Country>> GetCountriesAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<Country> GetCountryAsync(Guid countryId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(countryId), trackChanges).SingleOrDefaultAsync();

        public async Task<List<Country>> getCountryByPartworldAsync(Guid partworldId, bool trackChanges) =>
            await FindByCondition(c => c.PartWorldId.Equals(partworldId), trackChanges).ToListAsync();
    }
}
