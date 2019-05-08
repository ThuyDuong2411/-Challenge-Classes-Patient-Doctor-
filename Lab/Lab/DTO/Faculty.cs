using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Faculty
    {
        public int id_fac { get; set; }
        public string name_fac { get; set; }
        public static bool CompareIDFac(Object d1, Object d2)
        {
            if (((Faculty)d1).id_fac > ((Faculty)d2).id_fac)
                return true;
            else return false;
        }
        public static bool CompareNameFac(Object d1, Object d2)
        {
            if (string.Compare(((Faculty)d1).name_fac, ((Faculty)d2).name_fac) > 0)
                return true;
            else return false;
        }
    }
}
