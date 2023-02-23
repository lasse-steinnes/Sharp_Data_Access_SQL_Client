﻿using ReadSQLTry2.Models;
using ReadSQLTry2.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Xml.Serialization;

namespace ReadSQLTry2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello to SQL");

            ICustomerRepository repository = new CustomerRepository();
            //TestSelectAllCustomers(repository);
            //TestInsert(repository);
            int id = 61;
            //TestGetCustomerByID(repository,id);
            //TestDeleteCustomerByID(repository,id);
            //string first = "Lasse"; string last = "Steinnes";
            //TestGetCustomerByName(repository, first, last);
            TestSelectCustomers(repository);
        }

        static void TestSelect(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomerById(25));
        }

        static void TestSelectAllCustomers(ICustomerRepository repository)
        {
            Console.WriteLine("Call PrintCustomers");
            //PrintCustomers(repository.GetAllCustomers());
            //PrintCustomers(repository.GetAllCustomers());
        }

        static void TestSelectCustomers(ICustomerRepository repository)
        {   
            List<Customer> testCostumerSelection = new List<Customer>();
            int limit = 10; int offset = 5;
            testCostumerSelection = repository.GetSelectionCustomers(limit, offset);
            PrintCustomers(testCostumerSelection);
        }

        static void TestGetCustomerByID(ICustomerRepository repository ,int id)
        {
            Customer testCustomer = new Customer();
            testCustomer = repository.GetCustomerById(id);
            PrintCustomer(testCustomer);
        }

        static void TestGetCustomerByName(ICustomerRepository repository, string first, string last)
        {
            Customer testCustomer = new Customer();
            testCustomer = repository.GetCustomerByName(first,last);
            PrintCustomer(testCustomer);
        }

        static void TestInsert(ICustomerRepository repository)
        {
            Customer testCustomer = new Customer()
            {
                CustomerId = 63,
                FirstName = "Lasse",
                LastName = "Steinnes",
                Country = "Norway",
                PostalCode = "some",
                Phone = "call-me",
                Email = "lasse-go",
            };
            if(repository.AddNewCustomer(testCustomer)){
                Console.WriteLine("Works");
                //PrintCustomer(repository.GetCustomerById(61));
            } else
            {
                Console.WriteLine("Fails");
            };
            
        }

        static void TestUpdate(ICustomerRepository repository)
        {
            throw new NotImplementedException();
        }

        static void TestDeleteCustomerByID(ICustomerRepository repository, int id)
        {
            Console.WriteLine("Accessed Delete");
            bool success = false;
            success = repository.DeleteCustomer(id);
            if (success)
            {
                Console.WriteLine("Customer Deleted");
            }

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