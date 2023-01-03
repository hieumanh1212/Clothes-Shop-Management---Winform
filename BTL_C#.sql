use CSDL_BTL_C#
go

--Bảng khách hàng
create table KhachHang
(
	MaKH nvarchar(30) not null,
	TenKH nvarchar(50) not null,
	GioiTinh nvarchar(30) not null,
	NgaySinh datetime not null,
	DiaChi nvarchar(50) not null,
	DienThoai nvarchar(20) not null,

	Constraint pk_khachhang primary key(MaKH)
);

-- Bảng Voucher
create table Voucher
(
	MaVoucher nvarchar(30) not null,
	TenVoucher nvarchar(50) not null,
	PhanTram int not null,
	SoLuong int not null,
	NgayBatDau datetime,
	NgayKetThuc datetime

	Constraint pk_voucher primary key(MaVoucher)
);

-- Bảng chất liệu
create table ChatLieu
(
	MaChatLieu nvarchar(30) not null,
	TenChatLieu nvarchar(50) not null,

	Constraint pk_chatlieu primary key(MaChatLieu)
);

-- Bảng chức vụ
create table ChucVu
(
	MaChucVu nvarchar(30) not null,
	TenChucVu nvarchar(50) not null,

	Constraint pk_chucvu primary key(MaChucVu)
);

-- Bảng nhà cung cấp
create table NhaCungCap
(
	MaNhaCungCap nvarchar(30) not null,
	TenNhaCungCap nvarchar(50) not null,

	Constraint pk_nhacungcap primary key(MaNhaCungCap)
);

-- Bảng thể loại
create table TheLoai
(
	MaTheLoai nvarchar(30) not null,
	TenTheLoai nvarchar(50) not null,

	Constraint pk_theloai primary key(MaTheLoai)
);

-- Bảng nhân viên
create table NhanVien
(
	MaNV nvarchar(30) not null,
	TenNV nvarchar(50) not null,
	GioiTinh nvarchar(10) not null,
	NgaySinh datetime not null,
	DiaChi nvarchar(50) not null,
	DienThoai nvarchar(20) not null,
	MaChucVu nvarchar(30) not null,
	Anh nvarchar(100) not null,

	Constraint pk_nhanvien primary key(MaNV),
	Constraint fk_nhanvien foreign key(MaChucVu) references ChucVu(MaChucVu)
);

-- Hóa đơn bán
create table HoaDonBan
(
	MaHDB nvarchar(30) not null,
	MaNV nvarchar(30) not null,
	MaKH nvarchar(30) not null,
	MaVoucher nvarchar(30) not null,
	NgayBan datetime not null,
	TongTienHDB money not null,

	constraint pk_hoadonban primary key(MaHDB),
	constraint fk_hoadonban_nhanien foreign key(MaNV) references NhanVien(MaNV),
	constraint fk_hoadonban_khachhang foreign key(MaKH) references KhachHang(MaKH),
	constraint fk_hoadonban_voucher foreign key(MaVoucher) references Voucher(MaVoucher)
);

-- Hóa đơn nhập
create table HoaDonNhap
(
	MaHDN nvarchar(30) not null,
	MaNhaCungCap nvarchar(30) not null,
	MaNV nvarchar(30) not null,
	NgayNhap datetime not null,
	TongTienHDN money not null,

	constraint pk_hoadonnhap primary key (MaHDN),
	constraint fk_hoadonnhap_ncc foreign key(MaNhaCungCap) references NhaCungCap(MaNhaCungCap),
	constraint fk_hoadonnhap_nhanvien foreign key(MaNV) references NhanVien(MaNV)
);

-- Bảng sản phẩm
create table SanPham
(
	MaSP nvarchar(30) not null,
	TenSP nvarchar(50) not null,
	MaChatLieu nvarchar(30) not null,
	MaTheLoai nvarchar(30) not null,
	Anh nvarchar(100) not null,
	GiamGia int 

	constraint pk_sanpham primary key(MaSP),
	constraint fk_sanpham_chatlieu foreign key(MaChatLieu) references ChatLieu(MaChatLieu),
	constraint fk_sanpham_theloai foreign key(MaTheLoai) references TheLoai(MaTheLoai)
);

-- Chi Tiết Sản Phẩm
create table ChiTietSanPham
(
	MaChiTietSP nvarchar(30) not null,
	MaSP nvarchar(30) not null,
	Size nvarchar(30),
	DonGiaNhap money,
	DonGiaBan money,
	SoLuong int,

	constraint pk_chitietsanpham primary key(MaChiTietSP),
	constraint fk_masp foreign key (MaSP) references SanPham (MaSP),

)

alter table ChiTietSanPham
add MauSac nvarchar(30)

