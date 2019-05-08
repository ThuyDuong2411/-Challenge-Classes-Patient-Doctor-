using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab
{
    public partial class Form6 : Form
    {
        public delegate void AddPat(Patient d);
        public event AddPat addpat;
        public BLL_Lab blldt { get; set; }
        public Form6()
        {
            InitializeComponent();
            string s = @"Data Source=DESKTOP-9GE8N7A;Initial Catalog=Lab;Integrated Security=True";
            blldt = new BLL_Lab(s);
            LoadNameDoc();
            Form5.ppi += new Form5.PassPatInfor(Show_pat);
        }
        public void LoadNameDoc()
        {
            cbb_doc.DataSource = blldt.GetDoct();
            cbb_doc.DisplayMember = "name_doc";
            cbb_doc.ValueMember = "id_doc";
        }
        private void Show_pat(DataTable d)
        {
            idpat_txt.Text = d.Rows[0]["id_pat"].ToString();
            namepat_txt.Text = d.Rows[0]["name_pat"].ToString();
            cbb_doc.SelectedValue = d.Rows[0]["id_doc"].ToString();
        }
        private void OK_Click(object sender, EventArgs e)
        {
            Patient d = new Patient();
            if (idpat_txt.Text == "") { MessageBox.Show("Nhap ma cho benh nhan "); }
            else if (idpat_txt.Text == d.id_doc.ToString()) { MessageBox.Show("Ma benh nhan bi trung"); }
            else if (namepat_txt.Text == "") { MessageBox.Show("Nhap ten bac si"); }
            else
            {
                d.id_pat = Convert.ToInt32(idpat_txt.Text);
                d.name_pat = namepat_txt.Text;
                d.id_doc = Convert.ToInt32(cbb_doc.SelectedValue);
            }
            if (addpat != null)
            {
                addpat.Invoke(d);
            }
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
