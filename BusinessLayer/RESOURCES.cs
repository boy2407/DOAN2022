using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BusinessLayer
{
    public   class RESOURCES
    {
        Entities db;
        public RESOURCES()
        {
            db = Entities.CreateEntities();
        }    

        public List<Resource> getAll()
        {
            return db.Resources.ToList();
        }
        public void update()
        {
            db.SaveChanges();
        }
    }
}
