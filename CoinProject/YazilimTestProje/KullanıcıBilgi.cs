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
    public partial class KullanıcıBilgi : Form
    {
        public KullanıcıBilgi()
        {
            InitializeComponent();
        }
        public User user;
        private void KullanıcıBilgi_Load(object sender, EventArgs e)
        {
            PgSqlConnection conn = new PgSqlConnection("User Id=postgres;password=admin;Host=localhost;Port=8081;Database=INFO;Initial Schema=public");
            PgSqlCommand cmd = new PgSqlCommand("SELECT * FROM usersviews('" + user.UserID + "'); ",conn);
            PgSqlDataReader reader;
            conn.Open();
            reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                label3.Text = reader.GetString(0);
                label7.Text = reader.GetString(1);
                label8.Text = reader.GetString(2);
                label9.Text = reader.GetString(3);
                label10.Text = reader.GetString(4) + "RC";
            }



        }
        MainForm mf = new MainForm();
        private void button2_Click(object sender, EventArgs e)
        {
            mf.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mf.user = user;
            mf.Show();
            this.Hide();
        }
    }
}