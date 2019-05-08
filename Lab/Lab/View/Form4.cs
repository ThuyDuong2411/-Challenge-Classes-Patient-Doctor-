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
    public partial class Form4 : Form
    {
        public delegate void AddDoc(Doctor d);
        public event AddDoc adddoc;
        public BLL_Lab blldt { get; set; }
        public Form4()
        {
            InitializeComponent();
            string s = @"Data Source=DESKTOP-9GE8N7A;Initial Catalog=Lab;Integrated Security=True";
            blldt = new BLL_Lab(s);
            LoadNameFac();
            Form2.pdi += new Form2.PassDocInfor(Show_doc);
        }
        public void LoadNameFac()
        {
            cbb_namefac.DataSource = blldt.GetFac();
            cbb_namefac.DisplayMember = "name_fac";
            cbb_namefac.ValueMember = "id_fac";
        }
        private void Show_doc(DataTable d)
        {
            iddoc_txt.Text = d.Rows[0]["id_doc"].ToString();
            namedoc_txt.Text = d.Rows[0]["name_doc"].ToString();
            cbb_namefac.SelectedValue = d.Rows[0]["id_fac"].ToString();
        }
        private void OK_Click(object sender, EventArgs e)
        {
            Doctor d = new Doctor();
            if (iddoc_txt.Text == "") { MessageBox.Show("Nhap ma cho bac si "); }
            else if (iddoc_txt.Text == d.id_doc.ToString()) { MessageBox.Show("Ma bac si bi trung"); }
            else if (namedoc_txt.Text == "") { MessageBox.Show("Nhap ten bac si"); }
            else
            {
                d.id_doc = Convert.ToInt32(iddoc_txt.Text);
                d.name_doc= namedoc_txt.Text;
                d.id_fac = Convert.ToInt32(cbb_namefac.SelectedValue);
            }
            if (adddoc != null)
            {
                adddoc.Invoke(d);
            }
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
