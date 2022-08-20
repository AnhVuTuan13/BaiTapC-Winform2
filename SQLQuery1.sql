Create database DE4

use DE4
go

CREATE table Class(
	MaLop char(10) primary key,
	TenLop nvarchar(30) )

CREATE TABLE Student (
	MaSV char(10) primary key,
	HoTen nvarchar(30),
	Nu bit,
	QueQuan nvarchar(50),
	Tuoi int,
	MaLop char(10) foreign key (MaLop) references Class(MaLop) on update cascade on delete cascade)

insert into Class values('L01',N'Thỏ Bông'),
						('L02',N'Gấu Nhỏ'),
						('L03',N'Cá Vàng'),
						('L04',N'Chim Sẻ')
 where MaSV=