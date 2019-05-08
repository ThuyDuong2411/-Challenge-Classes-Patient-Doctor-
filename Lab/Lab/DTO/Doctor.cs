using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Doctor
    {
        public int id_doc { get; set; }
        public string name_doc { get; set; }
        public int id_fac { get; set; }
        public static bool CompareIDDoc(Object d1, Object d2)
        {
            if (((Doctor)d1).id_doc > ((Doctor)d2).id_doc)
                return true;
            else return false;
        }
        public static bool CompareNameDoc(Object d1, Object d2)
        {
            if (string.Compare(((Doctor)d1).name_doc, ((Doctor)d2).name_doc) > 0)
                return true;
            else return false;
        }
    }
}
