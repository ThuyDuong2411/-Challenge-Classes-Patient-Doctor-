using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Patient
    {
        public int id_pat { get; set; }
        public string name_pat { get; set; }
        public int id_doc { get; set; }
        public static bool CompareIDPat(Object d1, Object d2)
        {
            if (((Patient)d1).id_pat > ((Patient)d2).id_pat)
                return true;
            else return false;
        }
        public static bool CompareNamePat(Object d1, Object d2)
        {
            if (string.Compare(((Patient)d1).name_pat, ((Patient)d2).name_pat) > 0)
                return true;
            else return false;
        }
    }
}
