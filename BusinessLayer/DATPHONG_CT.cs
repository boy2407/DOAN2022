using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BusinessLayer
{
   public class DATPHONG_CT
    {
        Entities db;
        public DATPHONG_CT()
        {
            db = Entities.CreateEntities();
        }
        public List<tb_DatPhong_CT> getLisTrungNgayDat_ByDatPhong(int iddp)
        {
            return db.tb_DatPhong_CT.Where(x => x.IDDP == iddp).ToList();
        }
        public List<tb_DatPhong_CT>getAll()
        {
            return db.tb_DatPhong_CT.ToList();
        }
        public List<tb_DatPhong_CT> getAll(int iddp)
        {
            return db.tb_DatPhong_CT.Where(x=>x.IDDP==iddp).ToList();
        }
        public tb_DatPhong_CT getItem(int idDPCT)
        {
            return db.tb_DatPhong_CT.FirstOrDefault(x => x.IDDP == idDPCT);
        }
        public tb_DatPhong_CT getItem(int idDP,int idPhong)
        {
            return db.tb_DatPhong_CT.FirstOrDefault(x => x.IDDP == idDP && x.IDPHONG==idPhong);
        }
        public tb_DatPhong_CT add(tb_DatPhong_CT dpct)
        {
            try
            {
                db.tb_DatPhong_CT.Add(dpct);
                db.SaveChanges();
                return dpct;
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu"+ex.Message);
            }  
        }
        public tb_DatPhong_CT getIDDPByPhong(int idPhong)
        {
            return db.tb_DatPhong_CT.OrderByDescending(x => x.NGAY).FirstOrDefault(x=>x.IDPHONG==idPhong);
        }
        public double SumByIddp(int iddp)
        {
            List<tb_DatPhong_CT> lst = db.tb_DatPhong_CT.Where(x => x.IDDP == iddp).ToList();
            double result = 0;
            if(lst!=null)
            {
                foreach (var i in lst)
                {
                    result += i.THANHTIEN.Value;
                }
            }    
            
            return result;
        }
        public void update(tb_DatPhong_CT dpct)
        {
            tb_DatPhong_CT _dpct = db.tb_DatPhong_CT.FirstOrDefault(x => x.IDDPCT == dpct.IDDPCT);
            _dpct.IDDP = dpct.IDDP;
            _dpct.IDPHONG = dpct.IDPHONG;
            _dpct.NGAY = dpct.NGAY;
            _dpct.IDDPCT = dpct.IDDPCT;
            _dpct.SONGAYO = dpct.SONGAYO;
            _dpct.THANHTIEN = dpct.THANHTIEN;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }

        }
        public void delete(int _iddp,int _idphong)
        {
            tb_DatPhong_CT _dpct = db.tb_DatPhong_CT.FirstOrDefault(x => x.IDDP==_iddp && x.IDPHONG== _idphong);
            db.tb_DatPhong_CT.Remove(_dpct);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
        public void deleteAll(int idDP)
        {
            List<tb_DatPhong_CT> lstSP = db.tb_DatPhong_CT.Where(x => x.IDDP == idDP).ToList();
            foreach(var item in lstSP)
            {
                var phong = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == item.IDPHONG);
                //phong.TRANGTHAI = false;
            }    
            try
            {
                db.tb_DatPhong_CT.RemoveRange(lstSP);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);

            }
        }
        public List<OBJ_DATPHONGCHITIET>  getAllByDatPhong(int _iddp)
        {
            var listget = db.tb_DatPhong_CT.Where(x => x.IDDP==_iddp);
            List<OBJ_DATPHONGCHITIET> listDPCT = new List<OBJ_DATPHONGCHITIET>();
            OBJ_DATPHONGCHITIET DPCT;
            foreach(var item in listget)
            {
                DPCT = new OBJ_DATPHONGCHITIET();
                DPCT.IDDP = item.IDDP;
                DPCT.IDDPCT = item.IDDPCT;
                DPCT.IDPHONG = item.IDPHONG;
                DPCT.NGAY = item.NGAY;
                DPCT.THANHTIEN = item.THANHTIEN;
                DPCT.SONGAYO = item.SONGAYO;
                DPCT.DONGIA = item.DONGIA;
                listDPCT.Add(DPCT);
            }
            return listDPCT;
        }
        public List<OBJ_DP_CT> getAllDPCT(int _iddp)
        {
            PHONG p = new PHONG();
            TANG t = new TANG();
            LOAIPHONG lp = new LOAIPHONG();
            var listget = db.tb_DatPhong_CT.Where(x => x.IDDP == _iddp);
            //var listget = db.tb_DatPhong_CT.Select(c => new { c.IDDP, c.IDPHONG, c.SONGAYO, c.THANHTIEN, c.IDDPCT, c.DONGIA }).Where(x=>x.IDDP==_iddp).Distinct();
            List<OBJ_DP_CT> listDPCT = new List<OBJ_DP_CT>();
            OBJ_DP_CT DPCT;
            foreach (var item in listget)
            {
                DPCT = new OBJ_DP_CT();
                DPCT.IDDP = item.IDDP;
                DPCT.IDDPCT = item.IDDPCT;
                tb_Phong phong = p.getItem(item.IDPHONG);
                DPCT.TENPHONG = phong.TENPHONG;
                DPCT.IDTANG = phong.IDTANG;
                tb_Tang tang = t.getItem(phong.IDTANG);
                DPCT.TENTANG = tang.TENTANG;
                DPCT.SONGUOI = (int)lp.getItem(phong.IDLOAIPHONG).SONGUOI;
                DPCT.IDPHONG = item.IDPHONG;              
                DPCT.THANHTIEN = item.THANHTIEN;
                DPCT.SONGAYO = item.SONGAYO;
                DPCT.DONGIA = item.DONGIA;
                listDPCT.Add(DPCT);
            }
            return listDPCT;
        }
       
    }
}
