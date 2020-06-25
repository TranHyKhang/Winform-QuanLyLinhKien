use QuanLyLinhKien

create table Products(
	MSLK nvarchar(20) PRIMARY Key,
	TenLK nvarchar(30) Not null,
	Gia int Not null,
	TinhTrang bit,
)

Create table HoaDon (
	MSLK nvarchar (20) PRIMARY Key,
	NgayDat Datetime,
)

Create table HDChiTietDatHang(
	MSHD nvarchar(10) not null,
	MSLK nvarchar(20) not null,
	SoLuong int not null,
	TiLeGiam int
	PRIMARY Key(MSHD, MSLK)
);