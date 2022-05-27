using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BusinessLayer;
namespace BusinessLayer
{
  public class KYPHONG_CT
    {
        Entities db ;

        public KYPHONG_CT()
        {
            db = Entities.CreateEntities();
        }
		public List<tb_KyPhong_CT>GetList(int MaKy,string macty, string madv)
        {
			return db.tb_KyPhong_CT.Where(x=>x.MAKY==MaKy&&x.MACTY==macty&&x.MADV==madv).ToList();
        }
		public void incurred_KyPhong_CT(string macty,string madv, int thang, int nam)
		{
			var lstPhong = db.tb_Phong.ToList();
			
			if (lstPhong.Count == 0) return;

			foreach (var item in lstPhong)
			{
				List<string> listDay = new List<string>();

				var lst = db.tb_DatPhong_Phong_NgayO.Where(x => x.MAKY == nam * 100 + thang && x.MACTY == macty && x.MADV == madv&&x.IDPHONG==item.IDPHONG).ToList();
				if (lst.Count == 0)
                {
					for (int j = 1; j <= GetDayNumber(thang, nam); j++)
					{
						DateTime newDate = new DateTime(nam, thang, j);						
						listDay.Add(" ");
					}
					switch (listDay.Count)
					{
						case 28:
							listDay.Add("");
							listDay.Add("");
							listDay.Add("");
							break;
						case 29:
							listDay.Add("");
							listDay.Add("");
							break;
						case 30:
							listDay.Add("");
							break;
					}

					tb_KyPhong_CT kyphongchitiet = new tb_KyPhong_CT();
					kyphongchitiet.IDPHONG = item.IDPHONG;
					kyphongchitiet.TENPHONG = item.TENPHONG;
					kyphongchitiet.MACTY = macty;
					kyphongchitiet.MADV = madv;
					kyphongchitiet.MAKY = nam * 100 + thang;
					kyphongchitiet.D1 = listDay[0];
					kyphongchitiet.D2 = listDay[1];
					kyphongchitiet.D3 = listDay[2];
					kyphongchitiet.D4 = listDay[3];
					kyphongchitiet.D5 = listDay[4];
					kyphongchitiet.D6 = listDay[5];
					kyphongchitiet.D7 = listDay[6];
					kyphongchitiet.D8 = listDay[7];
					kyphongchitiet.D9 = listDay[8];
					kyphongchitiet.D10 = listDay[9];
					kyphongchitiet.D11 = listDay[10];
					kyphongchitiet.D12 = listDay[11];
					kyphongchitiet.D13 = listDay[12];
					kyphongchitiet.D14 = listDay[13];
					kyphongchitiet.D15 = listDay[14];
					kyphongchitiet.D16 = listDay[15];
					kyphongchitiet.D17 = listDay[16];
					kyphongchitiet.D18 = listDay[17];
					kyphongchitiet.D19 = listDay[18];
					kyphongchitiet.D20 = listDay[19];
					kyphongchitiet.D21 = listDay[20];
					kyphongchitiet.D22 = listDay[21];
					kyphongchitiet.D23 = listDay[22];
					kyphongchitiet.D24 = listDay[23];
					kyphongchitiet.D25 = listDay[24];
					kyphongchitiet.D26 = listDay[25];
					kyphongchitiet.D27 = listDay[26];
					kyphongchitiet.D28 = listDay[27];
					kyphongchitiet.D29 = listDay[28];
					kyphongchitiet.D30 = listDay[29];
					kyphongchitiet.D31 = listDay[30];
					kyphongchitiet.NAM = nam;
					kyphongchitiet.THANG = thang;
					var t = db.tb_KyPhong_CT.Where(x => x.IDPHONG == kyphongchitiet.IDPHONG && kyphongchitiet.MAKY == x.MAKY && x.MACTY == kyphongchitiet.MACTY && kyphongchitiet.MADV == x.MADV).ToList();
					if (t.Count > 0)
					{
						update(kyphongchitiet);
					}
					else
					{
						db.tb_KyPhong_CT.Add(kyphongchitiet);
						db.SaveChanges();
					}
				} 
				else
                {
					for (int j = 1; j <= GetDayNumber(thang, nam); j++)
					{
						DateTime newDate = new DateTime(nam, thang, j);
						foreach (var i in lst)
						{
							if (i.NGAYO.Value.ToString("dd/MM/yyyy") == newDate.ToString("dd/MM/yyyy"))
							{
								listDay.Add("X");
							}
						}
						listDay.Add(" ");

					}

					switch (listDay.Count)
					{
						case 28:
							listDay.Add("");
							listDay.Add("");
							listDay.Add("");
							break;
						case 29:
							listDay.Add("");
							listDay.Add("");
							break;
						case 30:
							listDay.Add("");
							break;
					}

					tb_KyPhong_CT kyphongchitiet = new tb_KyPhong_CT();
					kyphongchitiet.IDPHONG = item.IDPHONG;
					kyphongchitiet.TENPHONG = item.TENPHONG;
					kyphongchitiet.MACTY = macty;
					kyphongchitiet.MADV = madv;
					kyphongchitiet.MAKY = nam * 100 + thang;
					kyphongchitiet.D1 = listDay[0];
					kyphongchitiet.D2 = listDay[1];
					kyphongchitiet.D3 = listDay[2];
					kyphongchitiet.D4 = listDay[3];
					kyphongchitiet.D5 = listDay[4];
					kyphongchitiet.D6 = listDay[5];
					kyphongchitiet.D7 = listDay[6];
					kyphongchitiet.D8 = listDay[7];
					kyphongchitiet.D9 = listDay[8];
					kyphongchitiet.D10 = listDay[9];
					kyphongchitiet.D11 = listDay[10];
					kyphongchitiet.D12 = listDay[11];
					kyphongchitiet.D13 = listDay[12];
					kyphongchitiet.D14 = listDay[13];
					kyphongchitiet.D15 = listDay[14];
					kyphongchitiet.D16 = listDay[15];
					kyphongchitiet.D17 = listDay[16];
					kyphongchitiet.D18 = listDay[17];
					kyphongchitiet.D19 = listDay[18];
					kyphongchitiet.D20 = listDay[19];
					kyphongchitiet.D21 = listDay[20];
					kyphongchitiet.D22 = listDay[21];
					kyphongchitiet.D23 = listDay[22];
					kyphongchitiet.D24 = listDay[23];
					kyphongchitiet.D25 = listDay[24];
					kyphongchitiet.D26 = listDay[25];
					kyphongchitiet.D27 = listDay[26];
					kyphongchitiet.D28 = listDay[27];
					kyphongchitiet.D29 = listDay[28];
					kyphongchitiet.D30 = listDay[29];
					kyphongchitiet.D31 = listDay[30];
					var t = db.tb_KyPhong_CT.Where(x => x.IDPHONG == kyphongchitiet.IDPHONG && kyphongchitiet.MAKY == x.MAKY && x.MACTY == kyphongchitiet.MACTY && kyphongchitiet.MADV == x.MADV).ToList();
					if (t.Count > 0)
					{
						update(kyphongchitiet);
					}
					else
					{
						db.tb_KyPhong_CT.Add(kyphongchitiet);
						db.SaveChanges();
					}
				}					
					

				
				
			}

		}
		public void update(tb_KyPhong_CT cty)
		{
			tb_KyPhong_CT _cty = db.tb_KyPhong_CT.FirstOrDefault(x => x.MACTY == cty.MACTY&&x.MAKY==cty.MAKY&&x.IDPHONG==cty.IDPHONG&&x.MADV==cty.MADV);
			_cty.D1 = cty.D1;
			_cty.D2 = cty.D2;
			_cty.D3 = cty.D3;
			_cty.D4 = cty.D4;
			_cty.D5 = cty.D5;
			_cty.D6 = cty.D6;
			_cty.D7 = cty.D7;
			_cty.D8 = cty.D8;
			_cty.D9 = cty.D9;
			_cty.D10 = cty.D10;
			_cty.D11 = cty.D11;
			_cty.D12 = cty.D12;
			_cty.D13 = cty.D13;
			_cty.D14 = cty.D14;
			_cty.D15 = cty.D15;
			_cty.D16 = cty.D16;
			_cty.D17 = cty.D17;
			_cty.D18 = cty.D18;
			_cty.D19 = cty.D19;
			_cty.D20 = cty.D20;
			_cty.D21 = cty.D21;
			_cty.D22 = cty.D22;
			_cty.D23 = cty.D23;
			_cty.D24 = cty.D24;
			_cty.D25 = cty.D25;
			_cty.D26 = cty.D26;
			_cty.D27 = cty.D27;
			_cty.D28 = cty.D28;
			_cty.D29 = cty.D29;
			_cty.D30 = cty.D30;
			_cty.D31 = cty.D30;
			try
			{
				db.SaveChanges();
			}
			catch (Exception ex)
			{

				throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu" + ex.Message);
			}
		}
		private int GetDayNumber(int thang, int nam)
		{
			int dayNumber = 0;
			switch (thang)
			{
				case 2:
					dayNumber = (nam % 4 == 0 && nam % 100 != 0) || nam % 400 == 0 ? 29 : 28;
					break;
				case 4:
				case 6:
				case 9:
				case 11:
					dayNumber = 30;
					break;
				case 1:
				case 3:
				case 5:
				case 7:
				case 8:
				case 10:
				case 12:
					dayNumber = 31;
					break;
			}
			return dayNumber;
		}
	}
}
