USE master;
GO

-- Xóa database nếu đã tồn tại
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'CafeManagement')
    DROP DATABASE CafeManagement;
GO

-- Tạo database mới
CREATE DATABASE CafeManagement;
GO

USE CafeManagement;
GO

-- Bảng Tài Khoản
CREATE TABLE TaiKhoan (
    TenDangNhap VARCHAR(20) PRIMARY KEY,
    MatKhau VARCHAR(64),  -- Để lưu mật khẩu mã hóa
    TrangThai bit,
    vaitro NVARCHAR(30),
    HoTen NVARCHAR(50),
    Email NVARCHAR(100)
);

-- Bảng Loại Sản Phẩm
CREATE TABLE LoaiSanPham (
    MaLoai CHAR(4) PRIMARY KEY,
    TenLoai NVARCHAR(50)
);

-- Bảng Sản Phẩm
CREATE TABLE SanPham (
    MaSp CHAR(5) PRIMARY KEY,
    MaLoai CHAR(4) NOT NULL,
    TenSp NVARCHAR(100),
    HinhAnh VARBINARY(MAX),  -- Lưu ảnh sản phẩm
    GiaBan INT,
    TrangThai NVARCHAR(15),
    FOREIGN KEY (MaLoai) REFERENCES LoaiSanPham(MaLoai)
);


-- Bảng Ca Làm Việc
CREATE TABLE CaLamViec (
    MaCaLam CHAR(6) PRIMARY KEY,
    TenDangNhap VARCHAR(20) NOT NULL,         
    TgBatDau DATETIME,
    TgKetThuc DATETIME,
	TienDauCa INT,
    TienCuoiCa INT,
    GhiChu NVARCHAR(MAX) NULL,
    FOREIGN KEY (TenDangNhap) REFERENCES TaiKhoan(TenDangNhap)
);	

-- Bảng Loại Nguyên Liệu
CREATE TABLE LoaiNguyenLieu (
    MaLoaiNL CHAR(6) PRIMARY KEY,
    TenLoai NVARCHAR(50)
);

-- Bảng Nguyên Liệu
CREATE TABLE NguyenLieu (
    MaNL CHAR(6) PRIMARY KEY,
    MaLoaiNL CHAR(6) NOT NULL,
    TenNL NVARCHAR(100),
    DonVi NVARCHAR(20),
	GiaNhap int,
	SoLuongTon DECIMAL(10, 2) DEFAULT 0,
	MucToiThieu INT DEFAULT 0,
	MucOnDinh INT DEFAULT 0,
    FOREIGN KEY (MaLoaiNL) REFERENCES LoaiNguyenLieu(MaLoaiNL)
);

-- Bảng Định Lượng
CREATE TABLE DinhLuong (
	MaSp CHAR(5) NOT NULL,
	MaNL CHAR(6) NOT NULL,
	SoLuong DECIMAL(10, 2),
	PRIMARY KEY (Masp, MaNL),
    FOREIGN KEY (Masp) REFERENCES SanPham(MaSp),
    FOREIGN KEY (MaNL) REFERENCES NguyenLieu(MaNL)
);

-- Bảng Phiếu Nhập Kho
CREATE TABLE PhieuNhapKho (
    MaPhieuNhap CHAR(6) PRIMARY KEY,
    TenDangNhap VARCHAR(20) NOT NULL,
    NgayLap DATETIME DEFAULT GETDATE(),
    GhiChu NVARCHAR(MAX),
    FOREIGN KEY (TenDangNhap) REFERENCES TaiKhoan(TenDangNhap)
);

-- Bảng Chi Tiết Nhập Kho (Chỉ liên quan đến nguyên liệu)
CREATE TABLE ChiTietNhapKho (
    MaPhieuNhap CHAR(6) NOT NULL,
    MaNL CHAR(6) NOT NULL,
    GiaNhap INT,
    SoLuong DECIMAL(10, 2),
    PRIMARY KEY (MaPhieuNhap, MaNL),
    FOREIGN KEY (MaPhieuNhap) REFERENCES PhieuNhapKho(MaPhieuNhap),
    FOREIGN KEY (MaNL) REFERENCES NguyenLieu(MaNL)
);
go

