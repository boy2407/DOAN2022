using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BusinessLayer;
namespace BusinessLayer
{
   public class KYPHONG
    {
        Entities db;
        public KYPHONG()
        {
             db = Entities.CreateEntities();
        }
        public List<tb_KyPhong>getlist( string macty, string madv)
        {
            return db.tb_KyPhong.Where(x =>x.MACTY == macty && x.MADV == madv).ToList();
        }
        public tb_KyPhong getItem(int maky,string macty, string madv)
        {
            return db.tb_KyPhong.FirstOrDefault(x => x.MAKY==maky&&x.MACTY==macty&&x.MADV==madv);
        }
        public bool checkUserExist(int maky, string macty, string madv)
        {
            var us = db.tb_KyPhong.FirstOrDefault(x => x.MAKY == maky && x.MACTY == macty && x.MADV == madv);
            if (us != null)
            {
                return true;
            }
            else return false;
        }
        public void add(tb_KyPhong ky)
        {

            try
            {
                db.tb_KyPhong.Add(ky);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
     
        public void update(tb_KyPhong ky)
        {
            tb_KyPhong _ky = db.tb_KyPhong.FirstOrDefault(x => x.MAKY == ky.MAKY&&ky.MADV==x.MADV&&x.MACTY==ky.MACTY);            
            _ky.SONGAY = ky.SONGAY;
            _ky.NGAY = ky.NGAY;
            _ky.NAM = ky.NAM;
            _ky.THANG = ky.THANG;
           
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
        public void delete(int maky, string macty, string madv)
        {
            tb_KyPhong ky = db.tb_KyPhong.FirstOrDefault(x => x.MAKY == maky && x.MACTY == macty && x.MADV == madv);
            
            try
            {
                db.tb_KyPhong.Remove(ky);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
            }
        }
    }
}
