-- Tạo cơ sở dữ liệu QLYSACH
CREATE DATABASE QLYSACH;
GO

-- Sử dụng cơ sở dữ liệu QLYSACH
USE QLYSACH;
GO

-- Tạo bảng TheLoai
CREATE TABLE TheLoai (
    MaLoai NVARCHAR(50) NOT NULL PRIMARY KEY,
    TenLoai NVARCHAR(50) NOT NULL
);

-- Tạo bảng NhaXuatBan
CREATE TABLE NhaXuatBan (
    MaNXB NVARCHAR(50) NOT NULL PRIMARY KEY,
    TenNXB NVARCHAR(250) NOT NULL,
    DiaChiNXB NVARCHAR(250) NOT NULL,
    SDTNXB INT NOT NULL,
    EmailNXB NVARCHAR(150) NOT NULL
);

-- Tạo bảng TacGia
CREATE TABLE TacGia (
    MaTG NVARCHAR(50) NOT NULL PRIMARY KEY,
    TenTG NVARCHAR(50) NOT NULL,
    QueQuan NVARCHAR(250),
    NgaySinh DATE,
    NgayMat DATE,
    TieuSu NVARCHAR(500),
    GioiTinh NVARCHAR(10),
    ThanhPho NVARCHAR(100)
);

-- Tạo bảng Sach
CREATE TABLE Sach (
    MaSach NVARCHAR(50) NOT NULL PRIMARY KEY,
    TenSach NVARCHAR(250) NOT NULL,
    MaNXB NVARCHAR(50) NOT NULL,
    MaTG NVARCHAR(50) NOT NULL,
    GiaBan FLOAT NOT NULL,
    GiaNhap FLOAT NOT NULL,
    MoTa NVARCHAR(255),
    SoLuong INT NOT NULL,
    MaLoai NVARCHAR(50) NOT NULL,
    FOREIGN KEY (MaNXB) REFERENCES NhaXuatBan(MaNXB),
    FOREIGN KEY (MaTG) REFERENCES TacGia(MaTG),
    FOREIGN KEY (MaLoai) REFERENCES TheLoai(MaLoai)
);

-- Tạo bảng NhanVien
CREATE TABLE NhanVien (
    MaNV NVARCHAR(50) NOT NULL PRIMARY KEY,
    TenNV NVARCHAR(250) NOT NULL,
    DiaChi NVARCHAR(250),
    ThanhPho NVARCHAR(100),
    SDTNV INT NOT NULL,
    EmailNV NVARCHAR(150) NOT NULL,
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    ChucVu NVARCHAR(100)
);

-- Tạo bảng KhachHang
CREATE TABLE KhachHang (
    MaKH NVARCHAR(50) NOT NULL PRIMARY KEY,
    TenKH NVARCHAR(250) NOT NULL,
    DiaChi NVARCHAR(250),
    ThanhPho NVARCHAR(100),
    SDTKH INT NOT NULL,
    EmailKH NVARCHAR(150) NOT NULL,
    NgaySinh DATE,
    GioiTinh NVARCHAR(10)
);

