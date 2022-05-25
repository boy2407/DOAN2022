using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BusinessLayer
{
   public class DATPHONG
    {
        Entities db;
        public DATPHONG()
        {
            db = Entities.CreateEntities();
        }
        public List<tb_DatPhong>getList_StatusFalse()
        {
            return db.tb_DatPhong.Where(x=>x.STATUS==false).ToList();
        }    
        public tb_DatPhong GetItem(int iddp)
        {
            return db.tb_DatPhong.OrderByDescending(x=>x.UPDATE_BY).FirstOrDefault(x => x.IDDP == iddp);
        }
        public List<tb_DatPhong> GetAllTheoDoan()
        {
            return db.tb_DatPhong.Where(x=>x.THEODOAN==true&&x.BOOKING==false).ToList();
        }      
        public List<OBJ_DATPHONG> GetAll_RoomCheckedIn(DateTime tungay, DateTime denngay, string macty, string madvi)
        {
            var listDP = db.tb_DatPhong.Where(x => x.NGAYDAT >= tungay && x.NGAYTRA < denngay&&x.NHAN==true).ToList();
            List<OBJ_DATPHONG> lstDP = new List<OBJ_DATPHONG>();
            OBJ_DATPHONG dp;
            foreach (var item in listDP)
            {
                dp = new OBJ_DATPHONG();
                dp.IDDP = item.IDDP;
                dp.IDKH = item.IDKH;
                var kh = db.tb_KhachHang.FirstOrDefault(x => x.IDKH == item.IDKH);
                dp.HOTEN = kh.HOTEN;
                dp.NGAYDAT = item.NGAYDAT;
                dp.NGAYTRA = item.NGAYTRA;
                dp.UID = item.UID;
                dp.MACTY = item.MACTY;
                dp.MADVI = item.MADVI;
                dp.SOTIEN = item.SOTIEN;
                dp.SONGUOIO = item.SONGUOIO;
                dp.STATUS = item.STATUS;
                dp.THEODOAN = item.THEODOAN;
                dp.DISABLED = item.DISABLED;
                dp.GHICHU = item.GHICHU;
                dp.BOOKING = item.BOOKING;
                lstDP.Add(dp);
            }
            return lstDP;
        }
        public List<OBJ_DATPHONG> GetAllBooking(DateTime tungay, DateTime denngay,bool booking, string macty, string madvi)
        {
            var listDP = db.tb_DatPhong.Where(x => x.NGAYDAT >= tungay && x.NGAYTRA < denngay&&x.BOOKING==booking&&x.STATUS==false&&x.NHAN==false).ToList();
            List<OBJ_DATPHONG> lstDP = new List<OBJ_DATPHONG>();
            OBJ_DATPHONG dp;
            foreach (var item in listDP)
            {
                dp = new OBJ_DATPHONG();
                dp.IDDP = item.IDDP;
                dp.IDKH = item.IDKH;
                var kh = db.tb_KhachHang.FirstOrDefault(x => x.IDKH == item.IDKH);
                dp.HOTEN = kh.HOTEN;
                dp.NGAYDAT = item.NGAYDAT;
                dp.NGAYTRA = item.NGAYTRA;
                dp.UID = item.UID;
                dp.MACTY = item.MACTY;
                dp.MADVI = item.MADVI;
                dp.SOTIEN = item.SOTIEN;
                dp.SONGUOIO = item.SONGUOIO;
                dp.STATUS = item.STATUS;
                dp.THEODOAN = item.THEODOAN;
                dp.DISABLED = item.DISABLED;
                dp.GHICHU = item.GHICHU;
                dp.BOOKING = item.BOOKING;
                lstDP.Add(dp);
            }
            return lstDP;
        }
        public List<OBJ_DATPHONG> GetAll(DateTime tungay, DateTime denngay, string macty, string madvi)
        {
            var listDP = db.tb_DatPhong.Where(x => x.NGAYDAT >= tungay && x.NGAYTRA < denngay).ToList();
            List<OBJ_DATPHONG> lstDP = new List<OBJ_DATPHONG>();
            OBJ_DATPHONG dp;
            foreach (var item in listDP)
            {
                dp = new OBJ_DATPHONG();
                dp.IDDP = item.IDDP;
                dp.IDKH = item.IDKH;
                var kh = db.tb_KhachHang.FirstOrDefault(x => x.IDKH == item.IDKH);
                dp.HOTEN = kh.HOTEN;
                dp.NGAYDAT = item.NGAYDAT;
                dp.NGAYTRA = item.NGAYTRA;
                dp.UID = item.UID;
                dp.MACTY = item.MACTY;
                dp.MADVI = item.MADVI;
                dp.SOTIEN = item.SOTIEN;
                dp.SONGUOIO = item.SONGUOIO;
                dp.STATUS = item.STATUS;
                dp.THEODOAN = item.THEODOAN;
                dp.DISABLED = item.DISABLED;
                dp.GHICHU = item.GHICHU;
                lstDP.Add(dp);
            }
            return lstDP;
          }
        public List<OBJ_DATPHONG> GetAll_RoomCheckOut(string macty, string madvi)
        {
            var listDP = db.tb_DatPhong.Where(x => x.NGAYDAT < DateTime.Now && x.NGAYTRA <DateTime.Now&&x.STATUS==false).ToList();
            List<OBJ_DATPHONG> lstDP = new List<OBJ_DATPHONG>();
            OBJ_DATPHONG dp;
            foreach (var item in listDP)
            {
                dp = new OBJ_DATPHONG();
                dp.IDDP = item.IDDP;
                dp.IDKH = item.IDKH;
                var kh = db.tb_KhachHang.FirstOrDefault(x => x.IDKH == item.IDKH);
                dp.HOTEN = kh.HOTEN;
                dp.NGAYDAT = item.NGAYDAT;
                dp.NGAYTRA = item.NGAYTRA;
                dp.UID = item.UID;
                dp.MACTY = item.MACTY;
                dp.MADVI = item.MADVI;
                dp.SOTIEN = item.SOTIEN;
                dp.SONGUOIO = item.SONGUOIO;
                dp.STATUS = item.STATUS;
                dp.THEODOAN = item.THEODOAN;
                dp.DISABLED = item.DISABLED;
                dp.GHICHU = item.GHICHU;
                lstDP.Add(dp);
            }
            return lstDP;
        }
        public bool CheckIn(string macty, string madvi)
        {
            var listDP = db.tb_DatPhong.Where(x => x.STATUS == false && x.BOOKING == true&&x.NHAN==false).Min(x=>x.NGAYDAT);           
            if (listDP==null)
            {
                return false;
            }
            return true; 
        }
        public List<OBJ_DATPHONG>GetAllCheckIn(string macty,string madvi)
        {
            DateTime s = DateTime.Now;
            s = Convert.ToDateTime(s.ToString("dd-MM-yyyy"));
            var listDP = db.tb_DatPhong.Where(x => x.STATUS == false&&x.BOOKING==true&&x.NHAN==false).ToList();
            if(listDP==null)
            {
                return null;
            }    
            List<OBJ_DATPHONG> lstDP = new List<OBJ_DATPHONG>();
            OBJ_DATPHONG dp;
            foreach (var item in listDP)
            {
                  if(Convert.ToDateTime(item.NGAYDAT.Value.ToString("dd-MM-yyyy"))==s)
                {
                    dp = new OBJ_DATPHONG();
                    dp.IDDP = item.IDDP;
                    dp.IDKH = item.IDKH;
                    var kh = db.tb_KhachHang.FirstOrDefault(x => x.IDKH == item.IDKH);
                    dp.HOTEN = kh.HOTEN;
                    dp.NGAYDAT = item.NGAYDAT;
                    dp.NGAYTRA = item.NGAYTRA;
                    dp.UID = item.UID;
                    dp.MACTY = item.MACTY;
                    dp.MADVI = item.MADVI;
                    dp.SOTIEN = item.SOTIEN;
                    dp.SONGUOIO = item.SONGUOIO;
                    dp.STATUS = item.STATUS;
                    dp.THEODOAN = item.THEODOAN;
                    dp.DISABLED = item.DISABLED;
                    dp.GHICHU = item.GHICHU;
                    lstDP.Add(dp);
                }                                  
            }
            return lstDP;
        }
        public tb_DatPhong  add(tb_DatPhong _db)
        {
            try
            {
                db.tb_DatPhong.Add(_db);
                db.SaveChanges();
                return _db;
                
            }
            catch (Exception ex)
            {
                throw new Exception("An error encountered during data processing, please try again !" + ex.Message);
            }
        }
        public void updateStatus(int idDP)
        {
            tb_DatPhong dp = db.tb_DatPhong.FirstOrDefault(x => x.IDDP == idDP);
            dp.STATUS = true;
            try
            {
                db.SaveChanges();
                
            }
            catch (Exception ex)
            {
                throw new Exception("An error encountered during data processing, please try again !" + ex.Message);
            }
        }    
        public tb_DatPhong update(tb_DatPhong dp)
        {
            tb_DatPhong _dp = db.tb_DatPhong.FirstOrDefault(x => x.IDDP == dp.IDDP);
            _dp.IDKH = dp.IDKH;
            _dp.NGAYDAT = dp.NGAYDAT;
            _dp.NGAYTRA = dp.NGAYTRA;
            _dp.SOTIEN = dp.SOTIEN;
            _dp.SONGUOIO = dp.SONGUOIO;
            _dp.UID = dp.UID;
            _dp.MACTY = dp.MACTY;
            _dp.MADVI = dp.MADVI;
            _dp.STATUS = dp.STATUS;
            _dp.THEODOAN = dp.THEODOAN;
            _dp.GHICHU = dp.GHICHU;
            _dp.CREATED_DATE = dp.CREATED_DATE;
            _dp.UPDATE_DATE = dp.UPDATE_DATE;
            _dp.UPDATE_BY = dp.UPDATE_BY;
            _dp.DISABLED = dp.DISABLED;
            try
            {
                db.SaveChanges();
                return _dp;
            }
            catch (Exception ex)
            {
                throw new Exception("An error encountered during data processing, please try again !" + ex.Message);
            }
        }
        public void delete(int MaDatPhong)
        {
            tb_DatPhong _dp = db.tb_DatPhong.FirstOrDefault(x => x.IDDP == MaDatPhong);
            db.tb_DatPhong.Remove(_dp);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error encountered during data processing, please try again !" + ex.Message);
            }
        }
    }
}
