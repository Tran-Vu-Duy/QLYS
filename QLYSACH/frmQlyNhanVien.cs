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
            rdNam.Checked = false;
            rdNu.Checked = false;
            txtMa.Focus();
        }
        private void ShowNhanVien()
        {
            DataTable dtnhanvien = new DataTable();
            LopHamXuLy.Connect();
            string sqlNhanVien = "SELECT * FROM NHANVIEN";
            if (LopHamXuLy.TruyVan(sqlNhanVien, dtnhanvien))
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

                // Gắn sự kiện CellFormatting
                dtgvNV.CellFormatting += DtgvNV_CellFormatting;
            }
        }
        private void DtgvNV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgvNV.Columns[e.ColumnIndex].Name == "TENNV" && e.Value != null)
            {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }
        public bool KiemTraThongTin()
        {
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
                string newMaNV = TaoMoiMaNV();
                if (KiemTraMaNV(newMaNV))
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMa.Focus();
                    return;
                }
                LopHamXuLy.Connect();
                string gioiTinh = rdNam.Checked ? "Nam" : "Nữ";
                string sqlInsert = "INSERT INTO NHANVIEN(MANV, TENNV, DIACHI, THANHPHO, SDTNV, EMAILNV, NGAYSINH, GIOITINH, CHUCVU) VALUES(N'" + newMaNV +
                    "', N'" + txtTen.Text +
                    "', N'" + txtDiaChi.Text +
                    "', N'" + txtTP.Text +
                    "', '" + txtSDT.Text +
                    "', '" + txtEmail.Text + "', '" + DateTime.ParseExact(txtNSinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + 
                    "', N'" + gioiTinh +
                    "', N'" + cboChucVu.SelectedValue.ToString() + "')";
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
                string ChucVu = row.Cells["CHUCVU"].Value.ToString();
                string sql = "SELECT CHUCVU FROM NHANVIEN WHERE MANV=N'" + ChucVu + "'";
                cboChucVu.Text = LopHamXuLy.GetFieldValue(sql);
            }
        }

        private void QLyNhanVien_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            panelTT.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            ShowNhanVien();
            string sql = "SELECT DISTINCT CHUCVU FROM NHANVIEN";
            LopHamXuLy.FillComboBox(sql,"CHUCVU", "CHUCVU", cboChucVu);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            panelTT.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtMa.Enabled = false;
            txtMa.Text = TaoMoiMaNV();
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
                                   "', CHUCVU = N'" + cboChucVu.SelectedValue.ToString() +
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
            this.Close();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            panelTT.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;     
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            if(txtMa.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                txtMa.Enabled = false;
                txtTen.Focus();
            }
        }

        private void panelTT_Paint(object sender, PaintEventArgs e)
        {

        }
        private Boolean KiemTraNhap()
        {
            if (txtTimMa.Text == "" && txtTimTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Mã hoặc Tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
        private void btTim_Click(object sender, EventArgs e)
        {
            if (KiemTraNhap())
            {
                LopHamXuLy.Connect();
                string sqlTimKiem = "SELECT * FROM NHANVIEN";
                string dk = "";

                // Tìm theo MaSP khác rỗng
                if (txtTimMa.Text.Trim() != "")
                {
                    dk += " MaNV LIKE '%" + txtTimMa.Text + "%'";
                }

                // Kiểm tra TenSP và MaSP khác rỗng
                if (txtTimTen.Text.Trim() != "" && dk != "")
                {
                    dk += " AND TENNV LIKE N'%" + txtTimTen.Text + "%'";
                }

                // Tìm kiếm theo TenSP khi MaSP là rỗng
                if (txtTimTen.Text.Trim() != "" && dk == "")
                {
                    dk += " TENNV LIKE N'%" + txtTimTen.Text + "%'";
                }

                // Kết hợp điều kiện
                if (dk != "")
                {
                    sqlTimKiem += " WHERE" + dk;
                }
                LopHamXuLy.LoadDuLieu(sqlTimKiem, dtgvNV);
            }
        }

        private void rdQL_CheckedChanged(object sender, EventArgs e)
        {
            LopHamXuLy.Connect();
            string sqlLocQl = "SELECT * FROM NHANVIEN";
            string dk = "";

            if (rdQL.Checked)
            {
                dk += " CHUCVU = N'Quản Lý' ";
            }

            if (!string.IsNullOrWhiteSpace(dk))
            {
                sqlLocQl += " WHERE " + dk;
            }
            LopHamXuLy.LoadDuLieu(sqlLocQl, dtgvNV);
            LopHamXuLy.Disconnect();   
        }

        private void rdNV_CheckedChanged(object sender, EventArgs e)
        {
            LopHamXuLy.Connect();
            string sqlLocNV = "SELECT * FROM NHANVIEN";
            string dk1 = "";

            if (rdNV.Checked)
            {
                dk1 += " CHUCVU = N'Nhân Viên' ";
            }

            if (!string.IsNullOrWhiteSpace(dk1))
            {
                sqlLocNV += " WHERE " + dk1;
            }
            LopHamXuLy.LoadDuLieu(sqlLocNV, dtgvNV);
            LopHamXuLy.Disconnect();
        }

        private void rdAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAll.Checked)
            {
                ShowNhanVien();
            }
        }

        private void cboChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private string TaoMoiMaNV()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT MANV FROM NHANVIEN ORDER BY MANV DESC";
            LopHamXuLy.Connect();
            LopHamXuLy.TruyVan(sql, dt);
            LopHamXuLy.Disconnect();

            if (dt.Rows.Count > 0)
            {
                string lastMaNV = dt.Rows[0]["MANV"].ToString();
                string kytudau = lastMaNV.Substring(0, 2);
                int macuoi = int.Parse(lastMaNV.Substring(2));
                int mamoi = macuoi + 1;
                return kytudau + mamoi.ToString("D3"); // Tăng số và định dạng thành 3 chữ số
            }
            else
            {
                return "NV001"; // Mã nhân viên mặc định nếu không có nhân viên nào
            }
        }

    }
}
