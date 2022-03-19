using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    class GIOITINH
    {

        public bool _value { set; get; }
        public string _display { set; get; }
        public GIOITINH()
        {

        }
        public GIOITINH(bool _val, string _dis)
        {
            this._value = _val;
            this._display = _dis;
        }
        public static List<GIOITINH> getList()
        {
            List<GIOITINH> lst = new List<GIOITINH>();
            GIOITINH[] collect = new GIOITINH[2]
            {
                new GIOITINH(false,"Nữ"),
                new GIOITINH(true,"Nam")
            };
            lst.AddRange(collect);
            return lst;
        }
    }
}
