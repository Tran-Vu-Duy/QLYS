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
using System.Data.SqlClient;

namespace QLYSACH
{
    public partial class frmQlyKhachHang : Form
    {
        public static SqlConnection conn;
        public frmQlyKhachHang()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtThanhPho.Clear();
            txtSDT.Clear();
            txtNgSinh.Clear();
            rdNam.Checked = false;
            rdNu.Checked = false;
            txtMa.Focus();
        }
        private void ShowKhachHang()
        {
            DataTable dtkhachhang = new DataTable();
            LopHamXuLy.Connect();
            string sqlKhachHang = "SELECT * FROM KhachHang";
            if (LopHamXuLy.TruyVan(sqlKhachHang, dtkhachhang))
            {
                // Đặt DataSource cho DataGridView
                dtgvKH.DataSource = dtkhachhang;

                // Đặt tiêu đề và độ rộng cho các cột
                dtgvKH.Columns[0].HeaderText = "MÃ";
                dtgvKH.Columns[0].Width = 80;
                dtgvKH.Columns[1].HeaderText = "HỌ TÊN";
                dtgvKH.Columns[1].Width = 120;
                dtgvKH.Columns[2].HeaderText = "ĐỊA CHỈ ";
                dtgvKH.Columns[2].Width = 120;
                dtgvKH.Columns[3].HeaderText = "THÀNH PHỐ ";
                dtgvKH.Columns[3].Width = 100;
                dtgvKH.Columns[4].HeaderText = "SĐT";
                dtgvKH.Columns[4].Width = 100;
                dtgvKH.Columns[5].HeaderText = "EMAIL";
                dtgvKH.Columns[5].Width = 120;
                dtgvKH.Columns[6].HeaderText = "NGÀY SINH";
                dtgvKH.Columns[6].Width = 100;
                dtgvKH.Columns[7].HeaderText = "GIỚI TÍNH";
                dtgvKH.Columns[7].Width = 60;  

                // Định dạng ngày sinh hiển thị
                dtgvKH.Columns["NGAYSINH"].DefaultCellStyle.Format = "dd/MM/yyyy";
                // Thiết lập kiểu hiển thị cho header
                dtgvKH.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(116, 86, 174);
                dtgvKH.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dtgvKH.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10, FontStyle.Regular);

                // Đặt nền cho DataGridView
                dtgvKH.BackgroundColor = Color.FromArgb(235, 230, 255);

                // Loại bỏ border giữa các hàng
                dtgvKH.CellBorderStyle = DataGridViewCellBorderStyle.None;

                // Đặt màu nền cho các ô khi được chọn
                dtgvKH.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 230, 255);

