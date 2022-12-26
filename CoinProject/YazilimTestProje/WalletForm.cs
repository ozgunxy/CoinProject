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
    public partial class WalletForm : Form
    {
        public WalletForm()
        {
            InitializeComponent();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public User user;
        private void button3_Click(object sender, EventArgs e)
        {

            ParaTransfer pt = new ParaTransfer();
            pt.user = user;
            pt.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Hide();
        }

        private void WalletForm_Load(object sender, EventArgs e)
        {
            try
            {
                
                PgSqlConnection conn = new PgSqlConnection("User Id=postgres;password=admin;Host=localhost;Port=8081;Database=INFO;Initial Schema=public");
                PgSqlCommand cmd = new PgSqlCommand("SELECT * FROM usersviews('" + user.UserID + "'); ", conn);
                PgSqlDataReader reader;
                conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    label6.Text = reader.GetString(0);

                    label10.Text = reader.GetString(4) + "RC";
                    label20.Text = reader.GetString(5);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
