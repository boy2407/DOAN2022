using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   

   public class TANG
    {
        Entities db;
        public TANG ()
        {
            db = Entities.CreateEntities();
        }
 
        public List<tb_Tang> getALL(string macty,string madvi)
        {
            return db.tb_Tang.Where(x=>x.MACTY==macty&&madvi==x.MADVI).ToList();
        }
        public tb_Tang getItem(int idtang)
        {
            return db.tb_Tang.FirstOrDefault(x => x.IDTANG == idtang);
        }
        public void add(tb_Tang tang)
        {
            try
            {
                db.tb_Tang.Add(tang);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xữ lý dữ liệu" + ex.Message);
            }
        }
        public void update(tb_Tang tang)
        {
            tb_Tang _tang = db.tb_Tang.FirstOrDefault(x =>x.IDTANG== tang.IDTANG );
            _tang.TENTANG = tang.TENTANG;
            try
            {

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Có lỗi xảy ra trong quá trình xữ lý dữ liệu" + ex.Message);
            }
        }
        public void delete(int idtang)
        {

            tb_Tang _tang = db.tb_Tang.FirstOrDefault(x => x.IDTANG == idtang);
            List<tb_Phong> lsp = db.tb_Phong.Where(x => x.IDTANG == idtang).ToList();
            if(lsp!=null)
            {
                db.tb_Phong.RemoveRange(lsp);
            }    
            db.tb_Tang.Remove(_tang);
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
