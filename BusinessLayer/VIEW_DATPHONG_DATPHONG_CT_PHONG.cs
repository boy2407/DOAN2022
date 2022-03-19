using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BusinessLayer;
namespace BusinessLayer
{
    public  class VIEW_DATPHONG_DATPHONG_CT_PHONG
    {
        Entities db;
        public VIEW_DATPHONG_DATPHONG_CT_PHONG()
        {
            db = Entities.CreateEntities();
        }
        public v_DATPHONG_DATPHONG_CT_PHONG getItemByIdPhong_Iddp(int idphong)/// kiểm tra có phải là đoàn không phải lấy iddp để tham chiếu
        {
            return db.v_DATPHONG_DATPHONG_CT_PHONG.FirstOrDefault(x => x.IDPHONG == idphong && x.STATUS == false&&x.THEODOAN==true);
        }
    }
}
