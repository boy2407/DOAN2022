using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BusinessLayer
{
    public class SYS_FUNC
    {
        Entities db;

        public SYS_FUNC()
        {
            db = Entities.CreateEntities();
        }
        public List<tb_SYS_Func>getParent()
        {
            return db.tb_SYS_Func.Where(x => x.ISGROUP == true && x.MENU == true).OrderBy(s => s.SORT).ToList();
        }
        public List<tb_SYS_Func> getChild(string parent)
        {
            return db.tb_SYS_Func.Where(x => x.ISGROUP == false && x.MENU == true && x.PARENT == parent).OrderBy(s => s.SORT).ToList();
        }

    }
}
