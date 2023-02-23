using Microsoft.Data.SqlClient;
using ReadSQLTry2.Repositories;
using ReadSQLTry2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ReadSQLTry2.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool AddNewCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            Console.WriteLine("Get All Customers:");
            List <Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE (" +
                "CustomerId IS NOT NULL AND FirstName IS NOT NULL AND LastName IS NOT NULL AND Country IS NOT NULL AND " +
                "PostalCode IS NOT NULL AND Phone IS NOT NULL AND Email IS NOT NULL)";
            // error prone so try catch
            //Console.WriteLine("Here");
            try
            {
                // Connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))

                {
                    // open connection
                    //Console.WriteLine("Here 1");
                    conn.Open();
                    //Console.WriteLine("Here2");
                    // Make a command 
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Handle result by deserializing
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.GetString(3);
                                temp.PostalCode = reader.GetString(4);
                                temp.Phone = reader.GetString(5);
                                temp.Email = reader.GetString(6);

                                customerList.Add(temp);
                                //Console.WriteLine(temp.Email);
          
                            }
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                // l
            }

            return customerList;
        }

        public Customer GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
