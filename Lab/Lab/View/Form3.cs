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
    public partial class Form3 : Form
    {
        public delegate void AddHandeler(Faculty d);
        public event AddHandeler add;
        public BLL_Lab blldt { get; set; }
        public Form3()
        {
            InitializeComponent();
            string s = @"Data Source=DESKTOP-9GE8N7A;Initial Catalog=Lab;Integrated Security=True";
            blldt = new BLL_Lab(s);
            Form1.pfi += new Form1.PassFacInfor(Show_fac);
        }
        private void Show_fac(DataTable d)
        {
            idfac_txt.Text = d.Rows[0]["id_fac"].ToString();
            namefac_txt.Text = d.Rows[0]["name_fac"].ToString();
        }
        private void OK_Click(object sender, EventArgs e)
        {
            Faculty d = new Faculty();
            if (idfac_txt.Text == "") { MessageBox.Show("Nhap ma khoa. "); }
            else if (idfac_txt.Text == d.id_fac.ToString()) { MessageBox.Show("Trung ma khoa"); }
            else if (namefac_txt.Text == "") { MessageBox.Show("Nhap ten lop"); }
            else
            {
                d.id_fac = Convert.ToInt32(idfac_txt.Text);
                d.name_fac = namefac_txt.Text;
            }
            if (add != null)
            {
                add.Invoke(d);
            }
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