-- Tạo bảng HoaDonXuat
CREATE TABLE HoaDonXuat (
    MaHDX NVARCHAR(50) NOT NULL PRIMARY KEY,
    MaKH NVARCHAR(50) NOT NULL,
	MaNV NVARCHAR(50) NOT NULL,
    NgayXuat DATE NOT NULL,
    ThanhTien FLOAT NOT NULL,
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
	FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

-- Tạo bảng ChiTietHoaDonXuat (CTHDX)
CREATE TABLE CTHDX (
    MaCT_HDX NVARCHAR(50) NOT NULL PRIMARY KEY,
    MaHDX NVARCHAR(50) NOT NULL,
    MaSach NVARCHAR(50) NOT NULL,
    SoLuongXuat INT NOT NULL,
    DonGiaXuat FLOAT NOT NULL,
    TongTien FLOAT NOT NULL,
    FOREIGN KEY (MaHDX) REFERENCES HoaDonXuat(MaHDX),
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
);

-- Tạo bảng HoaDonNhap
CREATE TABLE HoaDonNhap (
    MaHDN NVARCHAR(50) NOT NULL PRIMARY KEY,
    MaNXB NVARCHAR(50) NOT NULL,
	MaNV NVARCHAR(50) NOT NULL,
    NgayNhap DATE NOT NULL,
    ThanhTien FLOAT NOT NULL,
    FOREIGN KEY (MaNXB) REFERENCES NhaXuatBan(MaNXB),
	FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

-- Tạo bảng ChiTietHoaDonNhap (CTHDN)
CREATE TABLE CTHDN (
    MaCT_HDN NVARCHAR(50) NOT NULL PRIMARY KEY,
    MaHDN NVARCHAR(50) NOT NULL,
    MaSach NVARCHAR(50) NOT NULL,
    SoLuongNhap INT NOT NULL,
    DonGiaNhap FLOAT NOT NULL,
    TongTien FLOAT NOT NULL,
    FOREIGN KEY (MaHDN) REFERENCES HoaDonNhap(MaHDN),
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
);

-- Tạo bảng Kho
CREATE TABLE Kho (
    MaKhoHang NVARCHAR(50) NOT NULL PRIMARY KEY,
    MaNXB NVARCHAR(50) NOT NULL,
    MaSach NVARCHAR(50) NOT NULL,
    SLTon INT NOT NULL,
    NgayNhapKho DATE NOT NULL,
    FOREIGN KEY (MaNXB) REFERENCES NhaXuatBan(MaNXB),
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
);

-- Tạo bảng NguoiDung
CREATE TABLE NguoiDung (
    id_NguoiDung INT IDENTITY NOT NULL PRIMARY KEY,
    TenDangNhap NVARCHAR(100) NOT NULL,
    MatKhau NVARCHAR(256) NOT NULL,
    HoTen NVARCHAR(250),
    Email NVARCHAR(150),
    Nhom NVARCHAR(150) NOT NULL
);

-- Tạo bảng ChucNang
CREATE TABLE ChucNang (
    id_ChucNang INT IDENTITY NOT NULL PRIMARY KEY,
    TenChucNang NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(250)
);

-- Tạo bảng PhanQuyen
CREATE TABLE PhanQuyen (
    id_NguoiDung INT NOT NULL,
    id_ChucNang INT NOT NULL,
    PRIMARY KEY (id_NguoiDung, id_ChucNang),
    FOREIGN KEY (id_NguoiDung) REFERENCES NguoiDung(id_NguoiDung),
    FOREIGN KEY (id_ChucNang) REFERENCES ChucNang(id_ChucNang)
);

-- Nhập Dữ Liệu Vào

-- Dữ liệu cho bảng NguoiDung
INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, Email, Nhom) 
VALUES 
(N'admin', N'admin123', N'Người Quản Trị', N'admin@example.com', 'admin'),
(N'user1', N'user1', N'Người Dùng Một', N'user1@example.com', 'user'),
(N'user2', N'user2', N'Người Dùng Hai', N'user2@example.com', 'user');

-- Dữ liệu cho bảng ChucNang
INSERT INTO ChucNang (TenChucNang, MoTa) 
VALUES 
(N'Đăng nhập', N'Người dùng đăng nhập vào hệ thống'),
(N'Đăng xuất', N'Người dùng thoát vào hệ thống'),
(N'Đổi mật khẩu', N'Người dùng đổi mật khẩu của họ'),
(N'Quản lý danh mục', N'Người dùng quản lý danh mục sách'),
(N'Xem bìa sách', N'Người dùng xem bìa của quyển sách'),
(N'Xem chi tiết sách', N'Người dùng xem chi tiết sách'),
(N'Quản lý sách', N'Người dùng quản lý hệ thống sách'),
(N'Xem báo cáo', N'Người dùng xem báo cáo'),
(N'In báo cáo', N'Người dùng in báo cáo'),
(N'Tìm kiếm sách', N'Người dùng tìm kiếm sách'),
(N'Tìm kiếm danh mục', N'Người dùng tìm kiếm danh mục'),
(N'Tìm kiếm nhân viên', N'Người dùng tìm kiếm nhân viên'),
(N'Tìm kiếm khách hàng', N'Người dùng tìm khách hàng'),
(N'Tìm kiếm hoá đơn', N'Người dùng tìm kiếm hoá đơn'),
(N'Quản lý hoá đơn', N'Người dùng quản lý hoá đơn'),
(N'Quản lý tài khoản', N'Người dùng quản lý tài khoản'),
(N'Quản lý nhân viên', N'Người dùng quản lý nhân viên'),
(N'Quản lý khách hàng', N'Người dùng quản lý khách hàng');

-- Dữ liệu cho bảng PhanQuyen
INSERT INTO PhanQuyen (id_NguoiDung, id_ChucNang) 
VALUES 
(1, 1), -- Người Quản Trị
(1, 3), -- Người Quản Trị
(2, 1), -- Người Dùng Một
(2, 2),
(2, 3),
(2, 5),
(2, 6),
(2, 10),
(3, 1), -- Người Dùng Hai
(3, 2),
(3, 3),
(3, 5),
(3, 6),
(3, 10);

-- Dữ liệu cho bảng TheLoai
INSERT INTO TheLoai (MaLoai, TenLoai) 
VALUES 
(N'TL001', N'Khoa học viễn tưởng'),
(N'TL002', N'Tiểu thuyết lãng mạn'),
(N'TL003', N'Giáo dục'),
(N'TL004', N'Lịch sử');

-- Dữ liệu cho bảng NhaXuatBan
INSERT INTO NhaXuatBan (MaNXB, TenNXB, DiaChiNXB, SDTNXB, EmailNXB) 
VALUES 
(N'NXB001', N'NXB Kim Đồng', N'123 Đường ABC, Hà Nội', 123456789, N'kimdong@example.com'),
(N'NXB002', N'NXB Trẻ', N'456 Đường XYZ, TP.HCM', 987654321, N'nxbtre@example.com');

-- Dữ liệu cho bảng TacGia
INSERT INTO TacGia (MaTG, TenTG, QueQuan, NgaySinh, NgayMat, TieuSu, GioiTinh, ThanhPho) 
VALUES 
(N'TG001', N'J.K. Rowling', N'Anh', '1965-07-31', NULL, N'Tác giả của Harry Potter', N'Nữ', N'London'),
(N'TG002', N'Nguyễn Nhật Ánh', N'Việt Nam', '1955-05-07', NULL, N'Tác giả của Kính Vạn Hoa', N'Nam', N'Hồ Chí Minh');

-- Dữ liệu cho bảng Sach
INSERT INTO Sach (MaSach, TenSach, MaNXB, MaTG, GiaBan, GiaNhap, MoTa, SoLuong, MaLoai) 
VALUES 
(N'S001', N'Harry Potter và Hòn Đá Phù Thủy', N'NXB001', N'TG001', 150000, 100000, N'Tập 1 của Harry Potter', 100, N'TL001'),
(N'S002', N'Kính Vạn Hoa - Tập 1', N'NXB002', N'TG002', 50000, 30000, N'Tập 1 của Kính Vạn Hoa', 200, N'TL003');

-- Dữ liệu cho bảng NhanVien
INSERT INTO NhanVien (MaNV, TenNV, DiaChi, ThanhPho, SDTNV, EmailNV, NgaySinh, GioiTinh, ChucVu) 
VALUES 
(N'NV001', N'Nguyễn Văn A', N'123 Đường ABC', N'Hà Nội', 123456789, N'nguyenvana@example.com', '1990-01-01', N'Nam', N'Quản lý'),
(N'NV002', N'Trần Thị B', N'456 Đường XYZ', N'TP.HCM', 987654321, N'tranthib@example.com', '1992-02-02', N'Nữ', N'Nhân viên');

-- Dữ liệu cho bảng KhachHang
INSERT INTO KhachHang (MaKH, TenKH, DiaChi, ThanhPho, SDTKH, EmailKH, NgaySinh, GioiTinh) 
VALUES 
(N'KH001', N'Lê Văn C', N'789 Đường DEF', N'Đà Nẵng', 456123789, N'levanc@example.com', '1988-03-03', N'Nam'),
(N'KH002', N'Phạm Thị D', N'101 Đường GHI', N'Hải Phòng', 789456123, N'phamthid@example.com', '1991-04-04', N'Nữ');

-- Dữ liệu cho bảng HoaDonXuat
INSERT INTO HoaDonXuat (MaHDX, MaKH, MaNV, NgayXuat, ThanhTien) 
VALUES 
(N'HDX001', N'KH001', N'NV001', '2024-06-01', 150000),
(N'HDX002', N'KH002', N'NV002', '2024-06-02', 50000);

-- Dữ liệu cho bảng CTHDX
INSERT INTO CTHDX (MaCT_HDX, MaHDX, MaSach, SoLuongXuat, DonGiaXuat, TongTien) 
VALUES 
(N'CTHDX001', N'HDX001', N'S001', 1, 150000, 150000),
(N'CTHDX002', N'HDX002', N'S002', 1, 50000, 50000);

-- Dữ liệu cho bảng HoaDonNhap
INSERT INTO HoaDonNhap (MaHDN, MaNXB, MaNV, NgayNhap, ThanhTien) 
VALUES 
(N'HDN001', N'NXB001', N'NV001', '2024-05-01', 100000),
(N'HDN002', N'NXB002', N'NV002', '2024-05-02', 30000);

-- Dữ liệu cho bảng CTHDN
INSERT INTO CTHDN (MaCT_HDN, MaHDN, MaSach, SoLuongNhap, DonGiaNhap, TongTien) 
VALUES 
(N'CTHDN001', N'HDN001', N'S001', 1, 100000, 100000),
(N'CTHDN002', N'HDN002', N'S002', 1, 30000, 30000);
-- Dữ liệu cho bảng Kho
INSERT INTO Kho (MaKhoHang, MaNXB, MaSach, SLTon, NgayNhapKho) 
VALUES 
(N'KHO001', N'NXB001', N'S001', 50, '2023-01-01'),
(N'KHO002', N'NXB002', N'S002', 75, '2023-02-01'),
(N'KHO003', N'NXB001', N'S002', 30, '2023-03-01');