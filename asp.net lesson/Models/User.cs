using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
namespace prototypedb
{
    class User
    {
       public int User_id { get; set;}
       public string First_name { get; set; }
       public string Second_name { get; set; }
       private string Email { get; set; }
       private string Password;
       public int Grade_id { get; set; }
       public User(string firstname, string secondname,string email,string password,int grade_id)
       {
            using(var sqlConnection = new SqlConnection(Connection.connection_string))
            {
                sqlConnection.Open();
                var command_string = @$"INSERT INTO Users (firstname,secondname,email,user_password,grade_id)
                                     VALUES('{firstname}','{secondname}','{email}','{password}',{1})";
                var command = new SqlCommand(command_string, sqlConnection);
                command.ExecuteNonQuery();
            }
       }
       public User(string email,string password)
        {
            using (var sqlConnection = new SqlConnection(Connection.connection_string))
            {
                sqlConnection.Open();
                var command_string = @$"Select * from Users 
                                     WHERE email = '{email}' AND user_password = '{password}'";
                var command = new SqlCommand(command_string, sqlConnection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            User_id = reader.GetInt32(0);
                            First_name = reader.GetString(1);
                            Second_name  = reader.GetString(2);
                            Email = reader.GetString(3);
                            Password = reader.GetString(4);
                            Grade_id = reader.GetInt32(5);
                        }
                    }
                }

            }
        }
    }
}
