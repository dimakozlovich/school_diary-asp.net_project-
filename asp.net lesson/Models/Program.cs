using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace prototypedb
{
    class Program
    {
        public static string connectionString = "Server=.\\SQLEXPRESS;Database=TimatableDB;Trusted_Connection=True;TrustServerCertificate=True";
        static async Task Main(string[] args)
        {
            var user = new User("kozlovichdima21@gmail.com","dimaamid");
            var timetable = new Timetable(user.Grade_id);
            Console.WriteLine(timetable.ToString());
        }
    }
}
