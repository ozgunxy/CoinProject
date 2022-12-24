using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Devart.Data.PostgreSql;
using Devart.Data;
using Devart.Common;
namespace YazilimTestProje
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }

        public Wallet wallet { get; set; }


        public User(string username, string password)
        {
            UserLogin(username, password);
            wallet = new Wallet(this);
        }


        private void UserLogin(string username,string password)
        {
            PgSqlConnection conn = new PgSqlConnection("User Id=postgres;password=admin;Host=localhost;Port=8081;Database=INFO;Initial Schema=public");
            PgSqlCommand c = new PgSqlCommand("SELECT UserId from public.users where UserLoginId = '" + username + "' ", conn);
            conn.Open();
            int userID = (int)c.ExecuteScalar();
            conn.Close();

            
            PgSqlDataReader reader;
            PgSqlCommand cm = new PgSqlCommand("SELECT * FROM public.users where userid = '" + userID + "'", conn);
            conn.Open();
            reader = cm.ExecuteReader();
            while(reader.Read())
            {
                FirstName = reader.GetString(3);
                lastName = reader.GetString(4);
                Email = reader.GetString(5);
            }
            conn.Close();
           
            UserID = userID;
            UserName = username;
            Password = password;
            
          

        }
    }
}