-- Chi tiết hóa đơn nhập
create table ChiTietHDN
(
	MaChiTietSP nvarchar(30) not null,
	MaHDN nvarchar(30) not null,
	SLNhap int not null,
	ThanhTienHDN money not null

	constraint pk_chitiethdn primary key (MaChiTietSP, MaHDN),
	constraint fk_chitiethdn_sp foreign key(MaChiTietSP) references ChiTietSanPham(MaChiTietSP),
	constraint fk_chitiethdn_hdn foreign key(MaHDN) references HoaDonNhap(MaHDN)
);

alter table ChiTietHDN
drop constraint fk_chitiethdn_sp

--Chi tiết hóa đơn bán
create table ChiTietHDB
(
	MaChiTietSP nvarchar(30) not null,
	MaHDB nvarchar(30) not null,
	SLBan int not null,
	ThanhTienHDB money not null, 

	constraint pk_chitiethdb primary key (MaChiTietSP, MaHDB),
	constraint fk_chitiethdb_sp foreign key(MaChiTietSP) references ChiTietSanPham(MaChiTietSP),
	constraint fk_chitiethdb_hdb foreign key(MaHDB) references HoaDonBan(MaHDB)
);

alter table ChiTietHDB
drop constraint fk_chitiethdb_sp

-- Bảng User
create table tblUser
(
	MaNV nvarchar(30) not null,
	TenDangNhap nvarchar(50) not null,
	MatKhau nvarchar(200) not null,

	constraint pk_user primary key(TenDangNhap),
	constraint fk_user foreign key(MaNV) references NhanVien(MaNV)
);



-- Xóa tất cả bảng
drop table SizeSanPham
drop table Size
drop table tblUser
drop table ChiTietHDB
drop table ChiTietHDN
drop table KhoHang
drop table SanPham
drop table HoaDonNhap
drop table HoaDonBan
drop table NhanVien
drop table NhaCungCap
drop table ChucVu
drop table ChatLieu
drop table Voucher
drop table KhachHang



-------------------------------------------------------------------TRIGGER----------------------------------------------------
-- 1 . Cập nhật ThanhTienHDN = SLNhap*DonGiaNhap
-- 2 . Cập nật tổng tiền HĐN khi thêm sưae xóa ChiTietHDN

create trigger ThanhTienHDN on dbo.ChiTietHDN
for insert, update
as
begin
	declare @mahdn nvarchar(30), @soluongthem int, @masanpham nvarchar(30), @dongia money
	select @mahdn = MaHDN, @soluongthem = SLNhap, @masanpham = MaChiTietSP from inserted
	select @dongia = DonGiaNhap from ChiTietSanPham where MaChiTietSP = @masanpham
	Update ChiTietHDN set ThanhTienHDN = @soluongthem * @dongia 
	where MaHDN = @mahdn and MaChiTietSP = @masanpham
end
-- Trigger TongTienHDN của HoaDonNhap
create trigger TongTienHDN on dbo.ChiTietHDN
for insert, update, delete
as
begin
	declare @mahdnthem nvarchar(30), @thanhtienthem money, @mahdnxoa nvarchar(30), @thanhtienxoa money
	select @mahdnthem = MaHDN, @thanhtienthem = ThanhTienHDN from inserted
	select @mahdnxoa = MaHDN, @thanhtienxoa = ThanhTienHDN from deleted

	Update HoaDonNhap set TongTienHDN = isnull(TongTienHDN, 0) + isnull(@thanhtienthem, 0)
	where MaHDN = @mahdnthem
	Update HoaDonNhap set TongTienHDN = isnull(TongTienHDN, 0) - isnull(@thanhtienxoa, 0)
	where MaHDN = @mahdnxoa
end



-- 3. Cập nhật ThanhTienHDB = SLBan*DonGiaBan(Có thể có giảm giá)
-- 4. Cập nhật Tổng tiền HDB khi thêm sửa xóa chi tiết hóa đơn bán
create trigger ThanhTienHDB on dbo.ChiTietHDB
for insert, update
as
begin
		-- Cập nhật tự động Thành Tiền HĐB
		declare @mahdb_in nvarchar(30), @machitietsp_in nvarchar(30), @dongiaban money, @soluongban int
		select @mahdb_in = MaHDB, @machitietsp_in = MaChiTietSP, @soluongban = SLBan from inserted
		select @dongiaban = DonGiaBan from ChiTietSanPham where MaChiTietSP = @machitietsp_in

		Update ChiTietHDB set ThanhTienHDB = @soluongban * @dongiaban
		where MaChiTietSP = @machitietsp_in and MaHDB = @mahdb_in
end

