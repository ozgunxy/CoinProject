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
    public partial class ParaTransfer : Form
    {
        public ParaTransfer()
        {
            InitializeComponent();
        }

        private void ParaTransfer_Load(object sender, EventArgs e)
        {
            string sha = (string)DB.getInstance().executeScalar("SELECT shaadress from public.wallet where userid = '" + user.UserID + "'");
            textBox4.Text = sha;
            textBox1.Text = user.UserName;
            double RcCoin = (double)DB.getInstance().executeScalar("SELECT recyclecoin from public.wallet where userid = '" + user.UserID + "' ");
            label5.Text = RcCoin.ToString();

        }
        public User user;
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Lutfen Bosluklari doldurunuz !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
            DB.getInstance().executeNonQuery("SELECT * FROM transfer('" + textBox4.Text + "','" + textBox2.Text + "','" + Convert.ToDouble(textBox5.Text) + "')");
            double coins = (double)DB.getInstance().executeScalar("select recyclecoin from public.wallet where userid = '" + user.UserID + "'");
            label5.Text = coins.ToString();
            }
            catch (Devart.Data.PostgreSql.PgSqlException ex )
            {
                MessageBox.Show("Yeterli paraniz yok !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch(System.FormatException ex)
            {
                MessageBox.Show("Hata !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

        }
    }
}
