IF DB_ID('BookStoreManagement') IS NULL 
	CREATE DATABASE BookStoreManagement
GO

USE [BookStoreManagement]
GO


--BOOKSHOP MANAGEMENT SYSTEM
CREATE TABLE BookCategory (
    CategoryID VARCHAR(10) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL
);
go

INSERT INTO BookCategory (CategoryID, CategoryName) VALUES 
	('CAT1', N'Tiểu thuyết'),
	('CAT2', N'Sách nước ngoài'),
	('CAT3', N'Kinh tế'),
	('CAT4', N'Thiếu nhi'),
	('CAT5', N'Tâm lý - Kỹ năng sống');
go

CREATE TABLE Book(
		BookID VARCHAR(50) PRIMARY KEY,
		BookName NVARCHAR(100) NOT NULL,
		CategoryID VARCHAR(10) FOREIGN KEY REFERENCES BookCategory(CategoryID),
		Author NVARCHAR(100) NOT NULL,
		Price INT NOT NULL,
		BookImage NVARCHAR(255)
);
go

INSERT INTO Book VALUES('BOOK1',N'Cây Cam Ngọt Của Tôi','CAT1',N'José Mauro de Vasconcelos', 80400, 'https://cdn1.fahasa.com/media/catalog/product/i/m/image_217480.jpg');
INSERT INTO Book VALUES('BOOK2',N'25 Độ Âm','CAT1',N'Thảo Trang', 210000, 'https://cdn1.fahasa.com/media/catalog/product/b/_/b_a-1-25-_-_m_1.jpg');
INSERT INTO Book VALUES('BOOK3',N'Người Đua Diều','CAT1',N'Khaled Hosseini', 96750, 'https://cdn1.fahasa.com/media/catalog/product/8/9/8935235237773.jpg');
INSERT INTO Book VALUES('BOOK4',N'Sapiens : A Brief History of Humankind','CAT2',N'Yuval Noah Harari', 276250, 'https://cdn1.fahasa.com/media/catalog/product/7/1/713jiomo3ul.jpg');
INSERT INTO Book VALUES('BOOK5',N'Flipped','CAT2',N'Van Draanen Wendelin', 210000, 'https://cdn1.fahasa.com/media/catalog/product/f/l/flipped_1_2018_08_22_11_41_29.jpg');
INSERT INTO Book VALUES('BOOK6',N'Think and Grow Rich','CAT2',N'Napoleon Hill', 230400, 'https://cdn1.fahasa.com/media/catalog/product/5/1/51dxwcr9fjl_1.jpg');
INSERT INTO Book VALUES('BOOK7',N'Bí Mật Tư Duy Triệu Phú (Tái Bản 2021)','CAT3',N'T Harv Eker', 78840, 'https://cdn1.fahasa.com/media/catalog/product/thumbnailframe/product_frame_ncc/frame_image_188995_1_1.jpg');
INSERT INTO Book VALUES('BOOK8',N'Người Giàu Có Nhất Thành Babylon','CAT3',N'Van Draanen Wendelin', 71540, 'https://cdn1.fahasa.com/media/catalog/product/i/m/image_195509_1_41914.jpg');
INSERT INTO Book VALUES('BOOK9',N'Ai Toàn Năng: Chinh Phục Thời Đại Số','CAT3',N'Ajay Agrawal, Joshua Gans', 126750, 'https://cdn1.fahasa.com/media/catalog/product/a/i/ai---c_ng-c_-n_ng-cao-hi_u-su_t-c_ng-vi_c-b_a-1.jpg');
INSERT INTO Book VALUES('BOOK10',N'Búp Sen Xanh (Tái Bản 2020)','CAT4',N'Sơn Tùng', 57600, 'https://cdn1.fahasa.com/media/catalog/product/b/u/bup-sen-xanh_bia_phien-ban-ky-niem-2020.jpg');
INSERT INTO Book VALUES('BOOK11',N'100 Kỹ Năng Sinh Tồn','CAT4',N'Clint Emerson', 70000, 'https://cdn1.fahasa.com/media/catalog/product/8/9/8935212351621.jpg');
INSERT INTO Book VALUES('BOOK12',N'Hoàng Tử Bé (Tái Bản 2022)','CAT4',N'Antoine De Saint-Exupéry', 22750, 'https://cdn1.fahasa.com/media/catalog/product/8/9/8935244868999.jpg');
INSERT INTO Book VALUES('BOOK13',N'Con Đường Chẳng Mấy Ai Đi','CAT5',N'M. Scott Peck', 99000, 'https://cdn1.fahasa.com/media/catalog/product/9/7/9786044009674.jpg');
INSERT INTO Book VALUES('BOOK14',N'Tư Duy Ngược','CAT5',N'Nguyễn Anh Dũng', 65330, 'https://cdn1.fahasa.com/media/catalog/product/9/7/9786043440287.jpg');
INSERT INTO Book VALUES('BOOK15',N'Manifest - 7 Bước Để Thay Đổi Cuộc Đời Bạn Mãi Mãi','CAT5',N'Roxie Nafousi', 62300, 'https://cdn1.fahasa.com/media/catalog/product/b/_/b_a-tr_c-manifest_1.jpg');
go
SELECT * FROM Book

