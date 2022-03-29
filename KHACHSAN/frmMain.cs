
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
using USERMANAGEMENT;

namespace KHACHSAN
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain(tb_SYS_USER user)
        {
            InitializeComponent();
            this._user = user;
            this.Text = "PHẦN MỀN QUẢN LÝ KHÁCH SẢN - " + _user.FULLNAME + " - "+ _user.USERNAME+" - " + Friend._macty+" - "+Friend._madvi ;
        }
        tb_SYS_USER _user;
        TANG _tang;
        PHONG _phong;
        SYS_FUNC _func;
        SYS_GROUP _sysgroup;
        SYS_RIGHT _sysRight;
        VIEW_DATPHONG_DATPHONG_CT_PHONG _v;
        GalleryItem item = null;
        bool them;
        //[Obsolete]
        private void frmMain_Load(object sender, EventArgs e)
        {
            _sysRight = new SYS_RIGHT();
            _sysgroup = new SYS_GROUP();
            _tang = new TANG();
            _func = new SYS_FUNC();
            _phong = new PHONG();
            leftMenu();
            showRoom(); 
           
            this.navMain.Size = new System.Drawing.Size(321, 500);
            timer1.Enabled = true;

            
            gControl.Gallery.Appearance.ItemCaptionAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10.25F);
            gControl.Gallery.Appearance.ItemCaptionAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 12, System.Drawing.FontStyle.Bold);
           
        }
        //add group vào navbar, add items vào group
       
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
        public void checkout1()
        {          
            var lst = _phong.getPhongCheckOut(Friend._macty, Friend._madvi);
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
            var lst = _phong.getPhongCheckOut(Friend._macty, Friend._madvi);
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
                        navGroup.ItemLinks.Add(navItem);
                    }
                    navMain.Groups[navGroup.Name].Expanded = false;
                }
              
            }    
            
        }
        //Hiện thị phòng lên gcontrol
        public void showRoom()
        {
            _tang = new TANG();
            _phong = new PHONG();
            var lsTang = _tang.getALL();
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
                    gc_item.Caption = p.TENPHONG;
                   
                    if (p.TRANGTHAI==false)
                        gc_item.ImageOptions.Image = imageList3.Images[2];
                    else
                      gc_item.ImageOptions.Image = imageList3.Images[0];
                    gc_item.Value = p.IDPHONG;
                  
                    galleryItem.Items.Add(gc_item);

                }
                gControl.Gallery.Groups.Add(galleryItem);
            }
           
        }
        //Hiện frm phụ
        private void navMain_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            string func_code = e.Link.Item.Tag.ToString();

            var _gr = _sysgroup.GetGroupByMenBer(_user.IDUSER);
            var _uRight = _sysRight.getRight(_user.IDUSER, func_code);

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
                            frmDonVi frm = new frmDonVi();
                            frm.ShowDialog();
                            break;
                        }
                    case "SANPHAM":
                        {
                            frmSanPham frm = new frmSanPham();
                            frm.ShowDialog();
                            break;
                        }
                    case "PHONG":
                        {
                            frmPhong frm = new frmPhong();
                            frm.ShowDialog();
                            //showRoom();
                            break;
                        }
                    case "THIETBI":
                        {
                            frmThietBi frm = new frmThietBi();
                            frm.ShowDialog();
                            break;
                        }
                    case "PHONG_THIETBI":
                        {
                            frmPhong_ThietBi frm = new frmPhong_ThietBi();
                            frm.ShowDialog();
                            break;
                        }
                    case "TANG":
                        {
                            frmTang frm = new frmTang();
                            frm.ShowDialog();
                            break;
                        }
                    case "KHACHHANG":
                        {
                            frmKhachHang frm = new frmKhachHang();
                            frm.ShowDialog();
                            break;
                        }
                    case "DATPHONG":
                        {
                            frmDatPhong frm = new frmDatPhong();
                            frm.ShowDialog();
                            break;
                        }
                    case "LOAIPHONG":
                        {
                            frmLoaiPhong frm = new frmLoaiPhong();
                            frm.ShowDialog();
                            break;
                        }
                    case "BOOKING":
                        {
                            frmBooking frm = new frmBooking();
                            frm.ShowDialog();
                            break;
                        }
                    case "QUANTRI":
                        {
                            USERMANAGEMENT.frmMain frm = new USERMANAGEMENT.frmMain();
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
            frmBaoCao frm = new frmBaoCao(_user);
            frm.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            frmChuyenPhong frm = new frmChuyenPhong();
            frm._idPhong = int.Parse(item.Value.ToString());            
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

        
    }
}
