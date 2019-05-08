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
    public partial class Form5 : Form
    { 
        public delegate void PassPatInfor(DataTable d);
        public static event PassPatInfor ppi;
        public BLL_Lab blldt { get; set; }
        public Form5()
        {
            InitializeComponent();
            string s = @"Data Source=DESKTOP-9GE8N7A;Initial Catalog=Lab;Integrated Security=True";
            blldt = new BLL_Lab(s);
            LoadNameDoc();
            Form2.pd += new Form2.PassDoc(ShowPat);
        }
        private void ShowPat(List<Patient> d)
        {
            dataGridView1.DataSource = d;
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoadNameDoc()
        {
            cbb_doc.DataSource = blldt.GetDoct();
            cbb_doc.DisplayMember = "name_doc";
            cbb_doc.ValueMember = "id_doc";
        }

        private void Show_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = blldt.GetListPatBLL1();
        }
        private void Add_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6();
            f.Show();
            f.addpat += new Form6.AddPat(AddPat);
        }
        public void AddPat(Patient d)
        {
            string id_doc = dataGridView1.SelectedRows[0].Cells["id_doc"].Value.ToString();
            if (blldt.countIDPat(Convert.ToInt32(id_doc)) < 16)
            {
                blldt.AddPat(d);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = blldt.GetListPatBLL1();
            }
        }
        private void Update_Click(object sender, EventArgs e)
        {
            string id_pat = dataGridView1.SelectedRows[0].Cells["id_pat"].Value.ToString();
            Form6 f = new Form6();
            if (ppi != null)
            {
                ppi.Invoke(blldt.GetPatient(Convert.ToInt32(id_pat)));
            }
            f.Show();
            f.addpat += new Form6.AddPat(UpdatePat);
        }
        public void UpdatePat(Patient d)
        {
            blldt.UpdatePat(d);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = blldt.GetListPatBLL1();
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            string id_pat = dataGridView1.SelectedRows[0].Cells["id_pat"].Value.ToString();
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Ban co muon xoa", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                blldt.DeletePat(Convert.ToInt32(id_pat));
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = blldt.GetListPatBLL1();
        }
        private void cbb_doc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = cbb_doc.SelectedValue.ToString();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = blldt.GetListPatient(s);
        }

        private void Search_Click(object sender, EventArgs e)
        {
            List<Patient> list = new List<Patient>();
            dataGridView1.SelectAll();
            foreach (DataGridViewRow i in dataGridView1.SelectedRows)
            {
                list.Add(blldt.GetPat(i.Cells["id_pat"].Value.ToString()));
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = blldt.SearchPat(Search_txt.Text, list);
        }

        private void Sort_Click(object sender, EventArgs e)
        {
            string s = Sort_combo.Text;
            if (s != "")
            {
                dataGridView1.DataSource = blldt.SortPat(s);
            }
            else MessageBox.Show("Chon thuoc tinh can sap xep");
        }
    }
}