-- Bảng Phiếu Xuất Kho
CREATE TABLE PhieuXuatKho (
    MaPhieuXuat CHAR(6) PRIMARY KEY,
    TenDangNhap VARCHAR(20) NOT NULL,
    NgayXuat DATETIME DEFAULT GETDATE(),
    GhiChu NVARCHAR(MAX),
    FOREIGN KEY (TenDangNhap) REFERENCES TaiKhoan(TenDangNhap)
);

-- Bảng Chi Tiết Xuất Kho (Chỉ liên quan đến nguyên liệu)
CREATE TABLE ChiTietXuatKho (
    MaPhieuXuat CHAR(6) NOT NULL,
    MaNL CHAR(6) NOT NULL,
    SoLuong DECIMAL(10, 2),
    PRIMARY KEY (MaPhieuXuat, MaNL),
    FOREIGN KEY (MaPhieuXuat) REFERENCES PhieuXuatKho(MaPhieuXuat),
    FOREIGN KEY (MaNL) REFERENCES NguyenLieu(MaNL)
);


CREATE TABLE TheRung (
    MaThe CHAR(4) PRIMARY KEY,
    SoThe NVARCHAR(5),           
    TrangThai TINYINT      -- 0: Rảnh, 1: Đang dùng
);

-- Bảng Đơn Hàng
CREATE TABLE DonHang (
    MaDonHang CHAR(7) PRIMARY KEY,
    MaCaLap CHAR(6) NOT NULL,                  -- Ca làm của người lập
    MaCaThanhToan CHAR(6),                     -- Ca làm lúc thanh toán (nếu khác)
    MaThe CHAR(4),                             -- Thẻ rung cấp cho khách
    GiamGia TINYINT DEFAULT 0,
    NgayLap DATETIME DEFAULT GETDATE(),        -- Thời điểm order
    TongTien INT,
    TrangThai TINYINT,                         -- 0: Chờ, 1: Hoàn tất
    LoaiThanhToan TINYINT,                     -- 0: Tiền mặt, 1: Chuyển khoản
    GhiChu NVARCHAR(MAX),                      -- Ghi chú đặc biệt nếu có

    FOREIGN KEY (MaCaLap) REFERENCES CaLamViec(MaCaLam),
    FOREIGN KEY (MaCaThanhToan) REFERENCES CaLamViec(MaCaLam),
    FOREIGN KEY (MaThe) REFERENCES TheRung(MaThe)
);

-- Bảng Chi Tiết Đơn Hàng (Liên quan đến sản phẩm)
CREATE TABLE ChiTietDonHang (
    MaDonHang CHAR(7) NOT NULL,
    MaSp CHAR(5) NOT NULL,
    DonGia INT,
    SoLuong INT,
    PRIMARY KEY (MaDonHang, MaSp),
    FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang),
    FOREIGN KEY (MaSp) REFERENCES SanPham(MaSp)
);

-- Tạo bảng LoaiThuChi
CREATE TABLE LoaiThuChi (
    MaLoaiThuChi CHAR(4) PRIMARY KEY, 
    TenLoai NVARCHAR(MAX) NOT NULL,     -- VD: "Thu từ đơn hàng", "Chi lương nhân viên"
    Loai CHAR(3) CHECK (Loai IN ('Thu', 'Chi')) -- Xác định đây là loại thu hay chi
);

-- Tạo bảng PhieuThuChi
CREATE TABLE PhieuThuChi (
    MaPhieu CHAR(10) PRIMARY KEY,
    TenDangNhap VARCHAR(20) NOT NULL,
    SoTien BIGINT NOT NULL,
    MaLoaiThuChi CHAR(4) NOT NULL,
	NgayLap Datetime default getdate(),
    GhiChu NVARCHAR(MAX),
    FOREIGN KEY (TenDangNhap) REFERENCES TaiKhoan(TenDangNhap),
    FOREIGN KEY (MaLoaiThuChi) REFERENCES LoaiThuChi(MaLoaiThuChi)
);
go

