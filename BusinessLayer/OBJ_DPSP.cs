using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public class OBJ_DPSP
    {
        public int IDDPSP { set; get; }
        public int? IDSP { set; get; }
        public  string TENSP { set; get; }
        public int ?SOLUONG { get; set; }
        public double ?DONGIA { get; set; }
        public double? THANHTIEN { get; set; }
        public int ?IDPHONG { get; set; }
        public string  TENPHONG { get; set; }
        public int IDDP { get; set; }
    }
}
