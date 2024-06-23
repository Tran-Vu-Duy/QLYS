using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLYSACH
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }
        private void frmMenu_Load(object sender, EventArgs e)
        {
            // Đăng ký sự kiện thay đổi kích thước cho các panel
            SideBar.SizeChanged += new EventHandler(SideBar_SizeChanged);
            menuQuanLy.SizeChanged += new EventHandler(menuQuanLy_SizeChanged);
            MenuBaoCao.SizeChanged += new EventHandler(MenuBaoCao_SizeChanged);
            MenuTaiKhoan.SizeChanged += new EventHandler(MenuTaiKhoan_SizeChanged);
            MenuTaoBaoCao.SizeChanged += new EventHandler(MenuTaoBaoCao_SizeChanged);
        }
        private void SideBar_SizeChanged(object sender, EventArgs e)
        {
            AdjustChildForm();
        }

        private void menuQuanLy_SizeChanged(object sender, EventArgs e)
        {
            AdjustChildForm();
        }

        private void MenuBaoCao_SizeChanged(object sender, EventArgs e)
        {
            AdjustChildForm();
        }

        private void MenuTaiKhoan_SizeChanged(object sender, EventArgs e)
        {
            AdjustChildForm();
        }

        private void MenuTaoBaoCao_SizeChanged(object sender, EventArgs e)
        {
            AdjustChildForm();
        }
        private void AdjustChildForm()
        {
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Dock = DockStyle.Fill;
                ActiveMdiChild.Invalidate();
            }
        }

        //...
        //..Khai báo các Form
        //...
        frmQLyNhanVien Nhanvien;
        frmQlyKhachHang Khachhang;
        frmQlyHoaDon Hoadon;
//-------------------------------------------------
//----------TẠO HAMBEGER MENU----------------------
//-------------------------------------------------
        //
        // Tạo Chuyển động cho Button Quản Lý
        //
        bool menuExpand = false;
        private void MenuTranstion_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                menuQuanLy.Height += 10;
                if (menuQuanLy.Height >= 253)
                {
                    MenuTranstion.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                menuQuanLy.Height -= 10;
                if(menuQuanLy.Height <= 50)
                {
                    MenuTranstion.Stop();
                    menuExpand = false;
                }
            }
        }

        private void btQuanLy_Click(object sender, EventArgs e)
        {
            MenuTranstion.Start();
        }
        //
        // Tạo CHuyển động cho SideBar
        //
        bool sidebarExpand = true;
        private void sidebarTrantion_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                SideBar.Width -= 10;
                if(SideBar.Width <= 60 )
                {
                    sidebarExpand = false;
                    sidebarTrantion.Stop();
                }
            }
            else
            {
                SideBar.Width += 10;
                if(SideBar.Width >= 200 )
                {
                    sidebarExpand = true;
                    sidebarTrantion.Stop();
                }
            }
        }
        private void btHome_Click(object sender, EventArgs e)
        {
            sidebarTrantion.Start();
        }
        //
        // Chuyển động Báo Cáo
        //
        bool BaoCaoExpand = false;
        private void BaoCaoTranstion_Tick(object sender, EventArgs e)
        {

            if (BaoCaoExpand == false)
            {
                MenuBaoCao.Height += 8;
                if (MenuBaoCao.Height >= 124)
                {
                    BaoCaoTranstion.Stop();
                    BaoCaoExpand = true;
                }
            }
            else
            {
                MenuBaoCao.Height -= 8;
                if (MenuBaoCao.Height <= 50)
                {
                    BaoCaoTranstion.Stop();
                    BaoCaoExpand = false;
                }
            }
        }
        private void btBaoCao_Click(object sender, EventArgs e)
        {
            BaoCaoTranstion.Start();
        }
        //
        // Chuyển động tài khoản
        //
        bool TaiKhoanExpand = false;
        private void TaiKhoanTranstion_Tick(object sender, EventArgs e)
        {
            if (TaiKhoanExpand == false)
            {
                MenuTaiKhoan.Height += 8;
                if (MenuTaiKhoan.Height >= 145)
                {
                    TaiKhoanTranstion.Stop();
                    TaiKhoanExpand = true;
                }
            }
            else
            {
                MenuTaiKhoan.Height -= 8;
                if (MenuTaiKhoan.Height <= 44)
                {
                    TaiKhoanTranstion.Stop();
                    TaiKhoanExpand = false;
                }
            }
        }
        private void btTaiKhoan_Click(object sender, EventArgs e)
        {
            TaiKhoanTranstion.Start();
        }
        //
        //Chuyển động tạo báo cáo
        //
        bool TaoBaoCaoExpand = false;
        private void TaoBaoCaoTranstion_Tick(object sender, EventArgs e)
        {
            if (TaoBaoCaoExpand == false)
            {
                MenuTaoBaoCao.Height += 8;
                if (MenuTaoBaoCao.Height >= 130)
                {
                    TaoBaoCaoTranstion.Stop();
                    TaoBaoCaoExpand = true;
                }
            }
            else
            {
                MenuTaoBaoCao.Height -= 8;
                if (MenuTaoBaoCao.Height <= 45)
                {
                    TaoBaoCaoTranstion.Stop();
                    TaoBaoCaoExpand = false;
                }
            }
        }
        private void btTaoBaoCao_Click(object sender, EventArgs e)
        {
            TaoBaoCaoTranstion.Start();
        }
