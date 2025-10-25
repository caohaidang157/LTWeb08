CREATE DATABASE BookStore
GO

USE BookStore
GO

CREATE TABLE Theloaitin
(
	IDLoai INT PRIMARY KEY,
	Tentheloai NVARCHAR(100)
)
GO

CREATE TABLE Tintuc
(
	IdTin INT PRIMARY KEY,
	IDLoai INT REFERENCES Theloaitin(IDLoai),
	Tieudetin NVARCHAR(100),
	Noidungtin NTEXT
)
GO

INSERT INTO Theloaitin (IDLoai, Tentheloai)
VALUES
(1, N'Thể thao'),
(2, N'Kinh tế'),
(3, N'Thế giới')
GO

INSERT INTO Tintuc (IdTin, IDLoai, Tieudetin, Noidungtin)
VALUES
(1, 1, N'Ra mắt bộ sách "Khoa học kỳ thú"', N'Bộ sách mới giúp trẻ em khám phá thế giới xung quanh một cách sinh động.'),
(2, 2, N'Giảm giá 30% toàn bộ sách văn học', N'Chương trình giảm giá diễn ra từ ngày 1/11 đến hết 15/11.'),
(3, 3, N'Hội sách mùa thu 2025', N'Sự kiện hội sách được tổ chức tại Nhà Văn hóa Thanh niên TP.HCM.')
GO
