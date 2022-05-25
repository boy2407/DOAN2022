using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BusinessLayer
{
   public class DATPHONG_SP
    {
        Entities db;
        public DATPHONG_SP()
        {
            db = Entities.CreateEntities();
        }
        public List<OBJ_DPSP> getAllByDatPhong(int idDP)
        {
            var lst = db.tb_DatPhong_SP.Where(x => x.IDDP == idDP).ToList();
            List<OBJ_DPSP> lstDPSP = new List<OBJ_DPSP>();
            OBJ_DPSP sp;
            foreach(var item in lst)
            {
                sp = new OBJ_DPSP();
                sp.IDDP = item.IDDP;
                sp.IDDPSP = item.IDDPSP;
                sp.IDPHONG = item.IDPHONG;
                var p = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == item.IDPHONG);
                sp.TENPHONG = p.TENPHONG;
                sp.IDSP = item.IDSP;
                var s = db.tb_SanPham.FirstOrDefault(x => x.IDSP == item.IDSP);
                sp.TENSP = s.TENSP;
                sp.SOLUONG = item.SOLUONG;
                sp.DONGIA = item.DONGIA;
                sp.THANHTIEN = item.THANHTIEN;
                lstDPSP.Add(sp);
            }
            return lstDPSP;  
        }
        public tb_DatPhong_SP getItem(int iddpsp)
        {
            return db.tb_DatPhong_SP.FirstOrDefault(x => x.IDDPSP == iddpsp);
        }
        public tb_DatPhong_SP getItem(int iddp,int idpphong)
        {
            return db.tb_DatPhong_SP.FirstOrDefault(x => x.IDDP == iddp && x.IDPHONG==idpphong);
        }
        public double SumByIddp_Iddp_ct(int iddp,int iddp_ct)
        {
            List<tb_DatPhong_SP> lst = db.tb_DatPhong_SP.Where(x => x.IDDP == iddp&&x.IDDPCT==iddp_ct).ToList();
            double result = 0;
            if (lst != null)
            {
                foreach (var i in lst)
                {
                    result += i.THANHTIEN.Value;
                }
            }

            return result;
        }
        public List<tb_DatPhong_SP> getAllByPhong(int idDP,int idDPCT)
        {
            return  db.tb_DatPhong_SP.Where(x => x.IDDP == idDP && x.IDDPCT==idDPCT).ToList();          
        }
        
        public void add(tb_DatPhong_SP dpsp)
        {
            try
            {
                db.tb_DatPhong_SP.Add(dpsp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
        public void update(tb_DatPhong_SP dpsp)
        {
            tb_DatPhong_SP sp = db.tb_DatPhong_SP.FirstOrDefault(x => x.IDDPSP == dpsp.IDDPSP);
            sp.IDDP = dpsp.IDDP;
            sp.IDPHONG = dpsp.IDPHONG;
            sp.SOLUONG = dpsp.SOLUONG;
            sp.NGAY = dpsp.NGAY;
            sp.DONGIA = dpsp.DONGIA;
            sp.THANHTIEN = dpsp.THANHTIEN;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex )
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
        public void deleteAll(int idDP)
        {
            List<tb_DatPhong_SP> lstSP = db.tb_DatPhong_SP.Where(x => x.IDDP == idDP).ToList();
            try
            {
                db.tb_DatPhong_SP.RemoveRange(lstSP);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);

            }
        }
        public void deletAllByPhong(int _idDP,int _idphong)
        {
            List<tb_DatPhong_SP> lstSP = db.tb_DatPhong_SP.Where(x => x.IDDP == _idDP&&x.IDPHONG==_idphong).ToList();
            try
            {
                db.tb_DatPhong_SP.RemoveRange(lstSP);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);

            }
        }
        public void deletAllByDatPhong_CT(int idDP, int _iddp_ct)
        {
            List<tb_DatPhong_SP> lstSP = db.tb_DatPhong_SP.Where(x => x.IDDPCT == _iddp_ct && x.IDDP == idDP).ToList();
            try
            {
                db.tb_DatPhong_SP.RemoveRange(lstSP);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);

            }
        }
    }
}
