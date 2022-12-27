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
     class DB
    {
        private static DB instance = null;
        private PgSqlConnection conn;
        private PgSqlCommand cmd;
        private DataTable dt;

        private DB()
        {
            conn = new PgSqlConnection(constring.conn);
            cmd = new PgSqlCommand("", conn);
            dt = new DataTable();
        }

        public static DB getInstance()
        {
            if(instance == null)
            {
                instance = new DB();
            }
            return instance;
        }

        public DataTable executeDataTable(string query)
        {
            conn.Open();
            cmd.CommandText = query;
            dt.Clear();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            return dt;
        }

        public int executeNonQuery(string query)
        {
            conn.Open();
            cmd.CommandText = query;
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        public object executeScalar(string sqlStatement)
        {
            conn.Open();
            cmd.CommandText = sqlStatement;
            object obj = cmd.ExecuteScalar();
            conn.Close();
            return obj;
        }
        public PgSqlDataReader MakeAreader(string query)
        {
            cmd.CommandText = query;
            conn.Open();
            PgSqlDataReader reader = cmd.ExecuteReader();
            conn.Close();
            return reader;
        }
        public ComboBox MakeComboBox(string query)
        {
            cmd.CommandText = query;
            ComboBox CB = new ComboBox();
            conn.Open();
            PgSqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                CB.Items.Add(reader.GetString(0));
            }
            conn.Close();
            return CB;
        }
    }
}