-- Trigger TongTienHDB của HoaDonBan
create trigger TongTienHDB on dbo.ChiTietHDB
for insert, update, delete
as
begin
	declare @mahdbthem nvarchar(30), @thanhtienthem money, @mahdbxoa nvarchar(30), @thanhtienxoa money
	select @mahdbthem = MaHDB, @thanhtienthem = ThanhTienHDB from inserted
	select @mahdbxoa = MahDB, @thanhtienxoa = ThanhTienHDB from deleted

	Update HoaDonBan set TongTienHDB = isnull(TongTienHDB, 0) + isnull(@thanhtienthem, 0)
	where MaHDB = @mahdbthem
	Update HoaDonBan set TongTienHDB = isnull(TongTienHDB, 0) - isnull(@thanhtienxoa, 0)
	where MaHDB = @mahdbxoa
end
-- 5. Nếu áp dụng Voucher thì giảm số lượng Voucher
go
alter Trigger GiamVoucher_HDB on HoaDonBan
for insert, update, delete
as
begin 
	declare @Voucher_in nvarchar(40), @Voucher_de nvarchar(50)
	select @Voucher_in = MaVoucher from inserted
	select @Voucher_de = MaVoucher from deleted

	update Voucher
	set SoLuong = SoLuong - 1
	where MaVoucher = @Voucher_in

	update Voucher
	set SoLuong = SoLuong + 1
	where MaVoucher = @Voucher_de

	declare @SoLuong int
	select @SoLuong = SoLuong from Voucher
	where MaVoucher = @Voucher_in

	if @SoLuong < 0
		ROLLBACK 
end 


-- 6. Cập nhật số lượng của ChiTietSanPham mỗi khi nhập/ bán
-- cập khi khi tạo Chi tiết hóa đơn bán
go 
create trigger CapNhatSoLuong_HDB on ChiTietHDB
for insert, update, delete
as 
begin

	declare @MaChiTietSP_in nvarchar(40), @MaChiTietSP_de nvarchar(255)
	declare @Soluong_in int, @SoLuong_de int	

	select @MaChiTietSP_in = MaChiTietSP, @Soluong_in = SLBan from inserted
	select @MaChiTietSP_de = MaChiTietSP, @Soluong_de = SLBan from deleted


	update ChiTietSanPham
	set SoLuong = SoLuong - @Soluong_in
	where MaChiTietSP = @MaChiTietSP_in

	update ChiTietSanPham
	set SoLuong = SoLuong + @Soluong_de
	where MaChiTietSP = @MaChiTietSP_de

	declare @SoLuong int
	select @SoLuong = SoLuong from ChiTietSanPham
	where MaChiTietSP = @MaChiTietSP_in

	if @SoLuong < 0
		ROLLBACK 

end
-- cập khi khi tạo Chi tiết hóa đơn nhập
go 
create trigger CapNhatSoLuong_HDN on ChiTietHDN
for insert, update, delete
as 
begin

	declare @MaChiTietSP_in nvarchar(40), @MaChiTietSP_de nvarchar(255)
	declare @Soluong_in int, @Soluong_de int

	select @MaChiTietSP_in = MaChiTietSP, @Soluong_in = SLNhap from inserted
	select @MaChiTietSP_de = MaChiTietSP, @Soluong_de = SLNhap from deleted

	update ChiTietSanPham
	set SoLuong = SoLuong + @Soluong_in
	where MaChiTietSP = @MaChiTietSP_in

	update ChiTietSanPham
	set SoLuong = SoLuong - @Soluong_de
	where MaChiTietSP = @MaChiTietSP_de

 
end

-- 7.
--7.1 Nếu xóa hóa đơn bán thì xóa chi tiết hóa bán tương ứng
go
create trigger XoaHoaDon_AllChiTietHDB on HoaDonBan
instead of Delete
as
begin 

	declare @MaHDB nvarchar(255)
	select @MaHDB = MaHDB from deleted

	delete ChiTietHDB where MaHDB = @MaHDB
	delete HoaDonBan where MaHDB = @MaHDB
end


--7.2 Nếu xóa hóa đơn nhập thì xóa chi tiết hóa bán nhập tương ứng
go
create trigger XoaHoaDon_AllChiTietHDN on HoaDonNhap
instead of Delete
as
begin 

	declare @MaHDN nvarchar(255)
	select @MaHDN = MaHDN from deleted

	delete ChiTietHDN where MaHDN = @MaHDN
	delete HoaDonNhap where MaHDN = @MaHDN
end

-- Nếu xóa sản phẩm thì xóa chi tiết sản phẩm
create trigger xoaCTSP on SanPham
instead of delete as
begin
	declare @masp nvarchar(20)
	select @masp = MaSP from deleted
	Delete from ChiTietSanPham where MaSP = @masp
	Delete from SanPham where MaSP = @masp	
end

select * from ChiTietSanPham
