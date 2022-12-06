using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace prototypedb
{
    public static class Connection
    {
        public static string connection_string = "Server=.\\SQLEXPRESS;Database=TimatableDB;Trusted_Connection=True;TrustServerCertificate=True";
        
    }
}
