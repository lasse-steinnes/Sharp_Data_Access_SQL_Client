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
        Customer GetCustomer(int id);
        List<Customer>  GetAllCustomers();
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(int id);
        bool AddNewCustomer(Customer customer);
    }
}
