using ReadSQLTry2.Models;
using ReadSQLTry2.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReadSQLTry2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello to SQL");

            ICustomerRepository repository = new CustomerRepository();
            TestSelectAllCustomers(repository);
        }

        static void TestSelect(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomer(25));
        }

        static void TestSelectAllCustomers(ICustomerRepository repository)
        {
            Console.WriteLine("Call PrintCustomers");
            PrintCustomers(repository.GetAllCustomers());
        }

        static void TestInsert(ICustomerRepository repository)
        {
            Customer test = new Customer()
            {
                CustomerId = 25,
                FirstName = "Lasse",
                LastName = "Steinnes",
                Country = "Norway",
                PostalCode = "somewhere-only-we-know",
                Phone = "call-me",
                Email = "lasse-go-gmail",
            };
            if(repository.AddNewCustomer(test)){
                Console.WriteLine("Works");
            } else
            {
                Console.WriteLine("Fails");
            };
            
        }

        static void TestUpdate(ICustomerRepository repository)
        {
            throw new NotImplementedException();
        }

        static void TestDelete(ICustomerRepository repository)
        {
            throw new NotImplementedException();
        }


        static void PrintCustomers(IEnumerable<Customer> customers)
        {
            Console.WriteLine("For each customer print...");
            foreach (Customer customer in customers)
            {
                PrintCustomer(customer);
            }
        }

        static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"---{customer.CustomerId} {customer.FirstName} {customer.LastName} {customer.Country} {customer.Email} {customer.Phone}---");
        }


    }
}