CREATE TABLE Suppliers(
		Supplier_ID VARCHAR (55)NOT NULL,
		Supplier_name NVARCHAR(100) NOT NULL,
		Supplier_address NVARCHAR(255),
		Supplier_email VARCHAR(55),
		Supplier_phone VARCHAR(55) NOT NULL,
		PRIMARY KEY (Supplier_ID)
);
go

	INSERT INTO Suppliers VALUES('SUP1',N'AZ Việt Nam',N'Số 50 đường 5, TTF361 An Dương, P. Yên Phụ, Q. Tây Hồ, Tp. Hà Nội','bophanbanle@azbooks.vn','02437172838')
	INSERT INTO Suppliers VALUES('SUP2',N'Phụ Nữ',N'39 P. Hàng Chuối, Phạm Đình Hổ, Hai Bà Trưng, Hà Nội','truyenthongvaprnxbpn@gmail.com','02439710717')
	INSERT INTO Suppliers VALUES('SUP3',N'Penguin Boos',N'Colchester Road Frating Colchester, CO7 7DW','SN3@gmail.com','+44 1206 256000')
	INSERT INTO Suppliers VALUES('SUP4',N'Grantham Book Services',N'Trent Rd, Grantham NG31 7XQ, Vương quốc Anh','SN4@gmail.com','+44 1476 541000')
	INSERT INTO Suppliers VALUES('SUP5',N'Nhã Nam',N'Số 59, Đỗ Quang, Trung Hoà, Cầu Giấy, Hà Nội.','info@nhanam.vn','02435146876')
	INSERT INTO Suppliers VALUES('SUP6',N'Công ty cổ phần Sbooks',N'124 Đường số 2, KDC Vạn Phúc, P. Hiệp Bình Phước, TP. Thủ Đức, TP. Hồ Chí Minh','nhasachsbooks@gmail.com','0964234085')
go	
	SELECT * FROM Suppliers

	
