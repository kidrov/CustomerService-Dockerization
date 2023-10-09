using DAL;
using Entities;

namespace Service
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepo _repo;
        public CustomerService(ICustomerRepo repo)
        {
            _repo = repo;
        }

        public Customer AddCustomer(Customer customer)
        {
            // Business logic and validation (if needed)
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "Note cannot be null.");
            }

            // Call the repository to create the note
            return _repo.AddCustomer(customer);
        }


        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }



    }
}