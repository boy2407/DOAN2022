using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BusinessLayer;
namespace BusinessLayer
{
    public class VIEW_USER_NOTIN_GROUP
    {
        Entities db;
        public VIEW_USER_NOTIN_GROUP()
        {
            db = Entities.CreateEntities();
        }
        public bool CheckGroupByUser(int idUser, int idgroup)
        {
            var gr = db.tb_SYS_GROUP.FirstOrDefault(x => x.GROUP == idgroup && x.MENBER == idUser);
            if (gr == null)
                return false;

            return true;

        }
        public List<V_USER_NOTIN_GROUP>getUserNoinGroup(string macty,string madvi,int idgroup)
        {
            
            return db.V_USER_NOTIN_GROUP.Where(x => x.MACTY == macty && x.MADVI == madvi&&x.ISGROUP==false&&x.DISABLED==false).ToList();
        }

    }
}