//----------------------------------------------------------
//----------KHAI BÁO MENU-------------------------------
//---------------------------------------------------
        //..
        //..MENU QUẢN LÝ
        //..
        public FlowLayoutPanel MnQL
        {
            get { return menuQuanLy;}
            set { menuQuanLy = value; }
        }
        public Panel QLNV   //Nhân viên
        {
            get { return QLNhanVien; }
            set { QLNhanVien = value; }
        }
        public Panel QLKH   //Khách hàng
        {
            get { return QLKhachHang; }
            set { QLKhachHang = value; }
        }
        public Panel QLHD   //Hoá đơn
        {
            get { return QLHoaDon; }
            set { QLHoaDon= value; }
        }
        public Panel QLTL   //Thể loại
        {
            get { return QLTheLoai; }
            set { QLTheLoai = value; }
        }
        public Panel QLS    //Sách
        {
            get { return QLSach; }
            set { QLSach = value; }
        }
        //..
        //..MENU BÁO CÁO
        //..
        public Panel MnBC
        {
            get { return MenuBaoCao; }
            set { MenuBaoCao = value; }
        }
        public Panel BCDT   //doanh thu
        {
            get { return BCDoanhThu; }
            set { BCDoanhThu = value; }
        }
        public Panel BCTK   //Tồn kho
        {
            get { return BCTonKho; }
            set { BCTonKho = value; }
        }
        //..
        //..MENU TẠO BÁO CÁO
        //..
        public Panel MnTBC
        {
            get { return MenuTaoBaoCao; }
            set { MenuTaoBaoCao = value; }
        }
        public Panel TBCHD   //Hoá đơn
        {
            get { return TBCHoaDon; }
            set { TBCHoaDon = value; }
        }
        public Panel TBCDT   //Doanh thu
        {
            get { return TBCDoanhThu; }
            set { TBCDoanhThu = value; }
        }
        //..
        //..MENU TÀI KHOẢN
        //..
        public Panel MnTKhoan
        {
            get { return MenuTaiKhoan; }
            set { MenuTaiKhoan = value; }
        }
        public Panel TKTT   //Thông tin
        {
            get { return TKThongTin; }
            set { TBCHoaDon = value; }
        }
        public Panel TkDX   //Đăng xuất
        {
            get { return TKDangXuat; }
            set { TKDangXuat = value; }
        }

        private void btHoaDon_Click(object sender, EventArgs e)
        {
            Form frmHD = new frmQlyHoaDon();
            frmHD.Show();
            this.Hide();
        }

        private void btNhanVien_Click(object sender, EventArgs e)
        {
            if (Nhanvien == null)
            {
                Nhanvien = new frmQLyNhanVien();
                Nhanvien.FormClosed += Nhanvien_FormClosed;
                Nhanvien.MdiParent = this;
                Nhanvien.Dock = DockStyle.Fill;
                Nhanvien.Show();
            }
            else
            {
                Nhanvien.Activate();
            }
        }
        private void Nhanvien_FormClosed(object sender, EventArgs e)
        {
            Nhanvien = null;
        }

        private void btKhachHang_Click(object sender, EventArgs e)
        {
            if (Khachhang == null)
            {
                Khachhang = new frmQlyKhachHang();
                Khachhang.FormClosed += Khachhang_FormClosed;
                Khachhang.MdiParent = this;
                Khachhang.Dock = DockStyle.Fill;
                Khachhang.Show();
            }
            else
            {
                Nhanvien.Activate();
            }
        }
        private void Khachhang_FormClosed(object sender, EventArgs e)
        {
            Khachhang = null;
        }

        private void btHoaDon_Click_1(object sender, EventArgs e)
        {
            if (Hoadon == null)
            {
                Hoadon = new frmQlyHoaDon();
                Hoadon.FormClosed += Hoadon_FormClosed;
                Hoadon.MdiParent = this;
                Hoadon.Dock = DockStyle.Fill;
                Hoadon.Show();
            }
            else
            {
                Hoadon.Activate();
            }
        }
        private void Hoadon_FormClosed(object sender, EventArgs e)
        {
            Hoadon = null;
        }
    }
}
