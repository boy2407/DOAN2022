using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public class OBJ_DATPHONGCHITIET
    {
        public int IDDPCT { get; set; }
        public int ?IDDP { get; set; }
        public int IDPHONG { get; set; }
        public int ?SONGAYO { get; set; }
        public double ?THANHTIEN { get; set; }
        public DateTime? NGAY { get; set; }
        public double ?DONGIA { get; set; }
    }
}
