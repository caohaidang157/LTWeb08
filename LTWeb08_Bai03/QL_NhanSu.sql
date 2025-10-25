CREATE DATABASE QL_NhanSu;
GO

USE QL_NhanSu;
GO

CREATE TABLE Department (
    DeptId INT PRIMARY KEY,
    Name NVARCHAR(255)
);

CREATE TABLE Employee (
    Id INT PRIMARY KEY,
    Name NVARCHAR(255),
    Gender NVARCHAR(10),
    City NVARCHAR(100),
    DeptId INT,
	ImagePath NVARCHAR(500) NULL,
    FOREIGN KEY (DeptId) REFERENCES Department(DeptId)
);
GO

INSERT INTO Department (DeptId, Name) VALUES
(1, N'Khoa CNTT'),
(2, N'Khoa Ngoại Ngữ'),
(3, N'Khoa Tài Chính'),
(4, N'Khoa Thực Phẩm'),
(5, N'Phòng Đào Tạo');

INSERT INTO Employee (Id, Name, Gender, City, DeptId,ImagePath) VALUES
(1, N'Nguyễn Hải Yến', N'Nữ', N'Đà Lạt', 1,'~/Content/images/1.jpg'),
(2, N'Trương Mạnh Hùng', N'Nam', N'TP.HCM', 1,'~/Content/images/1.jpg'),
(3, N'Đinh Duy Minh', N'Nam', N'Thái Bình', 2,'~/Content/images/1.jpg'),
(4, N'Ngô Thị Ngguyệt', N'Nữ', N'Long An', 2,'~/Content/images/1.jpg'),
(5, N'Đào Minh Châu', N'Nữ', N'Bạc Liêu', 3,'~/Content/images/1.jpg'),
(14, N'Phan Thị Ngọc Mai', N'Nữ', N'Bến Tre', 3,'~/Content/images/1.jpg'),
(15, N'Trương Nguyễn Quỳnh Anh', N'Nữ', N'TP.HCM', 4,'~/Content/images/1.jpg'),
(16, N'Lê Thanh Liêm', N'Nam', N'TP.HCM', 4,'~/Content/images/1.jpg');
GO