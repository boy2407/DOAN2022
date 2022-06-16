using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BusinessLayer
{
   public class SANPHAM
    {
        Entities db;
        public SANPHAM()
        {
            db = Entities.CreateEntities();

        }
        public List<tb_SanPham>getAll(string macty,string madvi)
        {
            return db.tb_SanPham.Where(x=>x.MACTY==macty&&x.MADVI==madvi).ToList();
        }
        public tb_SanPham getItem(int idsp )
        {
            return db.tb_SanPham.FirstOrDefault(x =>x.IDSP==idsp);            
        }
        public void add(tb_SanPham sp)
        {
            try
            {
                db.tb_SanPham.Add(sp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xữ lý dữ liệu"+ex.Message);
            }
        }
         public void update(tb_SanPham sp)
        {
            tb_SanPham _sp = db.tb_SanPham.FirstOrDefault(x => x.IDSP == sp.IDSP);
            _sp.TENSP = sp.TENSP;
            _sp.DONGIA = sp.DONGIA;
            try
            {
               
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xữ lý dữ liệu" + ex.Message);
            }
        }
        public void delete(int idsp)
        {
            tb_SanPham _sp = db.tb_SanPham.FirstOrDefault(x => x.IDSP == idsp);
            db.tb_SanPham.Remove(_sp);
            try
            {

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xữ lý dữ liệu" + ex.Message);
            }
        }

    }
}
