using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer customer);
        Task<List<Customer>> GetCustomersAsync(bool trackChanges);
        Task<Customer> GetCustomerAsync(Guid customerId, bool trackChanges);
        Task<Customer> GetCustomerCheckAsync(int seriesPassport, int numberPassport, bool trackChanges);
    }
}