insert into TaiKhoan values('admin', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1, 'admin', 'admin', '');
go

INSERT INTO LoaiThuChi (MaLoaiThuChi, TenLoai, Loai)
VALUES 
    ('TC01', N'Thu từ đơn hàng', 'Thu'),
    ('TC02', N'Chi tiền nhập kho', 'Chi');
		
INSERT INTO LoaiSanPham (MaLoai, TenLoai) VALUES
('L001', N'Cà phê'),
('L002', N'Trà'),
('L003', N'Trà sữa'),
('L004', N'Matcha'),
('L005', N'Nước ép & Sinh tố'),
('L006', N'Soda'),
('L007', N'Món ăn vặt');
go

--Thêm sản phẩm
INSERT INTO SanPham (MaSp, MaLoai, TenSp, HinhAnh, GiaBan, TrangThai)
VALUES
-- Các sản phẩm thuộc loại "Cà phê" (L001)
('SP001', 'L001', N'Cà Phê Sữa', NULL, 25000, N'Còn Bán'),
('SP002', 'L001', N'Cà Phê Đen Nóng', NULL, 23000, N'Còn Bán'),
('SP003', 'L001', N'Bạc xỉu', NULL, 30000, N'Còn Bán'),

-- Các sản phẩm thuộc loại "Trà" (L002)
('SP004', 'L002', N'Nước Ép Cam', NULL, 25000, N'Còn Bán'),
('SP005', 'L002', N'Trà Vải', NULL, 29000, N'Còn Bán'),
('SP006', 'L002', N'Trà Đào Cam Sả', NULL, 30000, N'Còn Bán'),

-- Các sản phẩm thuộc loại "Trà sữa" (L003)
('SP007', 'L003', N'Nước Ép Dứa', NULL, 28000, N'Còn Bán'),
('SP008', 'L003', N'Trà Sữa Trân Châu', NULL, 35000, N'Còn Bán'),

-- Các sản phẩm thuộc loại "Matcha" (L004)
('SP009', 'L004', N'Sinh Tố Dâu', NULL, 35000, N'Còn Bán'),
('SP010', 'L004', N'Sinh Tố Bơ', NULL, 35000, N'Còn Bán'),

-- Các sản phẩm thuộc loại "Nước ép & Sinh tố" (L005)
('SP011', 'L005', N'Bánh Mì Phô Mai', NULL, 15000, N'Còn Bán'),
('SP012', 'L005', N'Bánh Ngọt Socola', NULL, 20000, N'Còn Bán'),
('SP013', 'L005', N'Sinh Tố Xoài', NULL, 35000, N'Còn Bán'),

-- Các sản phẩm thuộc loại "Soda" (L006)
('SP014', 'L006', N'Soda Việt Quất', NULL, 32000, N'Còn Bán'),
('SP015', 'L006', N'Soda Bạc Hà', NULL, 31000, N'Còn Bán');


go

-- Thêm lại danh sách loại nguyên liệu
INSERT INTO LoaiNguyenLieu (MaLoaiNL, TenLoai) VALUES
('ML001', N'Nguyên liệu pha chế'),
('ML002', N'Nguyên liệu đồ ăn'),
('ML003', N'Nguyên liệu khác');
go

