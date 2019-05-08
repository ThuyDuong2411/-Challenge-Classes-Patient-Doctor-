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
    public partial class Form2 : Form
    {
        public delegate void PassDoc (List<Patient> d);
        public static event PassDoc pd ;

        public delegate void PassDocInfor(DataTable d);
        public static event PassDocInfor pdi;
        public BLL_Lab blldt { get; set; }
        public Form2()
        {
            InitializeComponent();
            string s = @"Data Source=DESKTOP-9GE8N7A;Initial Catalog=Lab;Integrated Security=True";
            blldt = new BLL_Lab(s);
            LoadNameFac();
            Form1.pf += new Form1.PassFac(ShowDoc);
        }
        private void ShowDoc(List<Doctor> d)
        {
            dataGridView1.DataSource = d;
        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string id_doc = dataGridView1.SelectedRows[0].Cells["id_doc"].Value.ToString();
            Form5 f = new Form5();
            if (pd != null)
            {
                pd.Invoke(blldt.GetListPatBLL(Convert.ToInt32(id_doc)));
            }
            f.Show();
        }
        public void LoadNameFac()
        {
            cbb_fac.DataSource = blldt.GetFac();
            cbb_fac.DisplayMember = "name_fac";
            cbb_fac.ValueMember = "id_fac";
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Show_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= blldt.GetListDocBLL();
        }
        private void Add_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
            f.adddoc += new Form4.AddDoc(AddDoc);
        }
        public void AddDoc(Doctor d)
        {
            blldt.AddDoc(d);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = blldt.GetListDocBLL();
        }
        private void Update_Click(object sender, EventArgs e)
        {
            string id_doc = dataGridView1.SelectedRows[0].Cells["id_doc"].Value.ToString();
            Form4 f = new Form4();
            if (pdi != null)
            {
                pdi.Invoke(blldt.GetDoctor(Convert.ToInt32(id_doc)));
            }
            f.Show();
            f.adddoc += new Form4.AddDoc(UpdateDoc);
        }
        public void UpdateDoc(Doctor d)
        {
            blldt.UpdateDoc(d);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = blldt.GetListDocBLL();
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            string id_doc = dataGridView1.SelectedRows[0].Cells["id_doc"].Value.ToString();
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Ban co muon xoa", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                blldt.DeleteDoc(Convert.ToInt32(id_doc));
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = blldt.GetListDocBLL();
        }
        private void cbb_fac_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = cbb_fac.SelectedValue.ToString();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = blldt.GetListDoctor(s);
        }
        private void Search_Click(object sender, EventArgs e)
        {
            List<Doctor> list = new List<Doctor>();
            dataGridView1.SelectAll();
            foreach (DataGridViewRow i in dataGridView1.SelectedRows)
            {
                list.Add(blldt.GetDoc(i.Cells["id_doc"].Value.ToString()));
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = blldt.SearchDoc(Search_txt.Text, list);
        }
        private void Sort_Click(object sender, EventArgs e)
        {
            string s = Sort_combo.Text;
            if (s != "")
            {
                dataGridView1.DataSource = blldt.SortDoc(s);
            }
            else MessageBox.Show("Chon thuoc tinh can sap xep");
        }
    }
}
