using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLYSACH
{
    public partial class frmQlyHoaDon : Form
    {
        public frmQlyHoaDon()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            txtMaKH.Clear();
            txtMaHD.Clear();
            txtNLapHD.Clear();
            txtTong.Clear();
            txtMaHD.Focus();
        }
        private void ShowHoaDon()
        {
            DataTable dthoadon = new DataTable();
            LopHamXuLy.Connect();
            string sqlHoadon = "SELECT * FROM HOADON";
            if (LopHamXuLy.TruyVan(sqlHoadon, dthoadon))
            {
                // Đặt DataSource cho DataGridView
                dtgvHD.DataSource = dthoadon;

                // Đặt tiêu đề và độ rộng cho các cột
                dtgvHD.Columns[0].HeaderText = "MÃ HOÁ ĐƠN";
                dtgvHD.Columns[0].Width = 100;
                dtgvHD.Columns[1].HeaderText = "MÃ NHÂN VIÊN";
                dtgvHD.Columns[1].Width = 100;
                dtgvHD.Columns[2].HeaderText = "MÃ KHÁCH HÀNG";
                dtgvHD.Columns[2].Width = 100;
                dtgvHD.Columns[3].HeaderText = "NGÀY LẬP HOÁ ĐƠN";
                dtgvHD.Columns[3].Width = 120;
                dtgvHD.Columns[4].HeaderText = "TỔNG TIỀN";
                dtgvHD.Columns[4].Width = 100;

                // Định dạng ngày sinh hiển thị
                dtgvHD.Columns["NGAYLAPHD"].DefaultCellStyle.Format = "dd/MM/yyyy";
                // Thiết lập kiểu hiển thị cho header
                dtgvHD.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(116, 86, 174);
                dtgvHD.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dtgvHD.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10, FontStyle.Regular);

                // Đặt nền cho DataGridView
                dtgvHD.BackgroundColor = Color.FromArgb(235, 230, 255);

                // Loại bỏ border giữa các hàng
                dtgvHD.CellBorderStyle = DataGridViewCellBorderStyle.None;

                // Đặt màu nền cho các ô khi được chọn
                dtgvHD.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 230, 255);

                // Đặt font chữ và màu nền cho các ô
                dtgvHD.DefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10, FontStyle.Regular);
                dtgvHD.DefaultCellStyle.BackColor = Color.FromArgb(230, 231, 233);

                // Loại bỏ kiểu mặc định của header
                dtgvHD.EnableHeadersVisualStyles = false;

                // Đặt màu nền cho các ô không được chọn
                dtgvHD.DefaultCellStyle.BackColor = Color.FromArgb(230, 231, 233);
                dtgvHD.DefaultCellStyle.ForeColor = Color.Black;

                // Đặt màu nền cho hàng lẻ và hàng chẵn nếu muốn
                dtgvHD.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 231, 233);
                dtgvHD.RowsDefaultCellStyle.BackColor = Color.FromArgb(235, 230, 255);

                // Đặt màu nền cho các ô khi được chọn
                dtgvHD.DefaultCellStyle.SelectionBackColor = Color.FromArgb(116, 86, 174);
                dtgvHD.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }
        public bool KiemTraThongTin()
        {
            // Kiểm tra mã 
            if (txtMaHD.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã hoá đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHD.Focus();
                return false;
            }

            // Kiểm tra tên 
            if (cboNV.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNV.Focus();
                return false;
            }

            // Kiểm tra ngày sinh
            if (txtNLapHD.Text == "")
            {
                MessageBox.Show("Vui lòng nhập ngày lập hoá đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNLapHD.Focus();
                return false;
            }
            else
            {
                string errorMessage;
                if (!IsValidDateOfBirth(txtNLapHD.Text, out errorMessage))
                {
                    MessageBox.Show(errorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNLapHD.Focus();
                    return false;
                }
            }
            float tongtien;
            if (txtTong.Text == "" || !float.TryParse(txtTong.Text, out tongtien))
            {
                MessageBox.Show("Vui lòng nhập tổng tiền hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTong.Focus();
                return false;
            }
            return true;
        }

        // Hàm kiểm tra ngày sinh
        private bool IsValidDateOfBirth(string dateOfBirth, out string errorMessage)
        {
            errorMessage = string.Empty;
            DateTime dob;

            // Kiểm tra định dạng ngày sinh (định dạng dd/MM/yyyy)
            if (!DateTime.TryParseExact(dateOfBirth, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
            {
                errorMessage = "Định dạng ngày lập hoá đơn không hợp lệ. Vui lòng nhập theo định dạng dd/MM/yyyy.";
                return false;
            }
            // Kiểm tra nếu ngày sinh là một ngày trong tương lai
            if (dob > DateTime.Now)
            {
                errorMessage = "Ngày lập hoá đơn không được là một ngày trong tương lai.";
                return false;
            }

            return true;
        }

        private void dtgvHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvHD.Rows[e.RowIndex];
                txtMaHD.Text = row.Cells["MAHD"].Value.ToString();
                txtMaKH.Text = row.Cells["MAKH"].Value.ToString();
                txtTong.Text = row.Cells["TONGTIEN"].Value.ToString();
                txtNLapHD.Text = DateTime.Parse(row.Cells["NGAYLAPHD"].Value.ToString()).ToString("dd/MM/yyyy");
                string MaNV = row.Cells["MANV"].Value.ToString();
                string sql = "SELECT TENNV FROM CHATLIEU WHERE MANV=N'" + MaNV + "'";
                cboNV.Text = LopHamXuLy.GetFieldValue(sql);
            }
        }

        private void frmQlyHoaDon_Load(object sender, EventArgs e)
        {
            panelTT.Enabled = false;
            ShowHoaDon();
            string sql = "SELECT * FROM NHANVIEN";
            LopHamXuLy.FillComboBox(sql, "MANV", "TENNV", cboNV);
        }
    }
}
