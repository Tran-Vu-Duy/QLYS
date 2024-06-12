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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form frmDk = new frmDangKi();
            frmDk.Show();
            this.Hide();
        }
        private Boolean KiemTraTT()
        {
            if (txtUser.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Tên Đăng Nhập", "Thông Báo Đến Người Dùng",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUser.Focus();
                return false;
            }
            if (txtPassWord.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập PassWord", "Thông Báo Đến Người Dùng",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassWord.Focus();
                return false;
            }
            return true;
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked)
            {
                txtPassWord.PasswordChar = '\0';
            }
            else
            {
                txtPassWord.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPassWord.Clear();
            txtUser.Focus();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KiemTraTT();
            // Kết nối tới cơ sở dữ liệu
            LopHamXuLy.Connect();

            // Lấy thông tin tài khoản và mật khẩu từ các ô nhập liệu
            string TaiKhoan = txtUser.Text.Trim(), matkhau = txtPassWord.Text.Trim();

            // Tạo câu lệnh SQL để truy vấn người dùng với tài khoản và mật khẩu đã nhập
            string sql1 = "SELECT * FROM NGUOIDUNG WHERE TENDANGNHAP='" + TaiKhoan + "' AND MATKHAU='" + matkhau + "'";
            string sql2 = "SELECT * FROM NGUOIDUNG WHERE TENDANGNHAP='" + TaiKhoan + "' AND MATKHAU!='" + matkhau + "'";
            DataTable dtlg = new DataTable();
            frmMenu frmM = new frmMenu();
            if (LopHamXuLy.TruyVan(sql1, dtlg))
            {
                //Mở frm Menu lên
                frmM.Show();
                this.Hide();
            }
            else if (LopHamXuLy.TruyVan(sql2, dtlg))
            {
                // Hiển thị thông báo nếu tài khoản hoặc mật khẩu không đúng
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Tên tài khoản không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
