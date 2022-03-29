using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BusinessLayer
{
    public class APPOINTMENTS
    {
        Entities db;
        public APPOINTMENTS()
        {
            db = Entities.CreateEntities();
        }
        public List<Appointment> getAll()
        {
            return db.Appointments.ToList();
        }
        public  void update()
        {
            db.SaveChanges();
        }
     
    }
}
