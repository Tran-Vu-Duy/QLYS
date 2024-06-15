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

-- Tạo bảng HoaDon
CREATE TABLE HoaDon (
    MaHD NVARCHAR(50) NOT NULL PRIMARY KEY,
    MaNV NVARCHAR(50) NOT NULL,
    MaKH NVARCHAR(50) NOT NULL,
    NgayLapHD DATE NOT NULL,
    TongTien FLOAT NOT NULL,
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);

-- Tạo bảng CTHD (ChiTietHoaDon)
CREATE TABLE CTHD (
    MaCTHD NVARCHAR(50) NOT NULL PRIMARY KEY,
    MaHD NVARCHAR(50) NOT NULL,
    MaSach NVARCHAR(50) NOT NULL,
    DonGia FLOAT NOT NULL,
    SoLuong INT NOT NULL,
    GiamGia FLOAT NOT NULL,
    ThanhTien FLOAT,
    FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
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
(N'TG001', N'Nguyễn Nhật Ánh', N'Quảng Nam', '1955-06-01', NULL, N'Tác giả nổi tiếng với các tác phẩm dành cho thanh thiếu niên.', 'Nam', 'Hà Nội'),
(N'TG002', N'J.K. Rowling', N'Yate, Anh', '1965-07-31', NULL, N'Tác giả của loạt truyện Harry Potter.', 'Nữ', 'Yate');

-- Dữ liệu cho bảng Sach
INSERT INTO Sach (MaSach, TenSach, MaNXB, MaTG, GiaBan, GiaNhap, MoTa, SoLuong, MaLoai) 
VALUES 
(N'S001', N'Cho tôi xin một vé đi tuổi thơ', N'NXB001', N'TG001', 50000, 30000, N'Tác phẩm nổi tiếng của Nguyễn Nhật Ánh', 100, N'TL002'),
(N'S002', N'Harry Potter và Hòn đá phù thủy', N'NXB002', N'TG002', 100000, 70000, N'Tập đầu tiên trong loạt truyện Harry Potter', 150, N'TL001');

-- Dữ liệu cho bảng NhanVien
INSERT INTO NhanVien (MaNV, TenNV, DiaChi, ThanhPho, SDTNV, EmailNV, NgaySinh, GioiTinh, ChucVu) 
VALUES 
(N'NV001', N'Nguyễn Văn A', N'123 Đường ABC', N'Hà Nội', 123456789, N'nva@example.com', '1980-01-01', N'Nam', N'Quản lý'),
(N'NV002', N'Trần Thị B', N'456 Đường XYZ', N'TP.HCM', 987654321, N'ttb@example.com', '1990-02-02', N'Nữ', N'Nhân viên bán hàng');

-- Dữ liệu cho bảng KhachHang
INSERT INTO KhachHang (MaKH, TenKH, DiaChi, ThanhPho, SDTKH, EmailKH, NgaySinh, GioiTinh) 
VALUES 
(N'KH001', N'Phạm Văn C', N'789 Đường QWE', N'Đà Nẵng', 123123123, N'pvc@example.com', '2000-03-03', N'Nam'),
(N'KH002', N'Lê Thị D', N'321 Đường RTY', N'Hải Phòng', 321321321, N'ltd@example.com', '1995-04-04', N'Nữ');

-- Dữ liệu cho bảng HoaDon
INSERT INTO HoaDon (MaHD, MaNV, MaKH, NgayLapHD, TongTien) 
VALUES 
(N'HD001', N'NV001', N'KH001', '2023-01-01', 50000),
(N'HD002', N'NV002', N'KH002', '2023-01-02', 100000);

-- Dữ liệu cho bảng CTHD (ChiTietHoaDon)
INSERT INTO CTHD (MaCTHD, MaHD, MaSach, DonGia, SoLuong, GiamGia, ThanhTien) 
VALUES 
(N'CTHD001', N'HD001', N'S001', 50000, 1, 0, 50000),
(N'CTHD002', N'HD002', N'S002', 100000, 1, 0, 100000);
