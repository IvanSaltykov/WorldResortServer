using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCity(City city)
        {
            Create(city);
        }

        public async Task<List<City>> GetCitiesAsync(bool trackChanges, ResortParameters resortParameters)
        {
            //var result = await FindByCondition(c => 
            //    (c.TherapeuticMud == resortParameters.TherapeuticMud && c.MineralWater == resortParameters.MineralWater && c.Climate == resortParameters.Climate), trackChanges)
            //    .ToListAsync();
            var result = await FindAll(trackChanges).ToListAsync();
            return result;
        }

        public async Task<List<City>> GetCitiesbyCountryAsync(Guid countryId, bool trackChanges) =>
            await FindByCondition(c => c.CountryId.Equals(countryId), trackChanges).ToListAsync();

        public async Task<City> GetCityAsync(Guid cityId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(cityId), trackChanges).SingleOrDefaultAsync();
    }
}