-- Thêm lại nguyên liệu theo loại mới
INSERT INTO NguyenLieu (MaNL, MaLoaiNL, TenNL, DonVi, GiaNhap, SoLuongTon, MucToiThieu, MucOnDinh)
VALUES
-- NL001: Nguyên liệu pha chế
('NL001', 'ML001', N'Cà phê hạt', N'Kg', 120000, 5, 1, 3),
('NL002', 'ML001', N'Sữa đặc', N'Hộp', 25000, 20, 3, 10),
('NL003', 'ML001', N'Sữa tươi', N'Lít', 30000, 10, 2, 6),
('NL004', 'ML001', N'Bột matcha', N'Kg', 150000, 5, 1, 3),
('NL005', 'ML001', N'Trà đen', N'Kg', 100000, 10, 2, 6),
('NL006', 'ML001', N'Siro dâu', N'Lít', 50000, 5, 1, 3),
('NL007', 'ML001', N'Nước ép cam', N'Lít', 45000, 5, 1, 3),
('NL008', 'ML001', N'Đường cát', N'Kg', 20000, 10, 2, 5),
('NL009', 'ML001', N'Đá viên', N'Kg', 5000, 40, 10, 20),
('NL010', 'ML001', N'Bột ca cao', N'Kg', 120000, 8, 2, 5),

-- NL002: Nguyên liệu đồ ăn
('NL011', 'ML002', N'Khoai tây', N'Kg', 25000, 5, 1, 3),
('NL012', 'ML002', N'Phô mai lát', N'Gói', 35000, 25, 5, 10),
('NL013', 'ML002', N'Trứng gà', N'Quả', 3000, 50, 10, 30),
('NL014', 'ML002', N'Bánh mì', N'Cái', 8000, 30, 10, 20),
('NL015', 'ML002', N'Sốt mayonnaise', N'Chai', 20000, 15, 5, 10),

-- NL003: Nguyên liệu khác
('NL016', 'ML003', N'Lá bạc hà', N'Gram', 1000, 500, 50, 200),
('NL017', 'ML003', N'Chanh tươi', N'Quả', 5000, 30, 5, 15),
('NL018', 'ML003', N'Siro blue curacao', N'Lít', 60000, 10, 2, 5),
('NL019', 'ML003', N'Nước lọc tinh khiết', N'Lít', 10000, 100, 20, 50);
go


INSERT INTO TheRung (MaThe, SoThe, TrangThai) VALUES
('T001', '1', 0),
('T002', '2', 0),
('T003', '3', 0),
('T004', '4', 0),
('T005', '5', 0),
('T006', '6', 0),
('T007', '7', 0),
('T008', '8', 0),
('T009', '9', 0),
('T010', '10', 0);
go


INSERT INTO PhieuThuChi (MaPhieu, TenDangNhap, SoTien, MaLoaiThuChi, NgayLap, GhiChu)
VALUES
-- Tháng -5
('PT00000001', 'admin', 95000, 'TC01', DATEADD(MONTH, -5, GETDATE()), N'DH00001'),
('PC00000001', 'admin', 300000, 'TC02', DATEADD(MONTH, -5, GETDATE()), N''),

-- Tháng -4
('PT00000002', 'admin', 120000, 'TC01', DATEADD(MONTH, -4, GETDATE()), N'DH00002'),
('PC00000002', 'admin', 280000, 'TC02', DATEADD(MONTH, -4, GETDATE()), N''),

-- Tháng -3
('PT00000003', 'admin', 150000, 'TC01', DATEADD(MONTH, -3, GETDATE()), N'DH00003'),
('PC00000003', 'admin', 350000, 'TC02', DATEADD(MONTH, -3, GETDATE()), N''),

-- Tháng -2
('PT00000004', 'admin', 110000, 'TC01', DATEADD(MONTH, -2, GETDATE()), N'DH00004'),
('PC00000004', 'admin', 270000, 'TC02', DATEADD(MONTH, -2, GETDATE()), N''),

-- Tháng -1
('PT00000005', 'admin', 180000, 'TC01', DATEADD(MONTH, -1, GETDATE()), N'DH00005'),
('PC00000005', 'admin', 300000, 'TC02', DATEADD(MONTH, -1, GETDATE()), N''),

-- Tháng hiện tại
('PT00000006', 'admin', 135000, 'TC01', GETDATE(), N'DH00006'),
('PC00000006', 'admin', 310000, 'TC02', GETDATE(), N'');
go

