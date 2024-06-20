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
            txtTP.Clear();
            txtSDT.Clear();
            txtNSinh.Clear();
            txtChucVu.Clear();
            rdNam.Checked = false;
            rdNu.Checked = false;
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
                dtgvNV.Columns[0].Width = 80;
                dtgvNV.Columns[1].HeaderText = "TÊN NV";
                dtgvNV.Columns[1].Width = 120;
                dtgvNV.Columns[2].HeaderText = "ĐỊA CHỈ ";
                dtgvNV.Columns[2].Width = 120;
                dtgvNV.Columns[3].HeaderText = "THÀNH PHỐ ";
                dtgvNV.Columns[3].Width = 100;
                dtgvNV.Columns[4].HeaderText = "SĐT";
                dtgvNV.Columns[4].Width = 100;
                dtgvNV.Columns[5].HeaderText = "EMAIL";
                dtgvNV.Columns[5].Width = 120;
                dtgvNV.Columns[6].HeaderText = "NGÀY SINH";
                dtgvNV.Columns[6].Width = 100;
                dtgvNV.Columns[7].HeaderText = "GIỚI TÍNH";
                dtgvNV.Columns[7].Width = 60;
                dtgvNV.Columns[8].HeaderText = "CHỨC VỤ";
                dtgvNV.Columns[8].Width = 60;

                // Định dạng ngày sinh hiển thị
                dtgvNV.Columns["NGAYSINH"].DefaultCellStyle.Format = "dd/MM/yyyy";
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

                // Đặt màu nền cho hàng lẻ và hàng chẵn nếu muốn
                dtgvNV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 231, 233);
                dtgvNV.RowsDefaultCellStyle.BackColor = Color.FromArgb(235, 230, 255);

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
            if (txtTP.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thành phố nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTP.Focus();
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
            if (!rdNam.Checked && !rdNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
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
        private bool KiemTraMaNV(string maNV)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT COUNT(*) FROM NHANVIEN WHERE MANV = N'" + maNV + "'";
            LopHamXuLy.Connect();
            LopHamXuLy.TruyVan(sql, dt);
            LopHamXuLy.Disconnect();

            if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
            {
                return true;
            }
            return false;
        }

        private void Them()
        {
            if (KiemTraThongTin())
            {
                if (KiemTraMaNV(txtMa.Text))
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMa.Focus();
                    return;
                }
                LopHamXuLy.Connect();
                string gioiTinh = rdNam.Checked ? "Nam" : "Nữ";
                string sqlInsert = "INSERT INTO NHANVIEN(MANV, TENNV, DIACHI, THANHPHO, SDTNV, EMAILNV, NGAYSINH, GIOITINH, CHUCVU) VALUES(N'" + txtMa.Text +
                    "', N'" + txtTen.Text +
                    "', N'" + txtDiaChi.Text +
                    "', N'" + txtTP.Text +
                    "', '" + txtSDT.Text +
                    "', '" + txtEmail.Text + "', '" + DateTime.ParseExact(txtNSinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + 
                    "', N'" + gioiTinh +
                    "', N'" + txtChucVu.Text + "')";
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
                txtDiaChi.Text = row.Cells["DIACHI"].Value.ToString();
                txtTP.Text = row.Cells["THANHPHO"].Value.ToString();
                txtSDT.Text = row.Cells["SDTNV"].Value.ToString();
                txtEmail.Text = row.Cells["EMAILNV"].Value.ToString();
                txtNSinh.Text = DateTime.Parse(row.Cells["NGAYSINH"].Value.ToString()).ToString("dd/MM/yyyy");
                string gioiTinh = row.Cells["GIOITINH"].Value.ToString();
                if (gioiTinh == "Nam")
                {
                    rdNam.Checked = true;
                }
                else
                {
                    rdNu.Checked = true;
                }
                txtChucVu.Text = row.Cells["CHUCVU"].Value.ToString();
            }
        }

        private void QLyNhanVien_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            panelTT.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            ShowNhanVien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            panelTT.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            Reset();
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }
        private void Sua()
        {
            if (KiemTraThongTin())
            {
                LopHamXuLy.Connect();
                string gioiTinh = rdNam.Checked ? "Nam" : "Nữ";
                string sqlUpdate = "UPDATE NHANVIEN SET TENNV = N'" + txtTen.Text +
                                   "', DIACHI = N'" + txtDiaChi.Text +
                                   "', THANHPHO = N'" + txtTP.Text +
                                   "', SDTNV = '" + txtSDT.Text +
                                   "', EMAILNV = '" + txtEmail.Text +
                                   "', NGAYSINH = '" + DateTime.ParseExact(txtNSinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") +
                                   "', GIOITINH = N'" + gioiTinh +
                                   "', CHUCVU = N'" + txtChucVu.Text +
                                   "' WHERE MANV = N'" + txtMa.Text + "'";

                try
                {
                    LopHamXuLy.runSql(sqlUpdate);
                    MessageBox.Show("CẬP NHẬT THÀNH CÔNG", "XÁC NHẬN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowNhanVien();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "LỖI");
                }
                LopHamXuLy.Disconnect();
            }
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
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Form frmM = new frmMenu();
            frmM.Show();
            this.Hide();
        }
        private void Xoa()
        {
            if (txtMa.Text == "")
            {
                MessageBox.Show("BẠN CHƯA CHỌN NHÂN VIÊN CẦN XOÁ", "XÁC NHẬN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            LopHamXuLy.Connect();
            string deleteSql = "DELETE FROM NHANVIEN WHERE MANV='" + txtMa.Text + "'";
            if (MessageBox.Show("BẠN CÓ CHẮC CHẮN MUỐN XOÁ NHÂN VIÊN " + txtTen.Text +" KHÔNG ?", "XÁC NHẬN XOÁ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                LopHamXuLy.runSql(deleteSql);
                MessageBox.Show("ĐÃ XOÁ THÀNH CÔNG NHÂN VIÊN " + txtTen.Text , "XÁC NHẬN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowNhanVien();
                Reset();
            }
            LopHamXuLy.Disconnect();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            Xoa();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Reset();
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            TimKiemNhanVien(txtSearch.Text.Trim());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            panelTT.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtMa.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void TimKiemNhanVien(string tuKhoa)
        {
            DataTable dtTimKiem = new DataTable();
            LopHamXuLy.Connect();
            string sqlTimKiem = "SELECT * FROM NHANVIEN WHERE MANV LIKE N'%" + tuKhoa + "%' OR TENNV LIKE N'%" + tuKhoa +"'";
            if (LopHamXuLy.TruyVan(sqlTimKiem, dtTimKiem))
            {
                // Đặt DataSource cho DataGridView
                dtgvNV.DataSource = dtTimKiem;

                // Đặt tiêu đề và độ rộng cho các cột
                dtgvNV.Columns[0].HeaderText = "MÃ NV";
                dtgvNV.Columns[0].Width = 80;
                dtgvNV.Columns[1].HeaderText = "TÊN NV";
                dtgvNV.Columns[1].Width = 120;
                dtgvNV.Columns[2].HeaderText = "ĐỊA CHỈ ";
                dtgvNV.Columns[2].Width = 120;
                dtgvNV.Columns[3].HeaderText = "THÀNH PHỐ ";
                dtgvNV.Columns[3].Width = 100;
                dtgvNV.Columns[4].HeaderText = "SĐT";
                dtgvNV.Columns[4].Width = 100;
                dtgvNV.Columns[5].HeaderText = "EMAIL";
                dtgvNV.Columns[5].Width = 120;
                dtgvNV.Columns[6].HeaderText = "NGÀY SINH";
                dtgvNV.Columns[6].Width = 100;
                dtgvNV.Columns[7].HeaderText = "GIỚI TÍNH";
                dtgvNV.Columns[7].Width = 60;
                dtgvNV.Columns[8].HeaderText = "CHỨC VỤ";
                dtgvNV.Columns[8].Width = 60;

                // Định dạng ngày sinh hiển thị
                dtgvNV.Columns["NGAYSINH"].DefaultCellStyle.Format = "dd/MM/yyyy";
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

                // Đặt màu nền cho hàng lẻ và hàng chẵn nếu muốn
                dtgvNV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 231, 233);
                dtgvNV.RowsDefaultCellStyle.BackColor = Color.FromArgb(235, 230, 255);

                // Đặt màu nền cho các ô khi được chọn
                dtgvNV.DefaultCellStyle.SelectionBackColor = Color.FromArgb(116, 86, 174);
                dtgvNV.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
            else
            {
                MessageBox.Show("MÃ HOẶC TÊN NHÂN VIÊN KHÔNG CHÍNH XÁC", "XÁC NHẬN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LopHamXuLy.Disconnect();
        }

        private void panelTT_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