                // Đặt font chữ và màu nền cho các ô
                dtgvKH.DefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10, FontStyle.Regular);
                dtgvKH.DefaultCellStyle.BackColor = Color.FromArgb(230, 231, 233);

                // Loại bỏ kiểu mặc định của header
                dtgvKH.EnableHeadersVisualStyles = false;

                // Đặt màu nền cho các ô không được chọn
                dtgvKH.DefaultCellStyle.BackColor = Color.FromArgb(230, 231, 233);
                dtgvKH.DefaultCellStyle.ForeColor = Color.Black;

                // Đặt màu nền cho hàng lẻ và hàng chẵn nếu muốn
                dtgvKH.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 231, 233);
                dtgvKH.RowsDefaultCellStyle.BackColor = Color.FromArgb(235, 230, 255);

                // Đặt màu nền cho các ô khi được chọn
                dtgvKH.DefaultCellStyle.SelectionBackColor = Color.FromArgb(116, 86, 174);
                dtgvKH.DefaultCellStyle.SelectionForeColor = Color.Black;
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
                MessageBox.Show("Vui lòng nhập địa chỉ khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return false;
            }
            if (txtThanhPho.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thành phố khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtThanhPho.Focus();
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
            if (txtNgSinh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập ngày sinh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgSinh.Focus();
                return false;
            }
            else
            {
                string errorMessage;
                if (!IsValidDateOfBirth(txtNgSinh.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgSinh.Focus();
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
        private bool KiemTraMaKH(string maKH)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT COUNT(*) FROM KhachHang WHERE MaKH = N'" + maKH + "'";
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
                if (KiemTraMaKH(txtMa.Text))
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMa.Focus();
                    return;
                }
                LopHamXuLy.Connect();
                string gioiTinh = rdNam.Checked ? "Nam" : "Nữ";
                string sqlInsert = "INSERT INTO KhachHang(MaKH, TenKH, DIACHI, THANHPHO, SDTKH, EMAILKH, NGAYSINH, GIOITINH) VALUES(N'" + txtMa.Text +
                    "', N'" + txtTen.Text +
                    "', N'" + txtDiaChi.Text +
                    "', N'" + txtThanhPho.Text +
                    "', '" + txtSDT.Text +
                    "', '" + txtEmail.Text + "', '" + DateTime.ParseExact(txtNgSinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") +
                    "', N'" + gioiTinh + "')";
                try
                {
                    LopHamXuLy.runSql(sqlInsert);
                    MessageBox.Show("THÊM THÀNH CÔNG KHÁCH HÀNG " + txtTen.Text, "XÁC NHẬN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowKhachHang();
                    Reset();
                    btSua.Enabled = true;
                    btXoa.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "LỖI");
                }
                LopHamXuLy.Disconnect();
            }
        }
        private void Sua()
        {
            if (KiemTraThongTin())
            {
                LopHamXuLy.Connect();
                string gioiTinh = rdNam.Checked ? "Nam" : "Nữ";
                string sqlUpdate = "UPDATE KhachHang SET TenKH = N'" + txtTen.Text +
                                   "', DIACHI = N'" + txtDiaChi.Text +
                                   "', THANHPHO = N'" + txtThanhPho.Text +
                                   "', SDTKH = '" + txtSDT.Text +
                                   "', EMAILKH = '" + txtEmail.Text +
                                   "', NGAYSINH = '" + DateTime.ParseExact(txtNgSinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") +
                                   "', GIOITINH = N'" + gioiTinh +
                                   "' WHERE MaKH = N'" + txtMa.Text + "'";

                try
                {
                    LopHamXuLy.runSql(sqlUpdate);
                    MessageBox.Show("CẬP NHẬT THÀNH CÔNG KHÁCH HÀNG " + txtTen.Text, "XÁC NHẬN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowKhachHang();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "LỖI");
                }
                LopHamXuLy.Disconnect();
            }
        }

        private void frmQlyKhachHang_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            panelTT.Enabled = false;
            btHuy.Enabled = false;
            btLuu.Enabled = false;
            ShowKhachHang();

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            panelTT.Enabled = true;
            btLuu.Enabled = true;
            btHuy.Enabled = true;
            Reset();
            btXoa.Enabled = false;
            btSua.Enabled = false;
        }
        private void btLuu_Click(object sender, EventArgs e)
        {

            if (btThem.Enabled)
            {
                Them();
            }
            else
            {
                Sua();
            }
            btHuy.Enabled = false;
            btLuu.Enabled = false;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Form frmKH = new frmMenu();
            frmKH.Show();
            this.Close();
        }
        private void Xoa()
        {
            if (txtMa.Text == "")
            {
                MessageBox.Show("BẠN CHƯA CHỌN KHÁCH HÀNG CẦN XOÁ", "XÁC NHẬN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            LopHamXuLy.Connect();
            string deleteSql = "DELETE FROM KhachHang WHERE MaKH='" + txtMa.Text + "'";
            if (MessageBox.Show("BẠN CÓ CHẮC CHẮN MUỐN XOÁ KHÁCH HÀNG " + txtTen.Text + " KHÔNG ?", "XÁC NHẬN XOÁ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                LopHamXuLy.runSql(deleteSql);
                MessageBox.Show("ĐÃ XOÁ THÀNH CÔNG KHÁCH HÀNG " + txtTen.Text, "XÁC NHẬN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowKhachHang();
                Reset();
            }
            LopHamXuLy.Disconnect();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            Xoa();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Reset();
            panelTT.Enabled = false;
            btThem.Enabled = true;
            btXoa.Enabled = true;
            btSua.Enabled = true;
            txtMa.Enabled = true;
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            panelTT.Enabled = true;
            btLuu.Enabled = true;
            btHuy.Enabled = true;
            txtMa.Enabled = false;
            btThem.Enabled = false;
            btXoa.Enabled = false;
        }

        private void dtgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvKH.Rows[e.RowIndex];
                txtMa.Text = row.Cells["MaKH"].Value.ToString();
                txtTen.Text = row.Cells["TenKH"].Value.ToString();
                txtDiaChi.Text = row.Cells["DIACHI"].Value.ToString();
                txtThanhPho.Text = row.Cells["THANHPHO"].Value.ToString();
                txtSDT.Text = row.Cells["SDTKH"].Value.ToString();
                txtEmail.Text = row.Cells["EMAILKH"].Value.ToString();
                txtNgSinh.Text = DateTime.Parse(row.Cells["NGAYSINH"].Value.ToString()).ToString("dd/MM/yyyy");
                string gioiTinh = row.Cells["GIOITINH"].Value.ToString();
                if (gioiTinh == "Nam")
                {
                    rdNam.Checked = true;
                }
                else
                {
                    rdNu.Checked = true;
                }
            }
        }
        private void LoadDuLieu(string sql)
        {
            try
            {
                // Khởi tạo đối tượng DataSet
                DataSet ds = new DataSet();

                // Kiểm tra kết nối trước khi tạo DataAdapter
                if (conn == null)
                {
                    conn = new SqlConnection();
                    conn.ConnectionString = "Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=QLYSACH;Integrated Security=True";
                    conn.Open();
                }
                // Khởi tạo đối tượng DataAdapter và cung cấp câu lệnh SQL cùng đối tượng Connection
                SqlDataAdapter dap = new SqlDataAdapter(sql, conn);

                // Dùng phương thức Fill của DataAdapter để đổ dữ liệu từ DataSource tới DataSet
                dap.Fill(ds);

                // Gắn dữ liệu từ DataSet lên DataGridView
                dtgvKH.DataSource = ds.Tables[0];
            }
            catch (SqlException ex)
            {
                // Xử lý lỗi SQL
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                MessageBox.Show("Lỗi: " + ex.Message);
            }
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
                string sqlTimKiem = "SELECT * FROM KhachHang";
                string dk = "";

                // Tìm theo MaSP khác rỗng
                if (txtTimMa.Text.Trim() != "")
                {
                    dk += " MaKH LIKE '%" + txtTimMa.Text + "%'";
                }

                // Kiểm tra TenSP và MaSP khác rỗng
                if (txtTimTen.Text.Trim() != "" && dk != "")
                {
                    dk += " AND TenKH LIKE N'%" + txtTimTen.Text + "%'";
                }

                // Tìm kiếm theo TenSP khi MaSP là rỗng
                if (txtTimTen.Text.Trim() != "" && dk == "")
                {
                    dk += " TenKH LIKE N'%" + txtTimTen.Text + "%'";
                }

                // Kết hợp điều kiện
                if (dk != "")
                {
                    sqlTimKiem += " WHERE" + dk;
                }
                LoadDuLieu(sqlTimKiem);
            }

        }

        private void btHuyTim_Click(object sender, EventArgs e)
        {
            txtTimMa.Clear();
            txtTimTen.Clear();
            ShowKhachHang();
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            Reset();
            btHuy.Enabled = false;
            btLuu.Enabled = false;
            btSua.Enabled = true;
            btThem.Enabled = true;
        }
        
    }
    
}
