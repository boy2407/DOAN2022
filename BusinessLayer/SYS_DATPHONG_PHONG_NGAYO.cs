using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BusinessLayer
{
  public class SYS_DATPHONG_PHONG_NGAYO
    {
        Entities db;
        public SYS_DATPHONG_PHONG_NGAYO()
        {
            db = Entities.CreateEntities();
        }
        public List<tb_DatPhong_Phong_NgayO> getAll()
        {
            return db.tb_DatPhong_Phong_NgayO.ToList();
        }
        public void add(tb_DatPhong_Phong_NgayO dcn)
        {            
            try
            {
                db.tb_DatPhong_Phong_NgayO.Add(dcn);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }     
        public void update(tb_DatPhong_Phong_NgayO dcn)
        {
            tb_DatPhong_Phong_NgayO _dcn = db.tb_DatPhong_Phong_NgayO.FirstOrDefault(x => x.IDDP == dcn.IDDP);

            _dcn.NGAYO = dcn.NGAYO;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
        public void delete(int iddpc)
        {
            tb_DatPhong_Phong_NgayO dcn = db.tb_DatPhong_Phong_NgayO.FirstOrDefault(x => x.IDDP == iddpc);
            
            try
            {
                db.tb_DatPhong_Phong_NgayO.Remove(dcn);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }

    }
}
