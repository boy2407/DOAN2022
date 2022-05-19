using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;
namespace BusinessLayer
{
   public class OBJ_DP_CT : OBJ_DATPHONGCHITIET
    {
        public string TENPHONG { get; set; }
        public int SONGUOI { get; set; }
        public int IDTANG { get; set; }
        public string TENTANG { get; set; }
    }

}
