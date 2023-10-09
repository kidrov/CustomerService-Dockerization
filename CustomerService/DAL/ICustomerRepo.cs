using Entities;

namespace DAL
{
    public interface ICustomerRepo
    {
        Customer AddCustomer(Customer customer); 
        List<Customer> GetAllCustomers();
    }
}
