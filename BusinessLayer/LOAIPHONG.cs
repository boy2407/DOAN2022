using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BusinessLayer
{
    public class LOAIPHONG
    {
        Entities db;
        public LOAIPHONG()
        {
            db = Entities.CreateEntities();

        }
        public List<tb_LoaiPhong> getAll(string macty, string madvi)
        {
            return db.tb_LoaiPhong.Where(x=>x.MACTY==macty&&x.MADVI==madvi).ToList();
        }
       public tb_LoaiPhong getItem(int idlp)
        {
            return db.tb_LoaiPhong.FirstOrDefault(x=>x.IDLOAIPHONG==idlp);
        }
        public void add(tb_LoaiPhong lp)
        {
            try
            {
                db.tb_LoaiPhong.Add(lp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xữ lý dữ liệu" + ex.Message);
            }
        }
        public void update(tb_LoaiPhong lp)
        {
            tb_LoaiPhong _lp = db.tb_LoaiPhong.FirstOrDefault(x => x.IDLOAIPHONG == lp.IDLOAIPHONG);
            _lp.DONGIA = lp.DONGIA;
            _lp.SOGIUONG = lp.SOGIUONG;
            _lp.TENLOAIPHONG = lp.TENLOAIPHONG;
            _lp.SONGUOI = lp.SONGUOI;
            try
            {

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xữ lý dữ liệu" + ex.Message);
            }
        }
        public void delete(int idlp)
        {
            tb_LoaiPhong _lp = db.tb_LoaiPhong.FirstOrDefault(x => x.IDLOAIPHONG == idlp);
            db.tb_LoaiPhong.Remove(_lp);
            try
            {

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xữ lý dữ liệu" + ex.Message);
            }
        }
        public int getId()
        {
            return db.tb_LoaiPhong.Max(x => x.IDLOAIPHONG);
        }
    }
}