create table Stock(
		StockID VARCHAR(50) PRIMARY KEY,
		SupplierID VARCHAR(55) FOREIGN KEY REFERENCES Suppliers(Supplier_ID),
		BookID VARCHAR(50) NOT NULL,
		CategoryID VARCHAR(10) FOREIGN KEY REFERENCES BookCategory(CategoryID),
		BookName NVARCHAR(100) NOT NULL,
		ImportDate DATETIME DEFAULT GETDATE(),
	    Quantity INT NOT NULL CHECK (Quantity >= 0)
);
go

	INSERT INTO Stock VALUES('STK1','SUP1','BOOK1','CAT1',N'Cây Cam Ngọt Của Tôi','2025-03-12', 250);
	INSERT INTO Stock VALUES('STK2','SUP1','BOOK2','CAT1',N'25 Độ Âm','2025-03-12', 200);
	INSERT INTO Stock VALUES('STK3','SUP2','BOOK3','CAT1',N'Người Đua Diều','2025-03-10', 300);
	INSERT INTO Stock VALUES('STK4','SUP3','BOOK4','CAT2',N'Sapiens : A Brief History of Humankind','2025-03-20', 400);
	INSERT INTO Stock VALUES('STK5','SUP3','BOOK5','CAT2',N'Flipped','2025-03-20', 350);
	INSERT INTO Stock VALUES('STK6','SUP4','BOOK6','CAT2',N'Think and Grow Rich','2025-03-20', 200);
	INSERT INTO Stock VALUES('STK7','SUP5','BOOK7','CAT3',N'Bí Mật Tư Duy Triệu Phú (Tái Bản 2021)','2025-03-15', 400);
	INSERT INTO Stock VALUES('STK8','SUP5','BOOK8','CAT3',N'Người Giàu Có Nhất Thành Babylon','2025-03-10', 500);
	INSERT INTO Stock VALUES('STK9','SUP6','BOOK9','CAT3',N'Ai Toàn Năng: Chinh Phục Thời Đại Số','2025-03-15', 500);
	INSERT INTO Stock VALUES('STK10','SUP6','BOOK10','CAT4',N'Búp Sen Xanh (Tái Bản 2020)','2025-03-15', 600);
	INSERT INTO Stock VALUES('STK11','SUP2','BOOK11','CAT4',N'100 Kỹ Năng Sinh Tồn','2025-03-05', 500);
	INSERT INTO Stock VALUES('STK12','SUP2','BOOK12','CAT4',N'Hoàng Tử Bé (Tái Bản 2022)','2025-03-05', 550);
	INSERT INTO Stock VALUES('STK13','SUP5','BOOK13','CAT5',N'Con Đường Chẳng Mấy Ai Đi','2025-03-05', 1000);
	INSERT INTO Stock VALUES('STK14','SUP1','BOOK14','CAT5',N'Tư Duy Ngược','2025-03-01', 800);
	INSERT INTO Stock VALUES('STK15','SUP6','BOOK15','CAT5',N'Manifest - 7 Bước Để Thay Đổi Cuộc Đời Bạn Mãi Mãi','2025-03-01', 1000);
go
	SELECT * FROM Stock
	ORDER BY CAST(SUBSTRING(StockID, 4, LEN(StockID)) AS INT);


CREATE TABLE Users (
    User_ID VARCHAR(30) PRIMARY KEY,
    Name NVARCHAR(30) NOT NULL, 
    Username VARCHAR(30) NOT NULL UNIQUE, -- Đảm bảo Username không trùng
    Password VARCHAR(50) NOT NULL,
    Email VARCHAR(50) NOT NULL UNIQUE, -- Email phải duy nhất
    Address NVARCHAR(100) NULL, -- Chỉ khách hàng cần nhập
    PhoneNumber VARCHAR(50) NULL, -- Dùng chung cho Customer & Staff
    Role VARCHAR(30) CHECK (Role IN ('Customer', 'Staff', 'Admin')) NOT NULL DEFAULT 'Customer'
);
go

-- Admin: Không cần nhập Address và PhoneNumber
	INSERT INTO Users (User_ID, Name, Username, Password, Email, Role) 
	VALUES 
	('A1', N'Ngọc Hân', 'Lele', '123', 'lele@gmail.com', 'Admin'),
	('A2',N'Hoàn Hảo', 'Hao', '123', 'hhao@gmail.com', 'Admin');
go
-- Manager, Customer: Cần nhập Address và PhoneNumber
	INSERT INTO Users (User_ID, Name, Username, Password, Email, Address, PhoneNumber, Role) 
	VALUES 
	('S1',N'Đan Hạnh', 'Tu', '000', 'tutu@gmail.com', 'Nhà Bè', '0123456789', 'Staff'),
	('S2',N'Phương Thảo', 'APT', '000', 'apt@gmail.com', 'Nhà Bè', '0223456789', 'Staff'),
	('S3',N'Gia Hân', 'Bao', '000', 'batman@gmail.com', 'Tân Bình', '0323456789', 'Staff'),
	('C1',N'Huệ Tin', 'Tin', '456', 'htk@gmail.com', N'Quận 7', '0987654321', 'Customer'),
	('C2',N'Hân Hân', 'hhan', '456', 'hhan@gmail.com', N'Nhà Bè', '0987654322', 'Customer'),
	('C3',N'Mỹ Diên', 'Dien', '456', 'mdien@gmail.com', N'Nhà Bè', '0987654323', 'Customer');
