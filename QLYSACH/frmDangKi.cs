using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLYSACH
{
    public partial class frmDangKi : Form
    {
        public frmDangKi()
        {
            InitializeComponent();
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked)
            {
                txtPassWord.PasswordChar = '\0';
                txtConfirmPass.PasswordChar = '\0';
            }
            else
            {
                txtPassWord.PasswordChar = '*';
                txtConfirmPass.PasswordChar = '*';
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form frmDn = new frmDangNhap();
            frmDn.Show();
            this.Hide();
        }

        private void txtHuy_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPassWord.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtConfirmPass.Clear();
            txtName.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hoten = txtName.Text.Trim();
            string taikhoan = txtUser.Text.Trim();
            string matkhau = txtPassWord.Text.Trim();
            string nhaplaimk = txtConfirmPass.Text.Trim();
            string email = txtEmail.Text.Trim();
            string nhomquyen = "user"; // Nhóm mặc định là "user"

            if (hoten == "" || email == "" || taikhoan == "" || matkhau == "" || nhaplaimk == "")
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            else if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            else if (matkhau != nhaplaimk)
            {
                MessageBox.Show("Mật Khẩu Nhập Lại Không Khớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassWord.Focus();
                return;
            }
            else
            {
                string sql = "INSERT INTO NGUOIDUNG(TENDANGNHAP, MATKHAU, HOTEN, EMAIL, NHOM) VALUES ('" + taikhoan + "','" + matkhau + "', N'" + hoten + "', '" + email + "', '" + nhomquyen + "')";
                try
                {
                    LopHamXuLy.runSql(sql);
                    MessageBox.Show("BẠN ĐÃ ĐĂNG KÍ THÀNH CÔNG.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Điều hướng người dùng trở lại trang đăng nhập
                    Form frmDN = new frmDangNhap();
                    frmDN.Show();
                    this.Close(); // Đóng form thêm tài khoản
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
