
CREATE DATABASE SHOPONLINE;
GO


USE SHOP;
GO

CREATE TABLE CUAHANG(
	ID INT NOT NULL INDENTITY(2,1),
	TenCH NVARCHAR(20) NOT NULL, 
	DiaChi NVARCHAR(50) NOT NULL, 
	DiaChiGMap NVARCHAR(20), 
	SDT VARCHAR(20),
	PRIMARY KEY (ID)
);

CREATE TABLE LOAIHANG(
	ID INT NOT NULL INDENTITY(4,1),  
	TenLoai NVARCHAR(20) NOT NULL, 
	MoTa NVARCHAR(50),
	PRIMARY KEY (ID)
);

CREATE TABLE SUBLOAIHANG
(
	ID INT NOT NULL INDENTITY(10,1),
	IDLoaiHang INT,
	TenLoai NVARCHAR(20) not null,
	MoTa NVARCHAR(50),
	PRIMARY KEY(ID),
	foreign key(IDLoaiHang) references LOAIHANG(ID)
);

CREATE TABLE MATHANG(
	ID INT NOT NULL IDENTITY(16,1), 
	TenMH NVARCHAR(50) NOT NULL,
	IDSubLoaiHang INT NOT NULL,
	URLHinhAnh1 VARCHAR(100),
	URLHinhAnh2 VARCHAR(100),
	URLHinhAnh3 VARCHAR(100),
	STATUS boolean,
	PRIMARY KEY(ID),
	foreign key(IDSubLoaiHang) references SUBLOAIHANG(ID)
);

CREATE TABLE CHITIETMATHANG(
	ID INT NOT NULL IDENTITY(32,1),
	IDMatHang INT NOT NULL,
	MoTa NVARCHAR(100),
	MauSac NVARCHAR(20),
	Size VARCHAR(3),
	Gia INT,
	Loai VARCHAR(3),
	SoLuong INT,
	STATUS boolean,
	PRIMARY KEY (ID),
	FOREIGN KEY (IDMatHang) REFERENCES MATHANG(ID),
);

CREATE TABLE ACCOUNTTYPE(
	ID VARCHAR(5) NOT NULL,
	TenLoai NVARCHAR(20) NOT NULL,
	PRIMARY KEY (ID)
);

CREATE TABLE ACCOUNT(
	Username VARCHAR(20) NOT NULL,
	Password VARCHAR(20) NOT NULL, 
	IDType VARCHAR(5) NOT NULL,
	PRIMARY KEY (Username),
	FOREIGN KEY (IDType) REFERENCES ACCOUNTTYPE(ID)
);

CREATE TABLE ACCOUNTADMIN(
	ID INT NOT NULL INDENTITY(2,1),
	Ten NVARCHAR(20) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	SDT INT NOT NULL,
	Account VARCHAR(20) NOT NULL,
	PRIMARY KEY (ID),
	FOREIGN KEY (Account) REFERENCES ACCOUNT(Username)
);

CREATE TABLE KHACHHANG(
	ID INT NOT NULL INDENTITY(2,1),
	Ten NVARCHAR(20) NOT NULL,
	Email VARCHAR(30), 
	SDT INT NOT NULL,
	DiaChi NVARCHAR(50),
	IDAccount VARCHAR(20),
	PRIMARY KEY (ID),
	FOREIGN KEY (IDAccount) REFERENCES ACCOUNT(Username)
);

CREATE TABLE HOADON(
	ID INT NOT NULL INDENTITY(1,1),
	SDT VARCHAR (13),
	EMAIL VARCHAR(50),
	Ngay DATE NOT NULL,
	TongTien INT NOT NULL,
	TinhTrang NVARCHAR(20) NOT NULL,
	STATUS boolean,
	PRIMARY KEY (ID),
	FOREIGN KEY (IDKhachHang) REFERENCES KHACHHANG(ID)
);

