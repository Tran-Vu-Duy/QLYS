using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;

namespace QLYSACH
{
    public partial class frmQLyNhanVien : Form
    {
        public frmQLyNhanVien()
        {
            InitializeComponent();
        }
  
        private void timerName_Tick(object sender, EventArgs e)
        {

        }

        private void txtName_Click(object sender, EventArgs e)
        {

        }
        private void Reset()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            txtNSinh.Clear();
            txtChucVu.Clear();
            txtMa.Focus();
        }
        private void ShowNhanVien()
        {
            DataTable dtnhanvien = new DataTable();
            LopHamXuLy.Connect();
            string sqlNhanVien = "SELECT * FROM NHANVIEN";
            if(LopHamXuLy.TruyVan(sqlNhanVien,dtnhanvien))
            {
                // Đặt DataSource cho DataGridView
                dtgvNV.DataSource = dtnhanvien;

                // Đặt tiêu đề và độ rộng cho các cột
                dtgvNV.Columns[0].HeaderText = "MÃ NV";
                dtgvNV.Columns[0].Width = 100;
                dtgvNV.Columns[1].HeaderText = "TÊN NHÂN VIÊN";
                dtgvNV.Columns[1].Width = 150;
                dtgvNV.Columns[2].HeaderText = "ĐỊA CHỈ NHÂN VIÊN";
                dtgvNV.Columns[2].Width = 150;
                dtgvNV.Columns[3].HeaderText = "SỐ ĐIỆN THOẠI";
                dtgvNV.Columns[3].Width = 120;
                dtgvNV.Columns[4].HeaderText = "EMAIL";
                dtgvNV.Columns[4].Width = 120;
                dtgvNV.Columns[5].HeaderText = "NGÀY SINH";
                dtgvNV.Columns[5].Width = 120;
                dtgvNV.Columns[6].HeaderText = "CHỨC VỤ";
                dtgvNV.Columns[6].Width = 100;

                // Thiết lập kiểu hiển thị cho header
                dtgvNV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(116, 86, 174);
                dtgvNV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dtgvNV.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10, FontStyle.Regular);

                // Đặt nền cho DataGridView
                dtgvNV.BackgroundColor = Color.FromArgb(235, 230, 255);

                // Loại bỏ border giữa các hàng
                dtgvNV.CellBorderStyle = DataGridViewCellBorderStyle.None;

                // Đặt màu nền cho các ô khi được chọn
                dtgvNV.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 230, 255);

                // Đặt font chữ và màu nền cho các ô
                dtgvNV.DefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10, FontStyle.Regular);
                dtgvNV.DefaultCellStyle.BackColor = Color.FromArgb(230, 231, 233);

                // Loại bỏ kiểu mặc định của header
                dtgvNV.EnableHeadersVisualStyles = false;

                // Đặt màu nền cho các ô không được chọn
                dtgvNV.DefaultCellStyle.BackColor = Color.FromArgb(230, 231, 233);
                dtgvNV.DefaultCellStyle.ForeColor = Color.Black;

                // Đặt màu nền cho các ô khi được chọn
                dtgvNV.DefaultCellStyle.SelectionBackColor = Color.FromArgb(116, 86, 174);
                dtgvNV.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        public bool KiemTraThongTin()
        {
            // Kiểm tra mã 
            if (txtMa.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMa.Focus();
                return false;
            }

            // Kiểm tra tên 
            if (txtTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Focus();
                return false;
            }

            // Kiểm tra địa chỉ
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return false;
            }

            // Kiểm tra số điện thoại
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }
            else if (!Regex.IsMatch(txtSDT.Text, @"^\d+$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng chỉ nhập số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            // Kiểm tra email
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập email.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            else if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Kiểm tra ngày sinh
            if (txtNSinh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập ngày sinh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNSinh.Focus();
                return false;
            }
            else
            {
                string errorMessage;
                if (!IsValidDateOfBirth(txtNSinh.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNSinh.Focus();
                    return false;
                }
            }

            return true;
        }
        // Hàm kiểm tra định dạng email
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        // Hàm kiểm tra ngày sinh
        private bool IsValidDateOfBirth(string dateOfBirth, out string errorMessage)
        {
            errorMessage = string.Empty;
             DateTime dob;

            // Kiểm tra định dạng ngày sinh (định dạng dd/MM/yyyy)
            if (!DateTime.TryParseExact(dateOfBirth, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
            {
                errorMessage = "Định dạng ngày sinh không hợp lệ. Vui lòng nhập theo định dạng dd/MM/yyyy.";
                return false;
            }
            // Kiểm tra nếu ngày sinh là một ngày trong tương lai
            if (dob > DateTime.Now)
            {
                errorMessage = "Ngày sinh không được là một ngày trong tương lai.";
                return false;
            }

            return true;
        }
        private void Them()
        {
            if (KiemTraThongTin())
            {
                LopHamXuLy.Connect();
                string sqlInsert = "INSERT INTO NHANVIEN(MANV, TENNV, DIACHINV, SDTNV, EMAILNV, NGAYSINH, CHUCVU) VALUES(N'" + txtMa.Text + "', N'" + txtTen.Text + "', N'" + txtDiaChi.Text + "', '" + txtSDT.Text + "', '" + txtEmail.Text + "', '" + txtNSinh.Text + "', N'" + txtChucVu.Text + "')";
                try
                {
                    LopHamXuLy.runSql(sqlInsert);
                    MessageBox.Show("THÊM THÀNH CÔNG", "XÁC NHẬN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowNhanVien();
                    Reset();
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "LỖI");
                }
                LopHamXuLy.Disconnect();
            }
        }

        private void dtgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvNV.Rows[e.RowIndex];
                txtMa.Text = row.Cells["MANV"].Value.ToString();
                txtTen.Text = row.Cells["TENNV"].Value.ToString();
                txtDiaChi.Text = row.Cells["DIACHINV"].Value.ToString();
                txtSDT.Text = row.Cells["SDTNV"].Value.ToString();
                txtEmail.Text = row.Cells["EMAILNV"].Value.ToString();
                txtNSinh.Text = row.Cells["NGAYSINH"].Value.ToString();
                txtChucVu.Text = row.Cells["CHUCVU"].Value.ToString();
            }
        }

        private void QLyNhanVien_Load(object sender, EventArgs e)
        {
            panelTT.Enabled = false;
            ShowNhanVien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            panelTT.Enabled = true;
            Reset();
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }
        private void Sua()
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled)
            {
                Them();
            }
            else
            {
                Sua();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Form frmM = new frmMenu();
            frmM.Show();
            this.Hide();
        }
    }
}
