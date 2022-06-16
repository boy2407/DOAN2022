using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BusinessLayer;
namespace BusinessLayer
{
   public class ROOM_BOOKING_DETAILS
    {
        Entities_web db;       
        public ROOM_BOOKING_DETAILS()
        {
            db = Entities_web.CreateEntities();
        }
        public List<room_booking_details> getAll_Receive()
        {
            return db.room_booking_details.Where(x=>x.received==0).ToList();
        }       
    }
}
