using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class VIEW_PHONGBYNGAY
    {
        Entities db;
        public VIEW_PHONGBYNGAY()
        {
            db = Entities.CreateEntities();
        }
        public List<V_PHONGBYNGAY> getAll()
        {
            return db.V_PHONGBYNGAY.ToList();

        }
        public List<V_PHONGBYNGAY> getlistItem(int idphong)
        {
            return db.V_PHONGBYNGAY.Where(x=>x.IDPHONG==idphong).ToList();
        }
        public List<V_PHONGBYNGAY> getlistPhongKhongTrungDateTime(DateTime ngaydat)
        {
            DATPHONG dp = new DATPHONG();
            DATPHONG_CT dp_ct = new DATPHONG_CT();
            PHONG phong = new PHONG();
            List<tb_DatPhong> lstdp = dp.getList_StatusFalse();
            List<tb_DatPhong> lstdp_Booking = new List<tb_DatPhong>();
            List<tb_DatPhong> lstdpLe_statusFalse = new List<tb_DatPhong>();
            foreach(var item in lstdp)
            {
                if(item.BOOKING==true&&item.NGAYTRA>ngaydat)
                {
                    lstdp_Booking.Add(item);
                }
                else if(item.BOOKING==false)
                {
                    if(item.NGAYTRA>ngaydat)
                    {
                        lstdpLe_statusFalse.Add(item);
                    }    
                   
                }
            }
            lstdp = new List<tb_DatPhong>();
            lstdp.AddRange(lstdp_Booking);
            lstdp.AddRange(lstdpLe_statusFalse);
            List<tb_DatPhong_CT> lstdp_ct = new List<tb_DatPhong_CT>();
             foreach(var i in lstdp)
            {
                List<tb_DatPhong_CT> p = dp_ct.getLisTrungNgayDat_ByDatPhong(i.IDDP);
                lstdp_ct.AddRange(p);
            }
            List<V_PHONGBYNGAY> vlistPhong = db.V_PHONGBYNGAY.ToList();
            List<V_PHONGBYNGAY> vlstPhongTrung = new List<V_PHONGBYNGAY>();
            foreach(var vp in vlistPhong)
            {
                foreach(var i in lstdp_ct)
                {
                    if (vp.IDPHONG==i.IDPHONG)
                    {
                        vlstPhongTrung.Add(vp);
                    }    
                }    
               
            }
            foreach(var i in vlstPhongTrung)
            {
                vlistPhong.Remove(i);
            }    
            return vlistPhong;
            
        }    
    }
}
