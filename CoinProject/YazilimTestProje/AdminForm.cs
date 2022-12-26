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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }
        public void formcontrol()
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.No)
            {

            }
            if (sonuc == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            formcontrol();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PgSqlConnection conn = new PgSqlConnection("User Id=postgres;password=admin;Host=localhost;Port=8081;Database=INFO;Initial Schema=public");
            //PgSqlCommand com = new PgSqlCommand("SELECT * FROM public.Users where UserLoginId = '" + textBox1.Text + "' and UserPassword = '" + textBox2.Text + "'", conn);
            PgSqlDataAdapter add = new PgSqlDataAdapter("SELECT * FROM public.users where UserLoginId = '" + textBox1.Text + "' and UserPassword = '" + textBox2.Text + "'", conn);
            DataTable dt = new DataTable();
            add.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Admin admin = new Admin();
                admin.adminUserName = textBox1.Text;
                AdminMainMenu forms = new AdminMainMenu();
                forms.admin = admin;
                forms.Show();
                this.Hide();                                                          
            }
            else
            {
                MessageBox.Show("ERORR");
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }
    }
}
