using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BusinessLayer
{
   public class PHONG
    {
        Entities db;
        public PHONG()
        {
            db = Entities.CreateEntities();

        }
        public List<tb_Phong>getAll()
        {
            return db.tb_Phong.ToList();
        }

        public List<tb_Phong> getAll(int idtang)
        {
            return db.tb_Phong.Where(x=>x.IDTANG== idtang).ToList();

        }
        public List<tb_Phong> getAll(int idloaiphong,int t)
        {
            return db.tb_Phong.Where(x => x.IDLOAIPHONG == idloaiphong).ToList();
        }
        public List<tb_Phong>getListPhongTrungNgayDat_byDatPhong_ct(tb_DatPhong_CT idpd_ct)
        {

            return db.tb_Phong.Where(x=>x.IDPHONG==idpd_ct.IDPHONG).ToList();
        }
        public List<OBJ_PHONG> getPhongTrong()
        {
            var lst = db.tb_Phong.Where(x => x.TRANGTHAI == false).ToList();
            List<OBJ_PHONG> listpt = new List<OBJ_PHONG>();
            OBJ_PHONG pt;
            foreach(var item in lst)
            {
                pt = new OBJ_PHONG();
                var dongia = db.tb_LoaiPhong.FirstOrDefault(x => x.IDLOAIPHONG == item.IDLOAIPHONG);
                pt.DONGIA = dongia.DONGIA;
                pt.IDLOAIPHONG = item.IDLOAIPHONG;
                pt.IDPHONG = item.IDPHONG;
                pt.IDTANG = item.IDTANG;
              
                pt.TENPHONG = item.TENPHONG;
                
                pt.TRANGTHAI = item.TRANGTHAI;
                listpt.Add(pt);
            }
            return listpt;
        }
        public List<OBJ_PHONG> getPhongCheckOut(string macty, string madvi)
        {
            DATPHONG dp = new DATPHONG();

            var lstdp = dp.GetAllCheckOut(macty, madvi);
            List<tb_DatPhong_CT> lstdpct = new List<tb_DatPhong_CT>();
            foreach (var item in lstdp)
            {
                var i = db.tb_DatPhong_CT.Where(x => x.IDDP == item.IDDP).ToList();
                lstdpct.AddRange(i);
            }

        
            List<tb_Phong> lstphong = new List<tb_Phong>();
            foreach(var item in lstdpct)
            {
                var i = db.tb_Phong.FirstOrDefault(x => x.TRANGTHAI == true&&x.IDPHONG==item.IDPHONG);
                lstphong.Add(i);
            }    
            List<OBJ_PHONG> listpt = new List<OBJ_PHONG>();
            OBJ_PHONG pt;
            foreach (var item in lstphong)
            {
                pt = new OBJ_PHONG();
                var dongia = db.tb_LoaiPhong.FirstOrDefault(x => x.IDLOAIPHONG == item.IDLOAIPHONG);
                pt.DONGIA = dongia.DONGIA;
                pt.IDLOAIPHONG = item.IDLOAIPHONG;
                pt.IDPHONG = item.IDPHONG;
                pt.IDTANG = item.IDTANG;
                var t = db.tb_Tang.FirstOrDefault(x => x.IDTANG==item.IDTANG);
                pt.TENTANG = t.TENTANG;
                pt.TENPHONG = item.TENPHONG;              
                pt.TRANGTHAI = item.TRANGTHAI;
                listpt.Add(pt);
            }
            return listpt;
        }
        public  OBJ_PHONG getItemFull(int _idphong)
        {
            var list = db.tb_Phong.Where(x => x.IDPHONG == _idphong).ToList();
            List<OBJ_PHONG> listPHONG = new List<OBJ_PHONG>();
            OBJ_PHONG p = new OBJ_PHONG();

            foreach(var item in list)
            {
                p.IDPHONG = item.IDPHONG;
                p.IDTANG = item.IDTANG;
                p.IDLOAIPHONG = item.IDLOAIPHONG;
                var dongia = db.tb_LoaiPhong.FirstOrDefault(x => x.IDLOAIPHONG == item.IDLOAIPHONG);

                p.DONGIA =dongia.DONGIA ;
               
                p.TENPHONG = item.TENPHONG;
               
                listPHONG.Add(p);
            }
            return p;

        }
        public tb_Phong getItem(int idp)
        {
            return db.tb_Phong.FirstOrDefault(x=>x.IDPHONG==idp);
        }
        public List<tb_Phong> getByTang(int idphong)
        {
            return db.tb_Phong.Where(x => x.IDTANG == idphong).ToList();
        }
        public void add(tb_Phong p)
        {
            try
            {
                db.tb_Phong.Add(p);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xữ lý dữ liệu" + ex.Message);
            }
        }
        public void update(tb_Phong p)
        {
            tb_Phong _p = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == p.IDPHONG);
            _p.TENPHONG = p.TENPHONG;
            _p.IDLOAIPHONG = p.IDLOAIPHONG;
            _p.IDTANG = p.IDTANG;
            _p.TRANGTHAI = p.TRANGTHAI;
            try
            {

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xữ lý dữ liệu" + ex.Message);
            }
        }
        public void delete(int idphong)
        {
            tb_Phong _p = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == idphong);
            db.tb_Phong.Remove(_p);
            try
            {

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xữ lý dữ liệu" + ex.Message);
            }
        }
        public void updateStatus(int IDphong,bool status)
        {
            tb_Phong _p = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == IDphong);
                _p.TRANGTHAI = status;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xữ lý dữ liệu" + ex.Message);
            }
        }
        public void updateStatusBy_IDDP(int iddp, bool status)
        {
            DATPHONG_CT ct = new DATPHONG_CT();
            PHONG phong = new PHONG();
            List<tb_DatPhong_CT> lst_dpct = ct.getAll(iddp);
            foreach(var p in lst_dpct)
            {
                phong.updateStatus(p.IDPHONG, status);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xữ lý dữ liệu" + ex.Message);
            }
        }
        public bool checkEmpty(int idPhong)
        {
            var p = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == idPhong);
            if (p.TRANGTHAI == true)
                return true;
            else
                return false;
        }
    }
}
