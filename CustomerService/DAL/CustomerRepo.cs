using System;
using System.Linq;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
 
    public class CustomerRepo : ICustomerRepo
    {
        private readonly KeepDbContext _dbContext;

        public CustomerRepo(KeepDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Customer AddCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return customer; 
        }


        public List<Customer> GetAllCustomers()
        {
            return _dbContext.Customers.ToList();
        }



    }
}
