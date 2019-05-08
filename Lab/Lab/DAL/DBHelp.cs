using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab
{
    public class DBHelp
    {
        SqlConnection cnn { get; set; }
        public DBHelp(string s)
        {
            cnn = new SqlConnection(s);
        }
        public void ExcuteDB(string query)
        {
            SqlCommand cmd = new SqlCommand(query, this.cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void ExcuteDBWithValue(string query, Faculty d)
        {
            SqlCommand cmd = new SqlCommand(query, this.cnn);
            cmd.Parameters.Add(new SqlParameter("@id_fac", d.id_fac));
            cmd.Parameters.Add(new SqlParameter("@name_fac", d.name_fac));
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void ExcuteDBWithValue1(string query, int id_fac)
        {
            SqlCommand cmd = new SqlCommand(query, this.cnn);
            cmd.Parameters.Add(new SqlParameter("@id_fac", id_fac));
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void ExcuteDBWithValue2(string query, Doctor d)
        {
            SqlCommand cmd = new SqlCommand(query, this.cnn);
            cmd.Parameters.Add(new SqlParameter("@id_doc", d.id_doc));
            cmd.Parameters.Add(new SqlParameter("@name_doc", d.name_doc));
            cmd.Parameters.Add(new SqlParameter("@id_fac", d.id_fac));
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void ExcuteDBWithValue3(string query, int id_doc)
        {
            SqlCommand cmd = new SqlCommand(query, this.cnn);
            cmd.Parameters.Add(new SqlParameter("@id_doc", id_doc));
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void ExcuteDBWithValue4(string query, Patient d)
        {
            SqlCommand cmd = new SqlCommand(query, this.cnn);
            cmd.Parameters.Add(new SqlParameter("@id_pat", d.id_pat));
            cmd.Parameters.Add(new SqlParameter("@name_pat", d.name_pat));
            cmd.Parameters.Add(new SqlParameter("@id_doc", d.id_doc));
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void ExcuteDBWithValue5(string query, int id_pat)
        {
            SqlCommand cmd = new SqlCommand(query, this.cnn);
            cmd.Parameters.Add(new SqlParameter("@id_pat", id_pat));
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public DataTable GetTable(string query)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, cnn);
            DataTable dt = new DataTable();
            cnn.Open();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }
    }
}
