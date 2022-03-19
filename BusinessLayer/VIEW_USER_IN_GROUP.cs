using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BusinessLayer;
namespace BusinessLayer
{
  public  class VIEW_USER_IN_GROUP
    {
        Entities db;
        public VIEW_USER_IN_GROUP()
        {
            db = Entities.CreateEntities();
        }
        public List<tb_SYS_USER> getGroupByUser(string macty,string madvi,int iduser)
        {
            List<tb_SYS_USER> lstGroup = new List<tb_SYS_USER>();

            List<V_USER_INGROUP> lst = db.V_USER_INGROUP.Where(x => x.MENBER == iduser&&x.MACTY==macty&&x.MADVI==madvi).ToList();
            tb_SYS_USER gr;
            foreach(var item in lst)
            {
                gr = new tb_SYS_USER();
                gr = db.tb_SYS_USER.FirstOrDefault(x => x.IDUSER == item.GROUP);             
                lstGroup.Add(gr);
                
            }
            return lstGroup;

        }
        public List<tb_SYS_USER> getGroupByDonVi(string macty, string madvi,int iduser)
        {
            List<tb_SYS_USER> allgroup = db.tb_SYS_USER.Where(x => x.ISGROUP == true && x.DISABLED == false && x.MACTY == macty && x.MADVI == madvi).ToList();
            
            List<tb_SYS_USER> lstgr = new List<tb_SYS_USER>();
            tb_SYS_USER gr;
            foreach (var i in allgroup)
            {
                if (!CheckGroupByUser(iduser,i.IDUSER))
                {
                    gr=new tb_SYS_USER();
                    gr = db.tb_SYS_USER.FirstOrDefault(x => x.IDUSER == i.IDUSER);
                    lstgr.Add(gr);
                }    
            }



            //  return db.tb_SYS_USER.Where(x => x.MACTY == macty && x.MADVI == madvi).ToList();
            return lstgr;

        }
        public List<tb_SYS_USER> getUserNotInGroup(string macty, string madvi, int idGroup)
        {
            List<tb_SYS_USER> allUser = db.tb_SYS_USER.Where(x => x.ISGROUP == false && x.DISABLED == false && x.MACTY == macty && x.MADVI == madvi).ToList();
          
            List<tb_SYS_USER> lstgr = new List<tb_SYS_USER>();
            tb_SYS_USER gr;
            foreach (var i in allUser)
            {
                if (!CheckGroupByUser(i.IDUSER, idGroup))
                {
                    gr = new tb_SYS_USER();
                    gr = db.tb_SYS_USER.FirstOrDefault(x => x.IDUSER == i.IDUSER);
                    lstgr.Add(gr);
                }
            }



            //  return db.tb_SYS_USER.Where(x => x.MACTY == macty && x.MADVI == madvi).ToList();
            return lstgr;

        }
        public bool CheckGroupByUser(int idUser , int idgroup)
        {
            var gr = db.tb_SYS_GROUP.FirstOrDefault(x => x.GROUP == idgroup && x.MENBER == idUser);
            if (gr == null)
                return false;

            return true;

        }
        public List<V_USER_INGROUP>getUserInGroup(string macty,string madvi,int idgroup)
        {
            return db.V_USER_INGROUP.Where(x => x.MADVI == madvi && x.MACTY == macty&&x.DISABLED==false&&x.ISGROUP==false&&x.GROUP==idgroup).ToList();
        }
    }

}
