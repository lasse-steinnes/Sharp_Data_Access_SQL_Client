﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadSQLTry2.Models
{
    public class CustomerSpender
    {
        public int CustomerId { get; set; }
        public decimal InvoiceTotal { get; set; }
    }
}
