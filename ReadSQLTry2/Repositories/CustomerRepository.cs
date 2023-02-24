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
using System.Drawing;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
            bool success = false;
            string sql = "DELETE FROM Customer " +
                $"WHERE (CustomerId={id})";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
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

        public List<Customer> GetSelectionCustomers(int limit, int offset) // NOTE: Cannot get OFFSET to work
        {
            List<Customer> customerSelectionList = new List<Customer>();
            string sql = $"SELECT TOP {limit} CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            // $"OFFSET 3 ROWS FETCH NEXT 5 ROWS ONLY";
            // "TOP 3 OFFSET 3";
            // TOP {limit} OFFSET {offset}
            // error prone so try catch
            //Console.WriteLine("Here");
            /* (" +
            "CustomerId IS NOT NULL AND FirstName IS NOT NULL AND LastName IS NOT NULL AND Country IS NOT NULL AND " +
            "PostalCode IS NOT NULL AND Phone IS NOT NULL AND Email IS NOT NULL)";
            */
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

                            customerSelectionList.Add(temp);
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

return customerSelectionList;
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

public Customer GetCustomerByName(string firstName, string lastName)
{   
// Get by name
Customer customer = new Customer();
string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE (" +
    $"FirstName LIKE '%{firstName}%' AND LastName LIKE '%{lastName}%' AND CustomerId IS NOT NULL AND Country IS NOT NULL AND " +
    "PostalCode IS NOT NULL AND Phone IS NOT NULL AND Email IS NOT NULL)";
// error prone so try catch
try
{
    // Connect
    using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
    {
        conn.Open();

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

public Customer GetCustomerById(int id)
{   // Write code to get customer by ID 
Customer customer = new Customer();
string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE (" +
    $"CustomerId={id})"; 
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
        //Console.WriteLine("Here opened");
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

        public List<CustomerCountry> GetCountriesAndSortByCustomers()
        {   
            List<CustomerCountry> countryList = new List<CustomerCountry>();
            string sql = "SELECT Country, COUNT(CustomerId) FROM Customer GROUP BY Country ORDER BY COUNT(CustomerID) DESC";

            try
            {
                // Connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))

                {
                    // open connection
                    conn.Open();
                    // Make a command 
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Handle result by deserializing
                                CustomerCountry temp = new CustomerCountry();
                                temp.Country = reader.GetString(0);
                                temp.Count = reader.GetInt32(1);
                               
                                countryList.Add(temp);
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

            return countryList;
        }

        public List<CustomerSpender> GetSpendersAndSortByTotal()
        {
            List<CustomerSpender> spenderList = new List<CustomerSpender>();

            string sql = "SELECT CustomerId, Total FROM Invoice ORDER BY Total DESC";

            try
            {
                // Connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))

                {
                    // open connection
                    conn.Open();
                    // Make a command 
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Handle result by deserializing
                                CustomerSpender temp = new CustomerSpender();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.InvoiceTotal = reader.GetDecimal(1);

                                spenderList.Add(temp);
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

            return spenderList;
        }
    }
}
// NONquery: Insert, update and delete
// Query: Travese sequential from database