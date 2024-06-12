using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace QLYSACH
{
    class LopHamXuLy
    {
        // Đối tượng kết nối
        public static SqlConnection conn;

        // Phương thức để kết nối đến cơ sở dữ liệu
        public static void Connect()
        {
            // Khởi tạo đối tượng kết nối
            conn = new SqlConnection();
            // Thiết lập chuỗi kết nối
            conn.ConnectionString = @"Data Source=DESKTOP-QVLRGRF\VUDUY;Initial Catalog=QLYSACH;Integrated Security=True";
            // Mở kết nối
            conn.Open();
        }

        // Phương thức để ngắt kết nối đến cơ sở dữ liệu
        public static void Disconnect()
        {
            // Kiểm tra trạng thái kết nối
            if (conn.State == ConnectionState.Open)
            {
                // Đóng kết nối
                conn.Close();
                // Giải phóng tài nguyên
                conn.Dispose();
                // Gán giá trị null cho đối tượng kết nối
                conn = null;
            }
        }

        // Phương thức để thực hiện truy vấn và điền dữ liệu vào DataTable
        public static Boolean TruyVan(string strSQL, DataTable dt)
        {
            // Biến kết quả
            Boolean kq = false;
            // Khai báo đối tượng SqlDataAdapter để thực hiện truy vấn
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            try
            {
                // Điền dữ liệu từ SqlDataAdapter vào DataTable
                da.Fill(dt);
                // Nếu có ít nhất một hàng dữ liệu được trả về, gán kết quả là true
                if (dt.Rows.Count != 0)
                {
                    kq = true;
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có ngoại lệ xảy ra
                MessageBox.Show(ex.Message, "Thông Báo");
            }
            // Trả về kết quả
            return kq;
        }

        public static void runSql(string sql)
        {
            // Đảm bảo kết nối được thiết lập trước khi thực thi lệnh SQL
            if (conn == null || conn.State == ConnectionState.Closed)
            {
                Connect();
            }

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = LopHamXuLy.conn;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }

        public static void FillComboBox(string sql, string ma, string ten, ComboBox cbo)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbo.DataSource = dt;
            cbo.ValueMember = ma;
            cbo.DisplayMember = ten;
        }

        public static string GetFieldValue(string sql)
        {
            Connect();
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ma = reader.GetValue(0).ToString();
            }
            reader.Close();
            Disconnect(); // Di chuyển Disconnect() ra ngoài câu lệnh return
            return ma;
        }

        public static void FillComboBoxTK(string sql, string nhom, ComboBox cbo)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbo.DataSource = dt;
            cbo.ValueMember = nhom;
            cbo.DisplayMember = nhom;
        }

        // Phương thức để thực hiện truy vấn không trả về kết quả
        public static bool ThucThi(string strSQL)
        {
            bool result = false;
            try
            {
                // Đảm bảo kết nối được thiết lập trước khi thực thi lệnh SQL
                if (conn == null || conn.State == ConnectionState.Closed)
                {
                    Connect();
                }

                // Khởi tạo đối tượng SqlCommand để thực hiện truy vấn
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                // Thực thi truy vấn
                cmd.ExecuteNonQuery();
                // Đặt kết quả là true nếu thực hiện thành công
                result = true;
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có ngoại lệ xảy ra
                MessageBox.Show(ex.Message, "Thông Báo");
            }
            return result;
        }
    }
}
