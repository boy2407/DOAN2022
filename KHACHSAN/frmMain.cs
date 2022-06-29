
using BusinessLayer;
using DataLayer;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using DevExpress.XtraNavBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
namespace KHACHSAN
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(tb_SYS_USER user)
        {
            InitializeComponent();
            this._user = user;
            this.Text = "PHẦN MỀN QUẢN LÝ KHÁCH SẢN - " + _user.FULLNAME + " - " + _user.USERNAME + " - " + Friend._macty + " - " + Friend._madvi;
        }
        public tb_SYS_USER _user { get; set; }
        TANG _tang;
        PHONG _phong;
        SYS_FUNC _func;
        SYS_GROUP _sysgroup;
        SYS_RIGHT _sysRight;
        SYS_RIGHT_REP _sysRightRep;
        int _right;
        VIEW_DATPHONG_DATPHONG_CT_PHONG _v;
        GalleryItem item = null;
        DATPHONG _datphong;
        NavBarItem _itemBK;
        public List<OBJ_PHONG> _lstphong;
        public frmSetParam _frmsetparam { get; set; }
        public frmLogin _frmlogin { get; set; }
        bool them;
        //[Obsolete]
        Label lbl;
        frmLogin objLogin = (frmLogin)Application.OpenForms["frmLogin"];

        public void frmMain_Load(object sender, EventArgs e)
        {
            _sysRightRep = new SYS_RIGHT_REP();
              _sysRight = new SYS_RIGHT();
            _sysgroup = new SYS_GROUP();
            _tang = new TANG();
            _func = new SYS_FUNC();
            _phong = new PHONG();
            _datphong = new DATPHONG();
            leftMenu();
            showRoom();
            _lstphong = _phong.getPhongCheckOut(Friend._macty, Friend._madvi);
            this.navMain.Size = new System.Drawing.Size(321, 500);
            timer_GetPhongCheckOut.Enabled = true;
            timer1.Enabled = true;
            timerCheckIn.Enabled = true;
            _itemBK = GetNavItem();
            //var tes = _datphong.GetAll_RoomCheckOut(Friend._macty, Friend._madvi);
            //MessageBox.Show(tes.Count.ToString());
            //foreach (var i in tes )
            //{
            //    MessageBox.Show(i.IDDP.ToString());
            //}    
            gControl.Gallery.Appearance.ItemCaptionAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10.25F);
            gControl.Gallery.Appearance.ItemCaptionAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 12, System.Drawing.FontStyle.Bold);
            if (objLogin != null)
            {
                objLogin.Hide();
            }         
            lblThongBooking.Text = "Thông báo có lịch booking";
            lblThongBooking.Location = new Point(toolStrip1.Location.X+btnThoat.Width+btnBaoCao.Height+btnHeThong.Width+btnCaiDat.Width,toolStrip1.Location.Y+5);
            lblThongBooking.Size = new System.Drawing.Size(300, 200);
            lblThongBooking.Font= new System.Drawing.Font("Tahoma", 12, System.Drawing.FontStyle.Bold);
            lblThongBooking.ForeColor = Color.Red;
            lblThongBooking.Visible = false;
        }
    
        //add group vào navbar, add items vào group
        private void timelblbooking_Tick(object sender, EventArgs e)
        {
            if(lblThongBooking.Location.X>toolStrip1.Width)
            {
                lblThongBooking.Location = new Point(toolStrip1.Location.X + btnThoat.Width + btnBaoCao.Height + btnHeThong.Width + btnCaiDat.Width, toolStrip1.Location.Y+5);
            }
            lblThongBooking.Location = new Point(lblThongBooking.Location.X+10, toolStrip1.Location.Y+5);
            lblThongBooking.Visible = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {          
                checkout1();
                timer1.Enabled = false;
                timer2.Enabled = true;             
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            checkout2();
                timer2.Enabled = false;
                timer1.Enabled = true;      
        }
        private void timer_GetPhongCheckOut_Tick(object sender, EventArgs e)
        {
            _lstphong = _phong.getPhongCheckOut(Friend._macty, Friend._madvi);        
        }
        public void checkout1()
        {        
            var lst = _lstphong;
            foreach(var i in lst)
            {               
                foreach (GalleryItemGroup gc in gControl.Gallery.Groups)
                {
                    if(gc.Caption.ToString()==i.TENTANG.ToString())
                    {
                        foreach (GalleryItem p in gc.Items)
                        {
                          
                            if (p.Value.ToString() != i.IDPHONG.ToString())
                            {
                                continue;
                            }
                            p.ImageOptions.Image = imageList3.Images[1];
                        }
                    }                     
                }    
            }    

        }
        public void checkout2()
        {
            var lst = _lstphong;
            foreach (var i in lst)
            {
                foreach (GalleryItemGroup gc in gControl.Gallery.Groups)
                {
                    if (gc.Caption.ToString() == i.TENTANG.ToString())
                    {
                        foreach (GalleryItem p in gc.Items)
                        {                          
                            if (p.Value.ToString() != i.IDPHONG.ToString())
                            {
                                continue;
                            }
                            p.ImageOptions.Image = imageList3.Images[0];
                        }
                    }
                }
            }

        }
         public NavBarItem GetNavItem()
        {           
            var lst = _datphong.GetAllCheckIn(Friend._macty, Friend._madvi);
            if (lst != null)
            {
                
                foreach (NavBarGroup navGroup in navMain.Groups)
                {
                    if (navGroup.Name == "DANHMUC")
                    {
                        foreach (NavBarItemLink i in navGroup.ItemLinks)
                        {
                            if (i.Item.Tag.ToString() == "BOOKING")
                            {
                                return i.Item;
                            }
                        }
                    }
                }
            }
            return null;
        }
        private void timerCheckIn_Tick(object sender, EventArgs e)
        {
                       
                _datphong = new DATPHONG();
                var lst = _datphong.GetAllCheckIn(Friend._macty, Friend._madvi);
                if (lst.Count < 1)
                {
                    _itemBK.Appearance.ForeColor = Color.Black;
                      lblThongBooking.Visible = false;
                    lblThongBooking.Location = new Point(toolStrip1.Location.X + btnThoat.Width + btnBaoCao.Height + btnHeThong.Width + btnCaiDat.Width, toolStrip1.Location.Y + 5);
                    timelblbooking.Stop();
                    return;
                }
                _itemBK.Appearance.ForeColor = Color.Red;
            timelblbooking.Start();           
        }

        void leftMenu()
        {
            var _lsParent = _func.getParent();
            int i = 0;
            if(_lsParent!=null)
            {
                foreach (var _pr in _lsParent)
                {
                    NavBarGroup navGroup = new NavBarGroup(_pr.DESCRIPTION);
                    navGroup.Tag = _pr.FUNC_CODE;
                    navGroup.Name = _pr.FUNC_CODE;
                    navGroup.ImageOptions.LargeImageIndex = i++;
                    navMain.Groups.Add(navGroup);
                    var _lsChild = _func.getChild(_pr.FUNC_CODE);
                    foreach (var _ch in _lsChild)
                    {
                        NavBarItem navItem = new NavBarItem(_ch.DESCRIPTION);
                        navItem.Tag = _ch.FUNC_CODE;
                        navItem.Name = _ch.FUNC_CODE;
                        navItem.Appearance.FontSizeDelta = 100;
                        navItem.ImageOptions.SmallImageIndex = 0;
                        navItem.Appearance.ForeColor = Color.Black;
                        navGroup.ItemLinks.Add(navItem);
                    }
                    navMain.Groups[navGroup.Name].Expanded = true;
                }
              
            }    
            
        }
        //Hiện thị phòng lên gcontrol
        public void showRoom()
        {
            _tang = new TANG();
            _phong = new PHONG();
            var lsTang = _tang.getALL(Friend._macty,Friend._madvi);
            gControl.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            gControl.Gallery.ImageSize = new Size(72,72);
            gControl.Gallery.ShowItemText = true;
            gControl.Gallery.ShowGroupCaption = true;

            foreach(var t in lsTang)
            {
                var galleryItem = new GalleryItemGroup();
              
                galleryItem.Caption = t.TENTANG;
                
                galleryItem.CaptionAlignment = GalleryItemGroupCaptionAlignment.Stretch;
                var lsPhong = _phong.getByTang(t.IDTANG);
                foreach(var p in lsPhong)
                {
                    var gc_item = new GalleryItem();
                    gc_item.Caption ="Phòng "+ p.TENPHONG;
                   
                    if (p.TRANGTHAI==false)
                        gc_item.ImageOptions.Image = imageList3.Images[2];
                    else
                      gc_item.ImageOptions.Image = imageList3.Images[0];
                    gc_item.Value = p.IDPHONG;
                  
                    galleryItem.Items.Add(gc_item);

                }
                gControl.Gallery.Groups.Add(galleryItem);
            }
            gControl.Controls.Add(lbl);
        }
        //Hiện frm phụ
        private void navMain_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            string func_code = e.Link.Item.Tag.ToString();

            var _gr = _sysgroup.GetGroupByMenBer(_user.IDUSER);
            var _uRight = _sysRight.getRight(_user.IDUSER, func_code);
            _right = _uRight.USER_RIGHT.Value;
            if(_gr!=null)
            {
                var _groupRight = _sysRight.getRight(_gr.GROUP, func_code);
                if(_uRight.USER_RIGHT<_groupRight.USER_RIGHT)
                {
                    _uRight.USER_RIGHT = _groupRight.USER_RIGHT;
                }    
            }    
            if(_uRight.USER_RIGHT==0)
            {
                MessageBox.Show("Không có quyền thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                switch (func_code)
                {
                    case "CONGTY":
                        {
                            frmCongTy frm = new frmCongTy(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "DONVI":
                        {
                            frmDonVi frm = new frmDonVi(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "SANPHAM":
                        {
                            frmSanPham frm = new frmSanPham(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "PHONG":
                        {
                            frmPhong frm = new frmPhong(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            //showRoom();
                            break;
                        }
                    case "THIETBI":
                        {
                            frmThietBi frm = new frmThietBi(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "PHONG_THIETBI":
                        {
                            frmPhong_ThietBi frm = new frmPhong_ThietBi(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "TANG":
                        {
                            frmTang frm = new frmTang(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "KHACHHANG":
                        {
                            frmKhachHang frm = new frmKhachHang(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "DATPHONG":
                        {
                            //ThreadStart ts = new ThreadStart(() =>
                            //{
                            //    frmDatPhong frm = new frmDatPhong(_user, _uRight.USER_RIGHT.Value);
                            //    frm.ShowDialog();
                            //});

                            //Thread t = new Thread(ts);
                            //t.Name = "frmDatPhong";
                            //t.ApartmentState = ApartmentState.STA;
                            //t.Start();

                            frmDatPhong frm = new frmDatPhong(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "LOAIPHONG":
                        {
                            frmLoaiPhong frm = new frmLoaiPhong(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "BOOKING":
                        {
                            frmBooking frm = new frmBooking(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "QUANTRI":
                        {
                          
                            break;
                        }
                    case "KYPHONG":
                        {
                            frmKyPhong frm = new frmKyPhong(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "DOIMK":
                        {
                            frmDoiMK frm = new frmDoiMK(_user);
                            frm.ShowDialog();
                            break;
                        }

                }

            }    
        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if(_sysRightRep.check(_user))
            {
                frmBaoCao frm = new frmBaoCao(_user);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn Không có quyền thao tác", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            timerClose.Start();
        }

        private void popupMenu1_Popup(object sender, EventArgs e)
        {
            Point point = gControl.PointToClient(Control.MousePosition);
            RibbonHitInfo hitInfo = gControl.CalcHitInfo(point);

            if (hitInfo.InGalleryItem || hitInfo.HitTest == RibbonHitTest.GalleryImage)
                item = hitInfo.GalleryItem;
        }

        private void btnDatPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(_phong.checkEmpty(int.Parse(item.Value.ToString())))
            {
                MessageBox.Show("Phòng đã được đặt. Vui lòng chọn phòng khác ", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            frmDatPhongDon frm = new frmDatPhongDon();
            frm._idPhong = int.Parse(item.Value.ToString());
            frm._them = true;
            frm.ShowDialog();
        }

        private void btnChuyenPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_phong.checkEmpty(int.Parse(item.Value.ToString())))
            {
                MessageBox.Show("Phòng chưa được đặt. Vui lòng chọn phòng khác ",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _v = new VIEW_DATPHONG_DATPHONG_CT_PHONG();
            v_DATPHONG_DATPHONG_CT_PHONG v = _v.getItemByIdPhong_Iddp(int.Parse(item.Value.ToString()));

            frmChuyenPhong frm = new frmChuyenPhong();
            frm._idPhong = int.Parse(item.Value.ToString());
            frm._iddp_ct = v.IDDPCT;
            frm._iddp = v.IDDP;
            var t = _datphong.GetItem(v.IDDP, Friend._macty, Friend._madvi);
            frm.ngaydat = t.NGAYDAT.Value;
            frm.ngaytra = t.NGAYTRA.Value;
            frm.ShowDialog();
        }
        private void btnSPDV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_phong.checkEmpty(int.Parse(item.Value.ToString())))
            {
                MessageBox.Show("Phòng chưa được đặt. Vui lòng chọn phòng khác ",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _v = new VIEW_DATPHONG_DATPHONG_CT_PHONG();
            v_DATPHONG_DATPHONG_CT_PHONG v = _v.getItemByIdPhong_Iddp(int.Parse(item.Value.ToString()));

            if (v != null)
            {
                frmDatPhong frmdp = new frmDatPhong(_user, _right);
                frmdp._idDP = v.IDDP;
                frmdp._thanhtoan = true;
                frmdp.Show();
            }
            else
            {
                frmDatPhongDon frm = new frmDatPhongDon();
                frm._idPhong = int.Parse(item.Value.ToString());
                frm._them = false;
                frm.ShowDialog();
            }

        }
        private void btnThanhToan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_phong.checkEmpty(int.Parse(item.Value.ToString())))
            {
                MessageBox.Show("Phòng chưa được đặt. Vui lòng chọn phòng khác ",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
               _v = new VIEW_DATPHONG_DATPHONG_CT_PHONG();
            v_DATPHONG_DATPHONG_CT_PHONG v= _v.getItemByIdPhong_Iddp(int.Parse(item.Value.ToString()));
          
            if (v!=null)
            {
                frmDatPhong frmdp = new frmDatPhong();
                frmdp._idDP = v.IDDP;
                frmdp._thanhtoan = true;
                frmdp.Show();
            }  
            else
            {
                frmDatPhongDon frm = new frmDatPhongDon();
                frm._idPhong = int.Parse(item.Value.ToString());
                frm._them = false;
                frm.ShowDialog();
            }    
           
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            frmCaiDat frm = new frmCaiDat();
            frm.ShowDialog();
        }

        private void timerClose_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.0)
            {
                this.Opacity -= 0.0525;
            }
            else
            {
                timerClose.Stop();
                Application.Exit();
            }
        }

      
    }
}