CREATE TABLE CHITIETHOADON(
	ID INT NOT NULL INDENTITY(1,1),
	IDChiTietMatHang INT NOT NULL,
	IDHoaDon INT NOT NULL,
	SoLuong INT,
	STATUS boolean,
	PRIMARY KEY (ID),
	FOREIGN KEY (IDChiTietMatHang) REFERENCES CHITIETMATHANG(ID),
	FOREIGN KEY (IDHoaDon) REFERENCES HOADON(ID)
);



INSERT INTO CUAHANG VALUES ('1', N'SHOP QUẦN ÁO RAIN',N'28 Nhật Tảo, Phường 4, Quận 10, TP HCM', '', '0975187293');

INSERT INTO LOAIHANG VALUES ('1',N'QUẦN', ''),	
							('2', N'ÁO', ''),
							('3', N'ĐẦM', '');
							
INSERT INTO SUBLOAIHANG VALUES('1', '1', N'QUẦN JEAN',''),
							('2', '1', N'QUẦN KAKI',''),
							('3', '1', N'QUẦN NGỐ', ''),
							('4', '2', N'ÁO THUN TAY DÀI', ''),
							('5', '2', N'ÁO THUN TAY NGẮN', ''),
							('6', '2', N'ÁO SƠ MI TAY DÀI', ''),
							('7', '2', N'ÁO SƠ MI TAY NGẮN', ''),
							('8', '3', N'ĐẦM CÔNG SỞ', ''),
							('9', '3', N'ĐẦM', '');

