using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public class OBJ_DATPHONG
    {
        public int IDDP { get; set; }
        public int IDKH { get; set; }
        public string HOTEN { get; set; }
        public DateTime? NGAYDAT { get; set; }
        public DateTime? NGAYTRA { get; set; }
        public double? SOTIEN { get; set; }
        public int? SONGUOIO { get; set; }
        public int UID { get; set; }
        public string MACTY { get; set; }
        public string MADVI { get; set; }
        public bool? STATUS { get; set; }
        public bool? THEODOAN { get; set; }
        public string GHICHU { get; set; }
        public bool? DISABLED { get; set; }
        public bool ?BOOKING { get; set; }
    }
}
