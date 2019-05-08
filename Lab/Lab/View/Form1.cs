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
    public partial class Form1 : Form
    {
        public delegate void PassFac(List<Doctor> d);
        public static event PassFac pf;

        public delegate void PassFacInfor(DataTable d);
        public static event PassFacInfor pfi;
        public BLL_Lab blldt { get; set; }
        public Form1()
        {
            InitializeComponent();
            string s = @"Data Source=DESKTOP-9GE8N7A;Initial Catalog=Lab;Integrated Security=True";
            blldt = new BLL_Lab(s);
        }
        private void Show_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = blldt.GetListFacBLL();
        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string id_fac = dataGridView1.SelectedRows[0].Cells["id_fac"].Value.ToString();
            Form2 f = new Form2();
            if (pf != null)
            {
                pf.Invoke(blldt.GetListDocBLL1(Convert.ToInt32(id_fac)));
            }
            f.Show();
        }
        private void Add_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            f.add += new Form3.AddHandeler(AddFac);
        }
        public void AddFac(Faculty d)
        {
            blldt.AddFac(d);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = blldt.GetListFacBLL();
        }
        private void Update_Click(object sender, EventArgs e)
        {
            string id_fac = dataGridView1.SelectedRows[0].Cells["id_fac"].Value.ToString();
            Form3 f = new Form3();
            if (pfi != null)
            {
                pfi.Invoke(blldt.GetFaculty(Convert.ToInt32(id_fac)));
            }
            f.Show();
            f.add += new Form3.AddHandeler(UpdateFac);
        }
        public void UpdateFac(Faculty d)
        {
            blldt.UpdateFac(d);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = blldt.GetListFacBLL();
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            string id_fac = dataGridView1.SelectedRows[0].Cells["id_fac"].Value.ToString();
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Ban co muon xoa", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                blldt.DeleteFac(Convert.ToInt32(id_fac));
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = blldt.GetListFacBLL();
        }
        private void Search_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = blldt.SearchFac(Search_txt.Text,blldt.GetListFacBLL());
        }
        private void Sort_Click(object sender, EventArgs e)
        {
            string s = Sort_combo.Text;
            if (s != "")
            {
                dataGridView1.DataSource = blldt.SortFac(s);
            }
            else MessageBox.Show("Chon thuoc tinh can sap xep");
        }
    }
}