INSERT INTO MATHANG VALUES ('1', N'QUẦN JEAN 116001','1' , 'http://totoshop.vn/cdn/store/7136/ps/20161124/jean_nam_32__3__500x750.jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20161109/3486895/JEAN_NAM_116001_(jean_nam_32_(1)).jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20161109/3486895/JEAN_NAM_116001_(jean_nam_32_(2)).jpg'),
						   ('2', N'QUẦN JEAN 116002', '1', 'http://totoshop.vn/cdn/store/7136/ps/20161128/jan_nam_63__4__500x750.jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20161109/3486896/JEAN_NAM_116002_(jan_nam_63_(2)).jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20161109/3486896/JEAN_NAM_116002_(jan_nam_63_(3)).jpg'),
						   ('3', N'QUẦN JEAN 116004', '1', 'http://totoshop.vn/cdn/store/7136/ps/20161130/jean_nam_21__3__500x750.jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20161106/3476330/JEAN_NAM_106014_(jean_nam_21_(1)).jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20161106/3476330/JEAN_NAM_106014_(jean_nam_21_(4)).jpg'),
						   ('4', N'QUẦN KAKI 106010NV','2' , 'http://totoshop.vn/cdn/store/7136/ps/20161116/quna_nam_13__4__500x750.jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20161018/3415541/KAKI_NAM_106010NV_(quna_nam_13_(1)).jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20161018/3415541/KAKI_NAM_106010NV_(quna_nam_13_(2)).jpg'),
						   ('5', N'QUẦN KAKI 106010GR','2', 'http://totoshop.vn/cdn/store/7136/ps/20161115/quan_nam_2__4__500x750.jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20161018/3415540/KAKI_NAM_106010GR_(quan_nam_2_(1)).jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20161018/3415540/KAKI_NAM_106010GR_(quan_nam_2_(2)).jpg'),
						   ('6', N'QUẦN SHORT JEAN 106005','1', 'http://totoshop.vn/cdn/store/7136/ps/20161109/short_nam_7__3__500x750.jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20161029/3445428/SHORT_JEAN_NAM_106005_(short_nam_7_(1)).jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20161029/3445428/SHORT_JEAN_NAM_106005_(short_nam_7_(2)).jpg'),
						   ('7', N'QUẦN SHORT KAKI 096001WH','2', 'http://totoshop.vn/cdn/store/7136/ps/20161026/short_nam_35__2__500x750.jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20160924/3344542/SHORT_KK_096001WH_(short_nam_35_(1)).jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20160924/3344542/SHORT_KK_096001WH_(short_nam_35_(3)).jpg'),
						   ('8', N'QUẦN SHORT THUN QT07155','3', 'http://totoshop.vn/cdn/store/7136/ps/20151025/384212020_500x750.jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20150813/1867187/QT07155_(quan_short_nam_20_(2)).jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20150813/1867187/QT07155_(quan_short_nam_20_(2)).jpg'),
						   ('9', N'ÁO THUN 086014GR','4', 'http://totoshop.vn/cdn/store/7136/ps/20161208/thun_nam_20__2__500x750.jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20161111/3495765/THUN_086014GR_(thun_nam_20_(1)).jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20161111/3495765/THUN_086014GR_(thun_nam_20_(3)).jpg'),
						   ('10', N'ÁO THUN 096036GN','5', 'http://totoshop.vn/cdn/store/7136/ps/20161103/thun_nam_22__7__500x750.jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20160930/3366725/THUN_NAM_TN_096036GN_(thun_nam_22_(1)).jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20160930/3366725/THUN_NAM_TN_096036GN_(thun_nam_22_(2)).jpg'),
						   ('11', N'ÁO SƠ MI 116004WH','6', 'http://totoshop.vn/cdn/store/7136/ps/20161208/somi_nam_15__3__500x750.jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20161110/3492112/SO_MI_TD_116004WH_(somi_nam_15_(1)).jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20161110/3492112/SO_MI_TD_116004WH_(somi_nam_15_(2)).jpg'),
						   ('12', N'ÁO SƠ MI 116005BL','7', 'http://totoshop.vn/cdn/store/7136/ps/20161125/somi_nam_51__5__500x750.jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20161110/3492113/SO_MI_TN_116005BL_(somi_nam_51_(1)).jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20161110/3492113/SO_MI_TN_116005BL_(somi_nam_51_(2)).jpg'),
						   ('13', N'ĐẦM CÔNG SỞ 086014GR','8', 'http://totoshop.vn/cdn/store/7136/ps/20161208/thun_nam_20__2__500x750.jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20161111/3495765/THUN_086014GR_(thun_nam_20_(1)).jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20161111/3495765/THUN_086014GR_(thun_nam_20_(3)).jpg'),
						   ('14', N'ĐẦM NHUNG 096036GN','9', 'http://totoshop.vn/cdn/store/7136/ps/20161103/thun_nam_22__7__500x750.jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20160930/3366725/THUN_NAM_TN_096036GN_(thun_nam_22_(1)).jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20160930/3366725/THUN_NAM_TN_096036GN_(thun_nam_22_(2)).jpg'),
						   ('15', N'ĐẦM ĐEN 116004WH','8', 'http://totoshop.vn/cdn/store/7136/ps/20161208/somi_nam_15__3__500x750.jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20161110/3492112/SO_MI_TD_116004WH_(somi_nam_15_(1)).jpg', 'http://totoshop.vn/cdn/store/7136/psCT/20161110/3492112/SO_MI_TD_116004WH_(somi_nam_15_(2)).jpg'),;
						   

