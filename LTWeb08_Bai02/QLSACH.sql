CREATE DATABASE QLSACH;
GO

USE QLSACH;
GO

-- Bảng CHUDE
CREATE TABLE CHUDE (
    MaCD CHAR(10) PRIMARY KEY,
    TenChuDe NVARCHAR(100)
);

-- Bảng NHAXUATBAN
CREATE TABLE NHAXUATBAN (
    MaNXB CHAR(10) PRIMARY KEY,
    TenNXB NVARCHAR(100),
    DiaChi NVARCHAR(200)
);

-- Bảng SACH
CREATE TABLE SACH (
    MaSach CHAR(10) PRIMARY KEY,
    TenSach NVARCHAR(200),
    GiaBan MONEY,
    MoTa NVARCHAR(MAX),
    AnhBia NVARCHAR(255),
    NgayCapNhat DATE,
    SoLuongTon INT,
    MaCD CHAR(10),
    MaNXB CHAR(10),
    FOREIGN KEY (MaCD) REFERENCES CHUDE(MaCD),
    FOREIGN KEY (MaNXB) REFERENCES NHAXUATBAN(MaNXB)
);

-- Bảng TACGIA
CREATE TABLE TACGIA (
    MaTG CHAR(10) PRIMARY KEY,
    TenTG NVARCHAR(100),
    DiaChi NVARCHAR(200),
    DienThoai VARCHAR(20)
);

-- Bảng VIETSACH (quan hệ n-n giữa SACH và TACGIA)
CREATE TABLE VIETSACH (
    MaTG CHAR(10),
    MaSach CHAR(10),
    VaiTro NVARCHAR(50),
    PRIMARY KEY (MaTG, MaSach),
    FOREIGN KEY (MaTG) REFERENCES TACGIA(MaTG),
    FOREIGN KEY (MaSach) REFERENCES SACH(MaSach)
);

-- Bảng KHACHHANG
CREATE TABLE KHACHHANG (
    MaKH CHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100),
    TaiKhoan NVARCHAR(50),
    MatKhau NVARCHAR(50),
    Email NVARCHAR(100),
    DiaChi NVARCHAR(200),
    DienThoai VARCHAR(20),
    NgaySinh DATE
);

-- Bảng DONDATHANG
CREATE TABLE DONDATHANG (
    SoDonHang CHAR(10) PRIMARY KEY,
    MaKH CHAR(10),
    NgayDat DATE,
    TriGia MONEY,
    FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH)
);

-- Bảng CHITIETDONDATHANG
CREATE TABLE CHITIETDONDATHANG (
    SoDonHang CHAR(10),
    MaSach CHAR(10),
    SoLuong INT,
    DonGia MONEY,
    PRIMARY KEY (SoDonHang, MaSach),
    FOREIGN KEY (SoDonHang) REFERENCES DONDATHANG(SoDonHang),
    FOREIGN KEY (MaSach) REFERENCES SACH(MaSach)
);

INSERT INTO CHUDE VALUES 
('CD01', N'Tin học - Chính trị'),
('CD02', N'Luật'),
('CD03', N'Thiếu nhi'),
('CD04', N'Kinh tế'),
('CD05', N'Văn học');

INSERT INTO NHAXUATBAN VALUES
('NXB01', N'Nhà xuất bản Trẻ', N'161B Lý Chính Thắng, Q3, TP.HCM'),
('NXB02', N'NXB Lao Động', N'175 Giảng Võ, Hà Nội'),
('NXB03', N'NXB Giáo Dục', N'81 Trần Hưng Đạo, Hà Nội');

INSERT INTO SACH VALUES
('S01', N'Giáo trình Tin học cơ bản', 28000,
 N'Nội dung của cuốn: Tin Học Cơ Bản Windows XP gồm có 7 chương. Chương 1: Một số vấn đề cơ bản... Chương 7: Hỏi và đáp các thắc mắc.', 
 N'/Content/images/tinhoccoban.jpg', '2014-10-25', 120, 'CD01', 'NXB01'),

('S02', N'Giáo trình Tin học văn phòng', 120000,
 N'Cuốn sách gồm 3 phần: soạn thảo văn bản, bảng tính, trình chiếu.', 
 N'/Content/images/tinhocvanphong.jpg', '2013-09-23', 25, 'CD02', 'NXB02'),

('S03', N'Lập trình cơ sở dữ liệu với VB.NET', 110000,
 N'Giới thiệu lập trình cơ sở dữ liệu bằng Visual Basic 2008 và ADO.NET 2.0.', 
 N'/Content/images/vbnet.jpg', '2014-12-21', 23, 'CD01', 'NXB01'),

('S04', N'Cơ sở dữ liệu quan hệ', 95000,
 N'Giải thích chi tiết mô hình quan hệ và SQL nâng cao.', 
 N'/Content/images/sql.jpg', '2015-05-10', 40, 'CD04', 'NXB03');

 INSERT INTO TACGIA VALUES
('TG01', N'Nguyễn Văn A', N'TP.HCM', '0909000111'),
('TG02', N'Lê Thị B', N'Hà Nội', '0908333222'),
('TG03', N'Phạm Quốc Cường', N'Đà Nẵng', '0908777666'),
('TG04', N'Trần Minh Dũng', N'Cần Thơ', '0919000444');

INSERT INTO VIETSACH VALUES
('TG01', 'S01', N'Chủ biên'),
('TG02', 'S02', N'Đồng tác giả'),
('TG03', 'S03', N'Chủ biên'),
('TG04', 'S04', N'Tác giả');

INSERT INTO KHACHHANG VALUES
('KH01', N'Lê Hồng Phong', 'lehongphong', '123456', 'phong@gmail.com', N'TP.HCM', '0908123456', '1995-03-21'),
('KH02', N'Nguyễn Thị Hoa', 'hoanguyen', 'abc123', 'hoa@gmail.com', N'Hà Nội', '0912333444', '1997-11-15');

INSERT INTO DONDATHANG VALUES
('DH01', 'KH01', '2024-10-05', 148000),
('DH02', 'KH02', '2024-11-02', 230000);

INSERT INTO CHITIETDONDATHANG VALUES
('DH01', 'S01', 2, 28000),
('DH01', 'S03', 1, 110000),
('DH02', 'S02', 1, 120000),
('DH02', 'S04', 1, 95000);
