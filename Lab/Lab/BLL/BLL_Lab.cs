using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public delegate bool CompareFac(Object s1, Object s2);
    public delegate bool CompareDoc(Object s1, Object s2);
    public delegate bool ComparePat(Object s1, Object s2);
    public class BLL_Lab
    {
        public DAL_Lab daldt { get; set; }

        public BLL_Lab(string s)
        {
            daldt = new DAL_Lab(s);
        }
        public List<Faculty> GetListFacBLL()
        {
            return daldt.GetListFacDAL();
        }
        public void AddFac(Faculty d)
        {
            daldt.AddFac(d);
        }
        public DataTable GetFaculty(int id_fac)
        {
            return daldt.GetFaculty(id_fac);
        }
        public DataTable GetFac()
        {
            return daldt.GetFac();
        }
        public void UpdateFac(Faculty d)
        {
            daldt.UpdateFac(d);
        }
        public void DeleteFac(int id_fac)
        {
            daldt.DeleteFac(id_fac);
        }
        public List<Faculty> SearchFac(string s, List<Faculty> list)
        {
            List<Faculty> listsearch = new List<Faculty>();
            foreach (Faculty i in list)
            {
                if (i.id_fac.ToString().Contains(s) || i.name_fac.Contains(s))
                {
                    listsearch.Add(i);
                }
            }
            return listsearch;
        }
        public List<Faculty> MySort(List<Faculty> l, CompareFac co)
        {
            for (int i = 0; i < l.Count; ++i)
                for (int j = i + 1; j < l.Count; ++j)
                    if (co(l[i], l[j]))
                    {
                        Faculty t = l[i];
                        l[i] = l[j];
                        l[j] = t;
                    }
            return l;
        }
        public List<Faculty> SortFac(string s)
        {
            List<Faculty> listsort = new List<Faculty>(GetListFacBLL());
            switch (s)
            {
                case "id_fac":
                    CompareFac cmp1 = new CompareFac(Faculty.CompareIDFac);
                    return MySort(listsort, cmp1);
                case "name_fac":
                    CompareFac cmp2 = new CompareFac(Faculty.CompareNameFac);
                    return MySort(listsort, cmp2);
                default:
                    return listsort;
            }
        }
        public List<Doctor> GetListDocBLL()
        { 
            return daldt.GetListDocDAL();
        }
        public List<Doctor> GetListDocBLL1(int id_fac)
        {
            return daldt.GetListDocDAL1(id_fac);
        }
        public List<Doctor> GetListDoctor(string id_fac)
        {
            List<Doctor> list = new List<Doctor>(100);
            foreach (Doctor i in GetListDocBLL())
            {
                if (i.id_fac.ToString().Contains(id_fac))
                    list.Add(i);
            }
            return list;
        }
        public Doctor GetDoc(string id_doc)
        {
            foreach (Doctor i in GetListDocBLL())
            {
                if (i.id_doc == Convert.ToInt32(id_doc))
                    return i;
            }
            return null;
        }
        public DataTable GetDoctor(int id_doc)
        {
            return daldt.GetDoctor(id_doc);
        }
        public DataTable GetDoct()
        {
            return daldt.GetDoct();
        }
        public void AddDoc(Doctor d)
        {
            daldt.AddDoc(d);
        }
        public void UpdateDoc(Doctor d)
        {
            daldt.UpdateDoc(d);
        }
        public void DeleteDoc(int id_doc)
        {
            daldt.DeleteDoc(id_doc);
        }
        public List<Doctor> SearchDoc(string s, List<Doctor> list)
        {
            List<Doctor> listsearch = new List<Doctor>();
            foreach (Doctor i in list)
            {
                if (i.id_fac.ToString().Contains(s) || i.name_doc.Contains(s) || i.id_doc.ToString().Contains(s))
                {
                    listsearch.Add(i);
                }
            }
            return listsearch;
        }
        public List<Doctor> MySortDoc(List<Doctor> l, CompareDoc co)
        {
            for (int i = 0; i < l.Count; ++i)
                for (int j = i + 1; j < l.Count; ++j)
                    if (co(l[i], l[j]))
                    {
                        Doctor t = l[i];
                        l[i] = l[j];
                        l[j] = t;
                    }
            return l;
        }
        public List<Doctor> SortDoc(string s)
        {
            List<Doctor> listsort = new List<Doctor>(GetListDocBLL());
            switch (s)
            {
                case "id_doc":
                    CompareDoc cmp1 = new CompareDoc(Doctor.CompareIDDoc);
                    return MySortDoc(listsort, cmp1);
                case "name_doc":
                    CompareDoc cmp2 = new CompareDoc(Doctor.CompareNameDoc);
                    return MySortDoc(listsort, cmp2);
                default:
                    return listsort;
            }
        }
        public List<Patient> GetListPatBLL(int id_doc)
        {
            return daldt.GetListPatDAL(id_doc);
        }
        public List<Patient> GetListPatBLL1()
        {
            return daldt.GetListPatDAL1();
        }
        public void AddPat(Patient d)
        {
            daldt.AddPat(d);
        }
        public DataTable GetPatient(int id_pat)
        {
            return daldt.GetPatient(id_pat);
        }
        public void UpdatePat(Patient d)
        {
            daldt.UpdatePat(d);
        }
        public void DeletePat(int id_pat)
        {
            daldt.DeletePat(id_pat);
        }
        public List<Patient> GetListPatient(string id_doc)
        {
            List<Patient> list = new List<Patient>(100);
            foreach (Patient i in GetListPatBLL1())
            {
                if (i.id_doc.ToString().Contains(id_doc))
                    list.Add(i);
            }
            return list;
        }
        public Patient GetPat(string id_pat)
        {
            foreach (Patient i in GetListPatBLL1())
            {
                if (i.id_pat == Convert.ToInt32(id_pat))
                    return i;
            }
            return null;
        }
        public List<Patient> SearchPat(string s, List<Patient> list)
        {
            List<Patient> listsearch = new List<Patient>();
            foreach (Patient i in list)
            {
                if (i.id_pat.ToString().Contains(s) || i.name_pat.Contains(s) || i.id_doc.ToString().Contains(s))
                {
                    listsearch.Add(i);
                }
            }
            return listsearch;
        }
        public List<Patient> MySortPat(List<Patient> l, ComparePat co)
        {
            for (int i = 0; i < l.Count; ++i)
                for (int j = i + 1; j < l.Count; ++j)
                    if (co(l[i], l[j]))
                    {
                        Patient t = l[i];
                        l[i] = l[j];
                        l[j] = t;
                    }
            return l;
        }
        public List<Patient> SortPat(string s)
        {
            List<Patient> listsort = new List<Patient>(GetListPatBLL1());
            switch (s)
            {
                case "id_pat":
                    ComparePat cmp1 = new ComparePat(Patient.CompareIDPat);
                    return MySortPat(listsort, cmp1);
                case "name_pat":
                    ComparePat cmp2 = new ComparePat(Patient.CompareNamePat);
                    return MySortPat(listsort, cmp2);
                default:
                    return listsort;
            }
        }
        public int countIDPat(int id_pat)
        {
            int count = 0;
            count = daldt.countIDPat(id_pat);
            return count;
        }
    }
}
