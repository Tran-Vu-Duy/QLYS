namespace QLYSACH
{
    partial class frmQLyNhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelNV = new System.Windows.Forms.Panel();
            this.dtgvNV = new System.Windows.Forms.DataGridView();
            this.panelTT = new System.Windows.Forms.Panel();
            this.txtNSinh = new System.Windows.Forms.MaskedTextBox();
            this.rdNam = new System.Windows.Forms.RadioButton();
            this.rdNu = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTP = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.cboChucVu = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdAll = new System.Windows.Forms.RadioButton();
            this.rdNV = new System.Windows.Forms.RadioButton();
            this.rdQL = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btHuyTim = new System.Windows.Forms.Button();
            this.btTim = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtTimMa = new System.Windows.Forms.TextBox();
            this.txtTimTen = new System.Windows.Forms.TextBox();
            this.panelNV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvNV)).BeginInit();
            this.panelTT.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelNV
            // 
            this.panelNV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.panelNV.Controls.Add(this.dtgvNV);
            this.panelNV.Location = new System.Drawing.Point(12, 113);
            this.panelNV.Name = "panelNV";
            this.panelNV.Size = new System.Drawing.Size(912, 393);
            this.panelNV.TabIndex = 12;
            // 
            // dtgvNV
            // 
            this.dtgvNV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvNV.Location = new System.Drawing.Point(0, 0);
            this.dtgvNV.Name = "dtgvNV";
            this.dtgvNV.RowTemplate.Height = 24;
            this.dtgvNV.Size = new System.Drawing.Size(902, 380);
            this.dtgvNV.TabIndex = 0;
            this.dtgvNV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvNV_CellClick);
            this.dtgvNV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DtgvNV_CellFormatting);
            // 
            // panelTT
            // 
            this.panelTT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.panelTT.Controls.Add(this.cboChucVu);
            this.panelTT.Controls.Add(this.txtNSinh);
            this.panelTT.Controls.Add(this.rdNam);
            this.panelTT.Controls.Add(this.rdNu);
            this.panelTT.Controls.Add(this.label16);
            this.panelTT.Controls.Add(this.label11);
            this.panelTT.Controls.Add(this.label9);
            this.panelTT.Controls.Add(this.label8);
            this.panelTT.Controls.Add(this.txtSDT);
            this.panelTT.Controls.Add(this.label7);
            this.panelTT.Controls.Add(this.txtEmail);
            this.panelTT.Controls.Add(this.label19);
            this.panelTT.Controls.Add(this.label6);
            this.panelTT.Controls.Add(this.txtTen);
            this.panelTT.Controls.Add(this.label5);
            this.panelTT.Controls.Add(this.txtMa);
            this.panelTT.Controls.Add(this.label4);
            this.panelTT.Controls.Add(this.txtTP);
            this.panelTT.Controls.Add(this.txtDiaChi);
            this.panelTT.Location = new System.Drawing.Point(930, 114);
            this.panelTT.Name = "panelTT";
            this.panelTT.Size = new System.Drawing.Size(423, 524);
            this.panelTT.TabIndex = 13;
            this.panelTT.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTT_Paint);
            // 
            // txtNSinh
            // 
            this.txtNSinh.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNSinh.Location = new System.Drawing.Point(57, 468);
            this.txtNSinh.Mask = "00/00/0000";
            this.txtNSinh.Name = "txtNSinh";
            this.txtNSinh.Size = new System.Drawing.Size(336, 35);
            this.txtNSinh.TabIndex = 12;
            // 
            // rdNam
            // 
            this.rdNam.AutoSize = true;
            this.rdNam.ForeColor = System.Drawing.Color.White;
            this.rdNam.Location = new System.Drawing.Point(322, 159);
            this.rdNam.Name = "rdNam";
            this.rdNam.Size = new System.Drawing.Size(71, 26);
            this.rdNam.TabIndex = 7;
            this.rdNam.TabStop = true;
            this.rdNam.Text = "Nam";
            this.rdNam.UseVisualStyleBackColor = true;
            // 
            // rdNu
            // 
            this.rdNu.AutoSize = true;
            this.rdNu.ForeColor = System.Drawing.Color.White;
            this.rdNu.Location = new System.Drawing.Point(202, 161);
            this.rdNu.Name = "rdNu";
            this.rdNu.Size = new System.Drawing.Size(55, 26);
            this.rdNu.TabIndex = 6;
            this.rdNu.TabStop = true;
            this.rdNu.Text = "Nữ";
            this.rdNu.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(53, 163);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 22);
            this.label16.TabIndex = 14;
            this.label16.Text = "Giới Tính :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(174, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 22);
            this.label11.TabIndex = 13;
            this.label11.Text = "Chức Vụ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(53, 440);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 22);
            this.label9.TabIndex = 11;
            this.label9.Text = "Ngày Sinh";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(53, 361);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 22);
            this.label8.TabIndex = 9;
            this.label8.Text = "Số Điện Thoại";
            // 
            // txtSDT
            // 
            this.txtSDT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSDT.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(57, 386);
            this.txtSDT.Multiline = true;
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(336, 36);
            this.txtSDT.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(53, 288);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 22);
            this.label7.TabIndex = 7;
            this.label7.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(57, 313);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(336, 36);
            this.txtEmail.TabIndex = 10;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(259, 203);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 22);
            this.label19.TabIndex = 5;
            this.label19.Text = "Thành Phố";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(53, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "Địa Chỉ";
            // 
            // txtTen
            // 
            this.txtTen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTen.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(57, 114);
            this.txtTen.Multiline = true;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(336, 36);
            this.txtTen.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(53, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 22);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mã ";
            // 
            // txtMa
            // 
            this.txtMa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMa.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa.Location = new System.Drawing.Point(57, 39);
            this.txtMa.Multiline = true;
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(115, 36);
            this.txtMa.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(53, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 22);
            this.label4.TabIndex = 1;
            this.label4.Text = "Họ Tên";
            // 
            // txtTP
            // 
            this.txtTP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTP.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTP.Location = new System.Drawing.Point(263, 237);
            this.txtTP.Multiline = true;
            this.txtTP.Name = "txtTP";
            this.txtTP.Size = new System.Drawing.Size(130, 36);
            this.txtTP.TabIndex = 9;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiaChi.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Location = new System.Drawing.Point(57, 237);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(200, 36);
            this.txtDiaChi.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.label2.Location = new System.Drawing.Point(1020, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(333, 30);
            this.label2.TabIndex = 14;
            this.label2.Text = "Thông Tin Nhân Viên ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.btnLuu);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Controls.Add(this.btnHuy);
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Controls.Add(this.btnThoat);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Location = new System.Drawing.Point(12, 512);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(912, 126);
            this.panel2.TabIndex = 18;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(811, 91);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 22);
            this.label18.TabIndex = 30;
            this.label18.Text = "Thoát";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(719, 91);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 22);
            this.label17.TabIndex = 29;
            this.label17.Text = "Xoá";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(620, 91);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 22);
            this.label15.TabIndex = 28;
            this.label15.Text = "Huỷ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(520, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 22);
            this.label14.TabIndex = 27;
            this.label14.Text = "Lưu";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(422, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 22);
            this.label13.TabIndex = 26;
            this.label13.Text = "Sửa";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(312, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 22);
            this.label12.TabIndex = 25;
            this.label12.Text = "Thêm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(20, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(213, 38);
            this.label10.TabIndex = 19;
            this.label10.Text = " BEANOBLE ";
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Image = global::QLYSACH.Properties.Resources.icons8_save_30;
            this.btnLuu.Location = new System.Drawing.Point(500, 34);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(83, 54);
            this.btnLuu.TabIndex = 15;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Image = global::QLYSACH.Properties.Resources.icons8_add_30;
            this.btnThem.Location = new System.Drawing.Point(300, 34);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(83, 54);
            this.btnThem.TabIndex = 13;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Image = global::QLYSACH.Properties.Resources.icons8_refresh_30;
            this.btnHuy.Location = new System.Drawing.Point(600, 34);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(83, 54);
            this.btnHuy.TabIndex = 16;
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Image = global::QLYSACH.Properties.Resources.icons8_edit_30;
            this.btnSua.Location = new System.Drawing.Point(400, 34);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(83, 54);
            this.btnSua.TabIndex = 14;
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Image = global::QLYSACH.Properties.Resources.icons8_logout_30;
            this.btnThoat.Location = new System.Drawing.Point(800, 34);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(83, 54);
            this.btnThoat.TabIndex = 18;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Image = global::QLYSACH.Properties.Resources.icons8_delete_30;
            this.btnXoa.Location = new System.Drawing.Point(700, 34);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(83, 54);
            this.btnXoa.TabIndex = 17;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // cboChucVu
            // 
            this.cboChucVu.FormattingEnabled = true;
            this.cboChucVu.Location = new System.Drawing.Point(188, 41);
            this.cboChucVu.Name = "cboChucVu";
            this.cboChucVu.Size = new System.Drawing.Size(205, 30);
            this.cboChucVu.TabIndex = 15;
            this.cboChucVu.SelectedIndexChanged += new System.EventHandler(this.cboChucVu_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rdAll);
            this.panel4.Controls.Add(this.rdNV);
            this.panel4.Controls.Add(this.rdQL);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(12, 42);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(394, 67);
            this.panel4.TabIndex = 303;
            // 
            // rdAll
            // 
            this.rdAll.AutoSize = true;
            this.rdAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic);
            this.rdAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.rdAll.Location = new System.Drawing.Point(39, 32);
            this.rdAll.Name = "rdAll";
            this.rdAll.Size = new System.Drawing.Size(77, 24);
            this.rdAll.TabIndex = 14;
            this.rdAll.TabStop = true;
            this.rdAll.Text = "Tất cả";
            this.rdAll.UseVisualStyleBackColor = true;
            this.rdAll.CheckedChanged += new System.EventHandler(this.rdAll_CheckedChanged);
            // 
            // rdNV
            // 
            this.rdNV.AutoSize = true;
            this.rdNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic);
            this.rdNV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.rdNV.Location = new System.Drawing.Point(249, 32);
            this.rdNV.Name = "rdNV";
            this.rdNV.Size = new System.Drawing.Size(107, 24);
            this.rdNV.TabIndex = 13;
            this.rdNV.TabStop = true;
            this.rdNV.Text = "Nhân Viên";
            this.rdNV.UseVisualStyleBackColor = true;
            this.rdNV.CheckedChanged += new System.EventHandler(this.rdNV_CheckedChanged);
            // 
            // rdQL
            // 
            this.rdQL.AutoSize = true;
            this.rdQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic);
            this.rdQL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.rdQL.Location = new System.Drawing.Point(135, 32);
            this.rdQL.Name = "rdQL";
            this.rdQL.Size = new System.Drawing.Size(98, 24);
            this.rdQL.TabIndex = 13;
            this.rdQL.TabStop = true;
            this.rdQL.Text = "Quản Lý ";
            this.rdQL.UseVisualStyleBackColor = true;
            this.rdQL.CheckedChanged += new System.EventHandler(this.rdQL_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.label1.Location = new System.Drawing.Point(22, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "Lọc theo chức vụ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btHuyTim);
            this.panel3.Controls.Add(this.btTim);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.txtTimMa);
            this.panel3.Controls.Add(this.txtTimTen);
            this.panel3.Location = new System.Drawing.Point(448, 39);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(476, 70);
            this.panel3.TabIndex = 302;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.label3.Location = new System.Drawing.Point(42, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tìm Kiếm";
            // 
            // btHuyTim
            // 
            this.btHuyTim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btHuyTim.FlatAppearance.BorderSize = 0;
            this.btHuyTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btHuyTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic);
            this.btHuyTim.ForeColor = System.Drawing.Color.White;
            this.btHuyTim.Location = new System.Drawing.Point(416, 37);
            this.btHuyTim.Name = "btHuyTim";
            this.btHuyTim.Size = new System.Drawing.Size(57, 30);
            this.btHuyTim.TabIndex = 9;
            this.btHuyTim.Text = "Huỷ";
            this.btHuyTim.UseVisualStyleBackColor = false;
            // 
            // btTim
            // 
            this.btTim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btTim.FlatAppearance.BorderSize = 0;
            this.btTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTim.Image = global::QLYSACH.Properties.Resources.icons8_search_26;
            this.btTim.Location = new System.Drawing.Point(367, 37);
            this.btTim.Name = "btTim";
            this.btTim.Size = new System.Drawing.Size(43, 30);
            this.btTim.TabIndex = 8;
            this.btTim.UseVisualStyleBackColor = false;
            this.btTim.Click += new System.EventHandler(this.btTim_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.label21.Location = new System.Drawing.Point(213, 43);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(32, 20);
            this.label21.TabIndex = 10;
            this.label21.Text = "Mã";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.label20.Location = new System.Drawing.Point(3, 43);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 20);
            this.label20.TabIndex = 11;
            this.label20.Text = "Tên";
            // 
            // txtTimMa
            // 
            this.txtTimMa.Location = new System.Drawing.Point(248, 38);
            this.txtTimMa.Multiline = true;
            this.txtTimMa.Name = "txtTimMa";
            this.txtTimMa.Size = new System.Drawing.Size(113, 28);
            this.txtTimMa.TabIndex = 6;
            // 
            // txtTimTen
            // 
            this.txtTimTen.Location = new System.Drawing.Point(46, 38);
            this.txtTimTen.Multiline = true;
            this.txtTimTen.Name = "txtTimTen";
            this.txtTimTen.Size = new System.Drawing.Size(161, 28);
            this.txtTimTen.TabIndex = 7;
            // 
            // frmQLyNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1372, 680);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelTT);
            this.Controls.Add(this.panelNV);
            this.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(265, 0);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQLyNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "QLyNhanVien";
            this.Load += new System.EventHandler(this.QLyNhanVien_Load);
            this.panelNV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvNV)).EndInit();
            this.panelTT.ResumeLayout(false);
            this.panelTT.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelNV;
        private System.Windows.Forms.DataGridView dtgvNV;
        private System.Windows.Forms.Panel panelTT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton rdNam;
        private System.Windows.Forms.RadioButton rdNu;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtTP;
        private System.Windows.Forms.MaskedTextBox txtNSinh;
        private System.Windows.Forms.ComboBox cboChucVu;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdAll;
        private System.Windows.Forms.RadioButton rdNV;
        private System.Windows.Forms.RadioButton rdQL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btHuyTim;
        private System.Windows.Forms.Button btTim;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtTimMa;
        private System.Windows.Forms.TextBox txtTimTen;
    }
}