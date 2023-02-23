using ReadSQLTry2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadSQLTry2.Repositories
{
    // Following the repository design pattern
    public interface ICustomerRepository
    { // CRUD: Create, Read, Update, Delete
        // Basic customer
        List<Customer> GetSelectionCustomers(int limit, int offset);
        List<Customer> GetAllCustomers();
        Customer GetCustomerByName(string firstName, string lastName);
        Customer GetCustomerById(int id);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(int id);
        bool AddNewCustomer(Customer customer);

        // countries with number of customers (high-low)
        List<CustomerCountry> GetCountriesAndSortByCustomers();

    }
}