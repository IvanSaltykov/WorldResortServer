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
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCustomer(Customer customer)
        {
            Create(customer);
        }

        public async Task<Customer> GetCustomerAsync(Guid customerId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(customerId), trackChanges).SingleOrDefaultAsync();

        public async Task<Customer> GetCustomerCheckAsync(int seriesPassport, int numberPassport, bool trackChanges) =>
            await FindByCondition(c => (c.PassportSeries.Equals(seriesPassport) && c.PassportNumber.Equals(numberPassport)), trackChanges).SingleOrDefaultAsync();

        public async Task<List<Customer>> GetCustomersAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();
    }
}
