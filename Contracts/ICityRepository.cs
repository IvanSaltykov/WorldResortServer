using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICityRepository
    {
        Task<List<City>> GetCitiesAsync(bool trackChanges, ResortParameters resortParameters);
        Task<List<City>> GetCitiesbyCountryAsync(Guid countryId,bool trackChanges);
        Task<City> GetCityAsync(Guid cityId, bool trackChanges);
        void CreateCity(City city);
    }
}
 