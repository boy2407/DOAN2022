using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BusinessLayer
{
  public  class PHONG_THIETBI
    {
        Entities db;
        public PHONG_THIETBI ()
        {
            db = Entities.CreateEntities();
        }
        public List<OBJ_PHONG_THIETBI> getALLByIDPHONG(int idphong)
        {
            ///phải chấm Tolist() ,không thì mồ mất thời gian 
            var l = db.tb_Phong_ThietBi.Where(x => x.IDPHONG == idphong).ToList();

            List<OBJ_PHONG_THIETBI> lst = new List<OBJ_PHONG_THIETBI>();
            foreach (var item in l)
            {
                OBJ_PHONG_THIETBI p = new OBJ_PHONG_THIETBI();
                p.IDPHONG = item.IDPHONG;
                p.IDTB = item.IDTB;
                p.SOLUONG = item.SOLUONG;
                var tp = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == item.IDPHONG);
                p.TENPHONG = tp.TENPHONG;
                tb_ThietBi ttb = db.tb_ThietBi.FirstOrDefault(x => x.IDTB == item.IDTB);
                p.TENTB = ttb.TENTB;
                p.TONGSLN = ttb.TONGSLN;
                p.TONGSLX = ttb.TONGSLX;
                lst.Add(p);
            }
            return lst;
        }
        
        public tb_Phong_ThietBi getItem(int idphong,int idtb)
        {
            return db.tb_Phong_ThietBi.FirstOrDefault(x => x.IDPHONG == idphong&&x.IDTB==idtb);
        }
     
        public void add(tb_Phong_ThietBi tb)
        {
            try
            {
                db.tb_Phong_ThietBi.Add(tb);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
        public void update(tb_Phong_ThietBi tb)
        {
            tb_Phong_ThietBi _tb = db.tb_Phong_ThietBi.FirstOrDefault(x => x.IDTB == tb.IDTB&&tb.IDPHONG==x.IDPHONG);
            _tb.SOLUONG = tb.SOLUONG;
            try
            {

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
        public void delete(int idphong , int idtb)
        {
            tb_Phong_ThietBi _tb = db.tb_Phong_ThietBi.FirstOrDefault(x => x.IDTB == idtb&&x.IDPHONG==idphong);
            db.tb_Phong_ThietBi.Remove(_tb);
            try
            {

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
    }
}
