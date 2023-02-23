using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ReadSQLTry2.Models
{
    public class Customer
    { 
        // reading off customer from SQL database.
      
        /*  Read all the customers in the database, 
        this should display their: Id, first name, last name, country, postal code, 
        phone number and email.
      
        POCO: Plain old C# class object 
      */

        public int CustomerId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string PostalCode {  get; set; }
        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
