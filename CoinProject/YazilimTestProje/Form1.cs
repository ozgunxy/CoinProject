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
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();

        }
        User user;
     

        private void UserLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PgSqlConnection conn = new PgSqlConnection("User Id=postgres;password=admin;Host=localhost;Port=8081;Database=INFO;Initial Schema=public");
            //PgSqlCommand com = new PgSqlCommand("SELECT * FROM public.Users where UserLoginId = '" + textBox1.Text + "' and UserPassword = '" + textBox2.Text + "'", conn);
            PgSqlDataAdapter add = new PgSqlDataAdapter("SELECT * FROM public.users where UserLoginId = '" + textBox1.Text + "' and UserPassword = '" + textBox2.Text + "'", conn);
            DataTable dt = new DataTable();
            add.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                user = new User(textBox1.Text, textBox2.Text);
                MainForm forms = new MainForm();
                forms.user = user;
                forms.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("ERORR");
            }
        }
        kayitformu kf = new kayitformu();
        private void button2_Click(object sender, EventArgs e)
        {
            kf.Show();
            this.Hide();
        }
    }
}