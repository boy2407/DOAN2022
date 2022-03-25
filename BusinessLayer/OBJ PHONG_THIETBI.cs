using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
     public class OBJ_PHONG_THIETBI
    {
        public int IDPHONG { get; set; }
        public int IDTB { get; set; }
        public int ?SOLUONG { get; set; }
        public string  TENTB { get; set; }
        public  string TENPHONG { get; set; }
        public int ?TONGSLN { get; set; }
        public int ?TONGSLX { get; set; }
    }
}