go
	SELECT * FROM Users

CREATE TABLE Customers (
    PhoneNumber VARCHAR(20) PRIMARY KEY,
	FullName NVARCHAR(100)
);

CREATE TABLE Orders (
    Order_ID VARCHAR(55) NOT NULL PRIMARY KEY, 
	PhoneNumber NVARCHAR(15) NOT NULL,
    Employee_ID VARCHAR(30), 
    Order_Date DATETIME NOT NULL DEFAULT GETDATE(), 
	Status NVARCHAR(20) DEFAULT 'Pending' CHECK (Status IN (N'Chờ xác nhận', N'Đã giao', N'Đã hoàn thành', N'Đã hủy')),

    -- Thiết lập khóa ngoại
    CONSTRAINT FK_Orders_Employee FOREIGN KEY (Employee_ID) REFERENCES Users(User_ID)
);
go

INSERT INTO Orders (Order_ID, PhoneNumber, Employee_ID, Order_Date, Status) 
VALUES 
    ('ORD1', '0987654321', 'S1', '2025-03-24', N'Đã giao'),
    ('ORD2', '0987654322', 'S2', '2025-04-01', N'Chờ xác nhận'),
    ('ORD3', '0987654323', 'S3', '2025-03-21', N'Đã hoàn thành'),
    ('ORD4', '0987654321', 'S1', '2025-04-02', N'Đã hủy'),
    ('ORD5', '0987654323', 'S3', '2025-04-01', N'Chờ xác nhận');
go

CREATE TABLE OrderDetails (
    OrderDetail_ID INT IDENTITY(1,1) PRIMARY KEY, 
    Order_ID VARCHAR(55) NOT NULL,
    StockID VARCHAR(50) NOT NULL, 
    Qty_sold INT CHECK (Qty_sold > 0),
	PriceAtOrderTime INT NOT NULL -- Cập nhật OrderDetails để lưu giá tại thời điểm đặt hàng

    -- Thiết lập khóa ngoại
    CONSTRAINT FK_OrderDetails_Order FOREIGN KEY (Order_ID) REFERENCES Orders(Order_ID),
    CONSTRAINT FK_OrderDetails_Stock FOREIGN KEY (StockID) REFERENCES Stock(StockID)
);
go

INSERT INTO OrderDetails (Order_ID, StockID, Qty_sold, PriceAtOrderTime)
VALUES ('ORD1', 'STK1', 2, 80400),  -- 2 cuốn "Cây Cam Ngọt Của Tôi"
       ('ORD1', 'STK3', 1, 96750),  -- 1 cuốn "Người Đua Diều"
       ('ORD2', 'STK4', 1, 276250),  
       ('ORD2', 'STK5', 1, 210000),
	   ('ORD3', 'STK15', 1, 62300),  
	   ('ORD3', 'STK14', 3, 65330),
	   ('ORD4', 'STK8', 1, 71540),  
	   ('ORD5', 'STK9', 1, 126750); 
go
SELECT * FROM OrderDetails
 
SELECT O.Order_ID, O.Order_Date, OD.StockID, S.BookName, OD.Qty_sold
FROM Orders O
JOIN OrderDetails OD ON O.Order_ID = OD.Order_ID
JOIN Stock S ON OD.StockID = S.StockID
WHERE O.Order_ID = 'ORD1';

	
CREATE TABLE Bill_Generate (
    Bill_ID VARCHAR(50) PRIMARY KEY,
    Order_ID VARCHAR(55) NOT NULL,
    Bill_Date DATE NOT NULL DEFAULT GETDATE(),
    Total_Cost INT CHECK (Total_Cost > 0) NOT NULL,

    -- Khóa ngoại tham chiếu đến Orders
    CONSTRAINT FK_Bill_Order FOREIGN KEY (Order_ID) REFERENCES Orders(Order_ID)
);
go

INSERT INTO Bill_Generate (Bill_ID, Order_ID, Total_Cost) 
SELECT 
    'BILL' + O.Order_ID,  -- Tạo mã Bill từ Order_ID
    O.Order_ID,  
    SUM(OD.PriceAtOrderTime * OD.Qty_sold) AS Total_Cost  
