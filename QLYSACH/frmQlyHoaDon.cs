﻿using System;
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
            txtMaNV.Clear();
            txtNLapHD.Clear();
            txtTong.Clear();
            txtMaHD.Focus();
        }
        //Hllo
        private void ShowHoaDon()
        {
            DataTable dthoadon = new DataTable();
            LopHamXuLy.Connect();
            string sqlHoadon = "SELECT * FROM HOADONXUAT";
            if (LopHamXuLy.TruyVan(sqlHoadon, dthoadon))
            {
                // Đặt DataSource cho DataGridView
                dtgvHD.DataSource = dthoadon;

                // Đặt tiêu đề và độ rộng cho các cột
                dtgvHD.Columns[0].HeaderText = "MÃ HOÁ ĐƠN";
                dtgvHD.Columns[0].Width = 150;
                dtgvHD.Columns[1].HeaderText = "MÃ NHÂN VIÊN";
                dtgvHD.Columns[1].Width = 150;
                dtgvHD.Columns[2].HeaderText = "MÃ KHÁCH HÀNG";
                dtgvHD.Columns[2].Width = 150;
                dtgvHD.Columns[3].HeaderText = "NGÀY LẬP HOÁ ĐƠN";
                dtgvHD.Columns[3].Width = 200;
                dtgvHD.Columns[4].HeaderText = "TỔNG TIỀN";
                dtgvHD.Columns[4].Width = 200;

                // Định dạng ngày lập hóa đơn hiển thị
                dtgvHD.Columns["NGAYXUAT"].DefaultCellStyle.Format = "dd/MM/yyyy";

                // Định dạng tiền tệ cho cột tổng tiền
                dtgvHD.Columns["THANHTIEN"].DefaultCellStyle.Format = "c";
                dtgvHD.Columns["THANHTIEN"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("vi-VN");

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
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
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
        //Kiểm tra mã hoá đơn
        private bool KiemTraMaHD(string maHD)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT COUNT(*) FROM HOADONXUAT WHERE MAHDX = N'" + maHD + "'";
            LopHamXuLy.Connect();
            LopHamXuLy.TruyVan(sql, dt);
            LopHamXuLy.Disconnect();

            if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
            {
                return true;
            }
            return false;
        }

        private void dtgvHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvHD.Rows[e.RowIndex];
                txtMaHD.Text = row.Cells["MAHDX"].Value.ToString();
                txtMaNV.Text = row.Cells["MANV"].Value.ToString();
                txtMaKH.Text = row.Cells["MAKH"].Value.ToString();
                txtTong.Text = row.Cells["THANHTIEN"].Value.ToString();
                txtNLapHD.Text = DateTime.Parse(row.Cells["NGAYXUAT"].Value.ToString()).ToString("dd/MM/yyyy");
            }
        }

        private void frmQlyHoaDon_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            panelTT.Enabled = false;
            ShowHoaDon();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Them()
        {
            if (KiemTraThongTin())
            {
                if (KiemTraMaHD(txtMaHD.Text))
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaHD.Focus();
                    return;
                }
                LopHamXuLy.Connect();
                string sqlInsert = "INSERT INTO HOADONXUAT(MAHDX, MAKH, MANV, NGAYXUAT, THANHTIEN) VALUES(N'" + txtMaHD.Text +
                                    "', N'" + txtMaKH.Text +
                                    "', N'" + txtMaNV.Text +
                                    "', '" + DateTime.ParseExact(txtNLapHD.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") +
                                    "', '" + txtTong.Text + "')";
                try
                {
                    LopHamXuLy.runSql(sqlInsert);
                    MessageBox.Show("THÊM THÀNH CÔNG", "XÁC NHẬN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowHoaDon();
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
            // Kiểm tra thông tin nhập vào trước khi cập nhật
            if (KiemTraThongTin())
            {
                // Kết nối đến cơ sở dữ liệu
                LopHamXuLy.Connect();
                // Chuẩn bị câu lệnh SQL để cập nhật hóa đơn
                string sqlUpdate = "UPDATE HOADONXUAT SET MANV = N'" + txtMaNV.Text +
                                   "', MAKH = N'" + txtMaKH.Text +
                                   "', NGAYXUAT = '" + DateTime.ParseExact(txtNLapHD.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") +
                                   "', THANHTIEN = '" + txtTong.Text +
                                   "' WHERE MAHDX = N'" + txtMaHD.Text + "'";

                try
                {
                    // Thực thi câu lệnh SQL để cập nhật hóa đơn
                    LopHamXuLy.runSql(sqlUpdate);

                    // Hiển thị thông báo thành công và cập nhật lại danh sách hóa đơn
                    MessageBox.Show("CẬP NHẬT THÀNH CÔNG", "XÁC NHẬN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowHoaDon(); // Hàm này cần được tạo để hiển thị danh sách hóa đơn
                    Reset(); // Hàm này cần được tạo để xóa trắng các trường nhập liệu
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                    MessageBox.Show(ex.Message, "LỖI");
                }

                // Ngắt kết nối cơ sở dữ liệu
                LopHamXuLy.Disconnect();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            panelTT.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtMaHD.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
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
            btnThem.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text == "")
            {
                MessageBox.Show("BẠN CHƯA CHỌN HOÁ ĐƠN CẦN XOÁ", "XÁC NHẬN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            LopHamXuLy.Connect();
            string deleteSql = "DELETE FROM HOADONXUAT WHERE MAHDX='" + txtMaHD.Text + "'";
            if (MessageBox.Show("BẠN CÓ CHẮC CHẮN MUỐN XOÁ HOÁ ĐƠN " + txtMaHD.Text + " KHÔNG ?", "XÁC NHẬN XOÁ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                LopHamXuLy.runSql(deleteSql);
                MessageBox.Show("ĐÃ XOÁ THÀNH CÔNG HOÁ ĐƠN " + txtMaHD.Text, "XÁC NHẬN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowHoaDon();
                Reset();
            }
            LopHamXuLy.Disconnect();
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
                string sqlTimKiem = "SELECT * FROM HOADONXUAT";
                string dk = "";

                // Tìm theo MaSP khác rỗng
                if (txtTimMa.Text.Trim() != "")
                {
                    dk += " MaHDX LIKE '%" + txtTimMa.Text + "%'";
                }

                // Kiểm tra TenSP và MaSP khác rỗng
                if (txtTimTen.Text.Trim() != "" && dk != "")
                {
                    dk += " AND MAKH LIKE N'%" + txtTimTen.Text + "%'";
                }

                // Tìm kiếm theo TenSP khi MaSP là rỗng
                if (txtTimTen.Text.Trim() != "" && dk == "")
                {
                    dk += " MAKH LIKE N'%" + txtTimTen.Text + "%'";
                }

                // Kết hợp điều kiện
                if (dk != "")
                {
                    sqlTimKiem += " WHERE" + dk;
                }
                LopHamXuLy.LoadDuLieu(sqlTimKiem, dtgvHD);
            }
        }
    }
}
