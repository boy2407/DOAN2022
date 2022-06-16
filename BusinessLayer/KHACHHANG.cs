using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BusinessLayer
{
   public class KHACHHANG
    {
        Entities db;
        public KHACHHANG()
        {
            db = Entities.CreateEntities();

        }
        public List<tb_KhachHang>getAll()
        {
            return db.tb_KhachHang.ToList();
        }
        public bool checkCCCD(string cccd)
        {
            var lst = db.tb_KhachHang.ToList();
            foreach(var i in lst)
            {
                if (i.CCCD == cccd)
                    return true;
            }
            return false;
        }
        public bool checkSTD(string dt)
        {
            var lst = db.tb_KhachHang.ToList();
            foreach (var i in lst)
            {
                if (i.DIENTHOAI == dt)
                    return true;
            }
            return false;
        }
        public List<tb_KhachHang> getAll(bool dis)
        {
            return db.tb_KhachHang.Where(x=>x.DISABLED==dis).ToList();
        }
        public tb_KhachHang getItem(int idkh)
        {
            return db.tb_KhachHang.FirstOrDefault(x => x.IDKH == idkh);
        }
        public void add(tb_KhachHang kh)
        {

            try
            {
                db.tb_KhachHang.Add(kh);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            };

        }
        public void update(tb_KhachHang kh)
        {
            tb_KhachHang _kh = db.tb_KhachHang.FirstOrDefault(x=>x.IDKH== kh.IDKH);

            _kh.DIACHI = kh.DIACHI;
            _kh.CCCD = kh.CCCD;
            _kh.DIENTHOAI = kh.DIENTHOAI;
            _kh.EMAIL = kh.EMAIL;
            _kh.HOTEN = kh.HOTEN;
            _kh.GIOITINH = kh.GIOITINH;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new   Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
        public void delete(int IDKH)
        {
            tb_KhachHang kh = db.tb_KhachHang.FirstOrDefault(x => x.IDKH == IDKH);
            
            try
            {
                db.tb_KhachHang.Remove(kh);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
    }
}