FROM Orders O
JOIN OrderDetails OD ON O.Order_ID = OD.Order_ID -- Lấy giá sách từ bảng OrderDetails
JOIN Stock S ON OD.StockID = S.StockID
GROUP BY O.Order_ID;
go
SELECT * FROM Bill_Generate; 

CREATE TABLE Payments (
    Payment_ID VARCHAR(50) PRIMARY KEY,
    Bill_ID VARCHAR(50),
    PhoneNumber VARCHAR(15), -- Có thể là user hoặc customer
    Payment_Method NVARCHAR(50) NOT NULL,  
    Transaction_Code VARCHAR(50) NULL,  -- NULL nếu là Tiền mặt
    Payment_Date DATE NULL,  -- NULL nếu chưa thanh toán
    Total_Cost INT NOT NULL CHECK (Total_Cost > 0)

	--Khóa ngoại
	CONSTRAINT FK_Payments_Bill FOREIGN KEY (Bill_ID) REFERENCES Bill_Generate(Bill_ID)
);
go

-- Tạo UNIQUE INDEX để tránh trùng Transaction_Code nhưng vẫn cho phép NULL
CREATE UNIQUE INDEX UQ_Transaction_Code_Not_Null
ON PAYMENTS(Transaction_Code)
WHERE Transaction_Code IS NOT NULL;
go

INSERT INTO Payments (Payment_ID, Bill_ID, PhoneNumber, Payment_Method, Transaction_Code, Payment_Date, Total_Cost)
VALUES
    ('PAY1', 'BILLORD1', '0987654321', N'Thẻ ghi nợ', 'TXN_001', '2025-03-24', 257550),
    ('PAY2', 'BILLORD2', '0987654322', N'Chuyển khoản ngân hàng', 'TXN_002', '2025-04-01', 486250),
    ('PAY3', 'BILLORD3', '0987654323', N'Tiền mặt', NULL, '2025-03-25', 258290), -- Tiền mặt => NULL Transaction_Code
    ('PAY4', 'BILLORD4', '0987654321', N'Tiền mặt', NULL, NULL, 71540), -- Chưa thanh toán => Payment_Date = NULL
	('PAY5', 'BILLORD5', '0987654323', N'Ví điện tử', 'TXN_005', '2025-04-01', 126750);
go

SELECT * FROM PAYMENTS;
go

--TRIGGER
CREATE TRIGGER trg_UpdateOrderStatus
ON Orders
FOR UPDATE
AS
BEGIN
	IF UPDATE(Status)
	BEGIN
		DECLARE @OldStatus NVARCHAR(20), @NewStatus NVARCHAR(20), @Order_ID VARCHAR(55);

		SELECT TOP 1 
			@OldStatus = d.Status,
			@NewStatus = i.Status,
			@Order_ID = i.Order_ID
		FROM inserted i
		JOIN deleted d ON i.Order_ID = d.Order_ID;

		IF @OldStatus = N'Chờ xác nhận' AND @NewStatus NOT IN (N'Đã giao', N'Đã hoàn thành', N'Đã hủy')
		BEGIN
			RAISERROR(N'Trạng thái không hợp lệ! Không thể chuyển từ "Chờ xác nhận" sang "%s".', 16, 1, @NewStatus)
			ROLLBACK TRANSACTION;
			RETURN;
		END

		IF @OldStatus = N'Đã giao' AND @NewStatus NOT IN (N'Đã hoàn thành', N'Đã hủy')
		BEGIN
			RAISERROR(N'Trạng thái không hợp lệ! Không thể chuyển từ "Đã giao" sang "%s".', 16, 1, @NewStatus)
			ROLLBACK TRANSACTION;
			RETURN;
		END

		IF @OldStatus IN (N'Đã hoàn thành', N'Đã hủy') AND @NewStatus <> @OldStatus
		BEGIN
			RAISERROR(N'Không thể thay đổi trạng thái đã hoàn thành hoặc đã hủy!', 16, 1)
			ROLLBACK TRANSACTION;
			RETURN;
		END
	END
END
GO

--STORED PROCEDURE
CREATE PROC GetStockQuantity
	@BookID VARCHAR(50)
AS
	SELECT Quantity
	FROM Stock
	WHERE BookID = @BookID
GO


