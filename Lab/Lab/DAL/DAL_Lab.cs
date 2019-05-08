using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class DAL_Lab
    {
        public DBHelp dbhelp { get; set; }
        SqlConnection cnn { get; set; }
        public DAL_Lab(string s)
        {
            cnn = new SqlConnection(s);
            dbhelp = new DBHelp(s);
        }
        public List<Faculty> GetListFacDAL()
        {
            List<Faculty> list = new List<Faculty>();
            string sql = "select * from Faculty";
            foreach (DataRow i in dbhelp.GetTable(sql).Rows)
            {
                list.Add(GetFacDAL(i));
            }
            return list;
        }
        public Faculty GetFacDAL(DataRow d)
        {
            return new Faculty()
            {
                id_fac = Convert.ToInt32(d["id_fac"].ToString()),
                name_fac = (d["name_fac"]).ToString()
            };
        }
        public void AddFac(Faculty d)
        {
            string add = "insert into Faculty values (@id_fac,@name_fac)";
            dbhelp.ExcuteDBWithValue(add, d);
        }
        public DataTable GetFaculty(int id_fac)
        {
            return dbhelp.GetTable("select * from Faculty where id_fac = " + id_fac);
        }
        public DataTable GetFac()
        {
            return dbhelp.GetTable("select * from Faculty");
        }
        public void UpdateFac(Faculty d)
        {
            string update = "update Faculty set name_fac = @name_fac where id_fac = @id_fac";
            dbhelp.ExcuteDBWithValue(update, d);
        }
        public void DeleteFac(int id_fac)
        {
            string delete = "delete from Faculty where id_fac = @id_fac";
            dbhelp.ExcuteDBWithValue1(delete, id_fac);
        }
        public List<Doctor> GetListDocDAL()
        {
            List<Doctor> list = new List<Doctor>();
            string sql = "select * from Doctor";
            foreach (DataRow i in dbhelp.GetTable(sql).Rows)
            {
                list.Add(GetDocDAL(i));
            }
            return list;
        }
        public List<Doctor> GetListDocDAL1(int id_fac)
        {
            List<Doctor> list = new List<Doctor>();
            string sql = "select * from Doctor inner join Faculty on Doctor.id_fac = Faculty.id_fac where Faculty.id_fac = " + id_fac;
            foreach (DataRow i in dbhelp.GetTable(sql).Rows)
            {
                list.Add(GetDocDAL(i));
            }
            return list;
        }
        public Doctor GetDocDAL(DataRow d)
        {
            return new Doctor()
            {
                id_doc = Convert.ToInt32(d["id_doc"].ToString()),
                name_doc = (d["name_doc"]).ToString(),
                id_fac = Convert.ToInt32(d["id_fac"].ToString())
            };
        }
        public DataTable GetDoct()
        {
            return dbhelp.GetTable("select id_doc, name_doc from Doctor");
        }
        public void AddDoc(Doctor d)
        {
            string add = "insert into Doctor values (@id_doc,@name_doc,@id_fac)";
            dbhelp.ExcuteDBWithValue2(add, d);
        }
        public DataTable GetDoctor(int id_doc)
        {
            return dbhelp.GetTable("select * from Doctor where id_doc = " + id_doc);
        }
        public void UpdateDoc(Doctor d)
        {
            string update = "update Doctor set name_doc = @name_doc, id_fac = @id_fac where id_doc = @id_doc";
            dbhelp.ExcuteDBWithValue2(update, d);
        }
        public void DeleteDoc(int id_doc)
        {
            string delete = "delete from Doctor where id_doc = @id_doc";
            dbhelp.ExcuteDBWithValue3(delete, id_doc);
        }
        public List<Patient> GetListPatDAL(int id_doc)
        {
            List<Patient> list = new List<Patient>();
            string sql = "select * from Patient inner join Doctor on Patient.id_doc = Doctor.id_doc where Doctor.id_doc = " + id_doc;
            foreach (DataRow i in dbhelp.GetTable(sql).Rows)
            {
                list.Add(GetPatDAL(i));
            }
            return list;
        }
        public Patient GetPatDAL(DataRow d)
        {
            return new Patient()
            {
                id_pat = Convert.ToInt32(d["id_pat"].ToString()),
                name_pat = (d["name_pat"]).ToString(),
                id_doc = Convert.ToInt32(d["id_doc"].ToString())
            };
        }
        public List<Patient> GetListPatDAL1()
        {
            List<Patient> list = new List<Patient>();
            string sql = "select * from Patient";
            foreach (DataRow i in dbhelp.GetTable(sql).Rows)
            {
                list.Add(GetPatDAL(i));
            }
            return list;
        }
        public void AddPat(Patient d)
        {
            string add = "insert into Patient values (@id_pat,@name_pat,@id_doc)";
            dbhelp.ExcuteDBWithValue4(add, d);
        }
        public DataTable GetPatient(int id_pat)
        {
            return dbhelp.GetTable("select * from Patient where id_pat = " + id_pat);
        }
        public void UpdatePat(Patient d)
        {
            string update = "update Patient set name_pat = @name_pat, id_doc = @id_doc where id_pat = @id_pat";
            dbhelp.ExcuteDBWithValue4(update, d);
        }
        public void DeletePat(int id_pat)
        {
            string delete = "delete from Patient where id_pat = @id_pat";
            dbhelp.ExcuteDBWithValue5(delete, id_pat);
        }
        public int countIDPat(int id_doc)
        {
            int count = 0;
            string sql = "select count(id_pat) from Patient where id_doc = "+ id_doc;
            count = Convert.ToInt32(dbhelp.GetTable(sql).Rows[0][0].ToString());
            return count;
        }
    }
}