INSERT INTO CHITIETMATHANG VALUES ('1', '1', '','XANH', '29', 385000, 'NAM', 5),
								  ('2', '1', '','XANH', '30', 385000, N'NỮ', 6),
								  ('3', '1', '','XANH', '31', 385000, 'NAM', 7),
								  ('4', '2', '','XANH', '28', 385000, 'NAM', 8),
								  ('5', '2', '','XANH', '29', 385000, N'NỮ', 5),
								  ('6', '2', '','XANH', '30', 385000, 'NAM', 4),
								  ('7', '2', '','XANH', '31', 385000, 'NAM', 3),
								  ('8', '3', '','XANH', '28', 365000, 'NAM', 7),
								  ('9', '3', '','XANH', '29', 365000, 'NAM', 9),
								  ('10', '3', '','XANH', '30', 365000, 'NAM', 7),
								  ('11', '3', '','XANH', '31', 365000, 'NAM', 7),
								  ('12', '4', '',N'ĐEN', '29', 365000, N'NỮ', 5),
								  ('13', '4', '',N'ĐEN', '30', 365000, 'NAM', 6),
								  ('14', '4', '',N'ĐEN', '31', 365000, N'NỮ', 5), 
								  ('15', '5', '', N'ĐEN', '30', 365000, 'NAM', 3),
								  ('16', '5', '', N'ĐEN', '31', 365000, 'NAM', 2),
								  ('17', '6', '', N'ĐEN', '32', 365000, 'NAM', 1),
								  ('18', '7', '', 'XANH', '28', 275000, 'NAM', 3),
								  ('19', '7', '', 'XANH', '29', 275000, N'NỮ', 2),
								  ('20', '8', '', 'XANH', '30', 275000, 'NAM', 2),
								  ('21', '8', '', N'TRẮNG', '29', 225000, 'NAM', 5),
								  ('22', '9', '', N'TRẮNG', 'M', 225000, 'NAM', 3), 
								  ('23', '10', '', 'XANH', 'L', 155000, 'NAM', 2),
								  ('24', '10', '', N'XÁM ĐỐM TRẮNG', 'M', 225000, 'NAM', 3),
								  ('25', '11', '', N'XÁM ĐỐM TRẮNG', 'L', 225000, N'NỮ', 4),
								  ('26', '12', '', N'TRẮNG VÀ XANH', 'M', 225000, 'NAM', 5),
								  ('27', '12', '', N'TRẮNG VÀ XANH', 'L', 225000, 'NAM', 5),
								  ('28', '13', '', N'TRẮNG', 'M', 245000, N'NỮ', 5),
								  ('29', '13', '', N'TRẮNG', 'L', 245000, N'NỮ', 5),
								  ('30', '14', '', N'ĐEN', 'M', 225000, N'NỮ', 5),
								  ('31', '15', '', N'ĐEN', 'L', 225000, N'NỮ', 5);

INSERT INTO ACCOUNTTYPE VALUES ('TYP01', 'ACCOUNT ADMIN'),
							   ('TYP02', 'ACCOUNT VIP'), 
							   ('TYP03', 'ACCOUNT THƯỜNG');

INSERT INTO ACCOUNT VALUES ('admin', 'admin', 'TYP01'),
						   ('admin2', 'admin2', 'TYP01'),
						   ('admin3', 'admin3', 'TYP01'),
						   ('user01', '12345', 'TYP02'),
						   ('user02', '12345', 'TYP03');

INSERT INTO ACCOUNTADMIN VALUES ('1', N'QUỐC', '',0977001541, 'admin'),
								('2', N'PHƯỚC', '','', 'admin2'),
								('3', N'TÀI', '','', 'admin3');

INSERT INTO KHACHHANG VALUES ('1',N'Thảo','nguyenchauthao@gmail.com',012244333, N'172/12 Trần Phú, Q5, TP HCM', 'user01'),
							 ('2',N'Hoài','vovanhoai@gmail.com',012255666, N'30/10 Trần Hưng Đạo, Q1, TP HCM', 'user02');	

INSERT INTO HOADON VALUES ('1','0951243215','hakaakaa@gmail.com', '11/12/2016', '385000', N'Đã đặt hàng'),
						  ('2','01654231544','lmaanshawi@gmail.com', '11/12/2016', '385000', N'Đã đặt hàng'),
						  ('3','0954213114','uuuss2aa@gmail.com', '11/12/2016', '385000', N'Đã đặt hàng');

INSERT INTO CHITIETHOADON VALUES ('1', '2', '1', 1),
								 ('2', '3', '1', 2),
								 ('3', '1', '2', 1),
								 ('4', '3', '2', 1),
								 ('5', '7', '3', 1),
								 ('6', '11', '3', 1);
								 