using Microsoft.Data.SqlClient;
using ReadSQLTry2.Repositories;
using ReadSQLTry2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Runtime.Remoting.Messaging;
using System.Data;

namespace ReadSQLTry2.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool AddNewCustomer(Customer customer)
        {
            bool success = false;
            string sql = "SET IDENTITY_INSERT Customer ON " +
                "INSERT INTO Customer(CustomerId,FirstName,LastName,Country,PostalCode,Phone,Email)" +
                "VALUES(@CustomerId,@FirstName,@LastName,@Country,@PostalCode,@Phone,@Email) " +
                "SET IDENTITY_INSERT Customer OFF";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Console.WriteLine(customer);
                        cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        //int testParam = cmd.ExecuteNonQuery();
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }

            }
            
            catch(SqlException ex)
            {
                // log
                Console.WriteLine(ex.ToString());
            }
            return success;
        }

        public bool DeleteCustomer(int id)
        {   
            // Delete customer...
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
                Console.WriteLine(ex.ToString());
            }

            return customerList;
        }

        public Customer GetCustomer(int id)
        {   // Write code to get customer by ID 
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE (" +
                $"CustomerId IS NOT NULL AND CustomerId={id})"; 
            // AND CustomerId=@CustomerId)";
            // AND FirstName IS NOT NULL AND LastName IS NOT NULL AND Country IS NOT NULL AND " +
            //"PostalCode IS NOT NULL AND Phone IS NOT NULL AND Email IS NOT NULL)";
            // error prone so try catch
            try
            {
                // Connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))

                {
                    // open connection
                    //Console.WriteLine("Here 1");
                    conn.Open();
                    Console.WriteLine("Here opened");
                    // Make a command 
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            // Handle result by deserializing
                            customer.CustomerId = reader.GetInt32(0);
                            customer.FirstName = reader.GetString(1);
                            customer.LastName = reader.GetString(2);
                            customer.Country = reader.GetString(3);
                            customer.PostalCode = reader.GetString(4);
                            customer.Phone = reader.GetString(5);
                            customer.Email = reader.GetString(6);
                            Console.WriteLine("Has read");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return customer;
        }

        public bool UpdateCustomer(Customer customer)
        {
            bool success = false;
            string sql = "Update Customer " +
                "SET CustomerId = @CustomerId, FirstName = @FirstName, LastName = @LastName, " +
                "Country = @Country, PostalCode = @PostalCode, Phone = @Phone, Email = @Email";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Console.WriteLine(customer);
                        cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }

            catch (SqlException ex)
            {
                // log
                Console.WriteLine(ex.ToString());
            }
            return success;

        }
    }
}
// NONquery: Insert, update and delete
// Query: Travese sequential from database