using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BusinessLayer
{
    public class SYS_RIGHT_REP
    {
        Entities db;
        public SYS_RIGHT_REP()
        {
            db = Entities.CreateEntities();
        }
        public List<tb_SYS_RIGHT_REP> getListByUser(int idUser)
        {
            SYS_GROUP sGROUP = new SYS_GROUP();
            var group = sGROUP.GetGroupByMenBer(idUser);
            if (group == null)
                return db.tb_SYS_RIGHT_REP.Where(x => x.IDUSER == idUser && x.USER_RIGHT == true).ToList();
            else//lấy theo group 
            {
                List<tb_SYS_RIGHT_REP> lstByGroup = db.tb_SYS_RIGHT_REP.Where(x => x.IDUSER == group.GROUP && x.USER_RIGHT == true).ToList();
                List<tb_SYS_RIGHT_REP> lstByUser = db.tb_SYS_RIGHT_REP.Where(x => x.IDUSER == idUser && x.USER_RIGHT == true).ToList();
                List<tb_SYS_RIGHT_REP> lstAll = lstByUser.Concat(lstByGroup).ToList();
                return lstAll;
            }
        }
        public void update(int idUser, int rep_code, bool right)
        {
            tb_SYS_RIGHT_REP sRight = db.tb_SYS_RIGHT_REP.FirstOrDefault(x => x.IDUSER == idUser && x.REP_CODE == rep_code);
            try
            {
                sRight.USER_RIGHT = right;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("lỗi" + ex.Message);
            }
        }
        public bool check(tb_SYS_USER us)
        {
            var rep = db.tb_SYS_RIGHT_REP.Where(x => x.IDUSER == us.IDUSER);
            foreach (var i in rep)
            {
                if (i.USER_RIGHT == true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