-- Trigger cập nhật số lượng tồn kho khi nhập kho
CREATE TRIGGER trg_CapNhatTonKhoNhap
ON ChiTietNhapKho
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE nl
    SET nl.SoLuongTon = nl.SoLuongTon + i.SoLuong
    FROM NguyenLieu nl
    INNER JOIN INSERTED i ON nl.MaNL = i.MaNL;
END;
GO

CREATE TRIGGER trg_UpdateGiaNhapNguyenLieu
ON ChiTietNhapKho
AFTER INSERT, UPDATE
AS
BEGIN
    -- Cập nhật giá nhập của nguyên liệu theo giá mới nhất từ bản ghi được thêm/cập nhật
    UPDATE NL
    SET NL.GiaNhap = I.GiaNhap
    FROM NguyenLieu NL
    INNER JOIN INSERTED I ON NL.MaNL = I.MaNL
END
go

-- Trigger cập nhật số lượng tồn kho khi xuất kho
CREATE TRIGGER trg_CapNhatTonKhoXuat
ON ChiTietXuatKho
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE nl
    SET nl.SoLuongTon = nl.SoLuongTon - i.SoLuong
    FROM NguyenLieu nl
    INNER JOIN INSERTED i ON nl.MaNL = i.MaNL;
END;	
GO


--Hàm lấy mã loại theo tên loại
CREATE FUNCTION dbo.LayMaloaiTheoTenloai (
    @TenLoai NVARCHAR(50)
)
RETURNS CHAR(5)
AS
BEGIN
    DECLARE @MaLoai CHAR(5)

    SELECT TOP 1 @MaLoai = MaLoai
    FROM LoaiSanPham
    WHERE TenLoai = @TenLoai
    ORDER BY MaLoai DESC;

    RETURN @MaLoai
END;
Go


--Hàm lấy mã sản phẩm theo tên sản phẩm
CREATE FUNCTION dbo.LayMaSpTheoTenSp (@TenSp NVARCHAR(100))
RETURNS CHAR(6)
AS
BEGIN
    DECLARE @MaSp CHAR(6);
    SELECT top 1 @MaSp = MaSp
    FROM SanPham
    WHERE TenSp = @TenSp
	ORDER BY MaSp DESC;
    RETURN @MaSp;
END;
GO

--Hàm lấy mã nguyên liệu theo tên nguyên liệu
CREATE FUNCTION dbo.LayMaNlTheoTenNl (@TenNL NVARCHAR(100))
RETURNS CHAR(6)
AS
BEGIN
    DECLARE @MaNL CHAR(6);
    SELECT TOP 1 @MaNL = MaNL
    FROM NguyenLieu
    WHERE TenNL = @TenNL
    ORDER BY MaNL DESC;
    RETURN @MaNL;
END;
GO

--Hàm lấy mã loại nguyên liệu theo tên nguyên liệu
CREATE FUNCTION dbo.LayMaloaiNLTheoTenloaiNL (@TenLoai NVARCHAR(50))
RETURNS CHAR(6) 
AS
BEGIN
    DECLARE @MaLoai CHAR(6);

    SELECT TOP 1 @MaLoai = MaLoaiNL
    FROM LoaiNguyenLieu
    WHERE TenLoai = @TenLoai
    ORDER BY MaLoaiNL DESC;

    RETURN @MaLoai;
END;
Go

CREATE VIEW vw_HoaDonChiTiet AS
SELECT 
    dh.MaDonHang,
    dh.NgayLap,
    tr.SoThe,                          
    dh.GiamGia,
    dh.TongTien,
    dh.GhiChu,
    sp.TenSp,
    ct.DonGia,
    ct.SoLuong,
    (ct.DonGia * ct.SoLuong) AS ThanhTien

FROM DonHang dh
JOIN ChiTietDonHang ct ON dh.MaDonHang = ct.MaDonHang
JOIN SanPham sp ON ct.MaSp = sp.MaSp
LEFT JOIN TheRung tr ON dh.MaThe = tr.MaThe;
go

