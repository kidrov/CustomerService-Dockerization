using Entities;
using System.Collections.Generic;

namespace Service
{
    public interface ICustomerService
    {
        Customer AddCustomer(Customer customer);
        List<Customer> GetAllCustomers();
    }
}
