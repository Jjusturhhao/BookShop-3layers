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

INSERT INTO Book VALUES('BOOK1',N'Cây Cam Ngọt Của Tôi','CAT1',N'José Mauro de Vasconcelos', 80400, 'CCNCT.jpg');
INSERT INTO Book VALUES('BOOK2',N'25 Độ Âm','CAT1',N'Thảo Trang', 210000, '25DA.jpg');
INSERT INTO Book VALUES('BOOK3',N'Người Đua Diều','CAT1',N'Khaled Hosseini', 96750, 'NDD.jpg');
INSERT INTO Book VALUES('BOOK4',N'Sapiens : A Brief History of Humankind','CAT2',N'Yuval Noah Harari', 276250, 'Sapiens.jpg');
INSERT INTO Book VALUES('BOOK5',N'Flipped','CAT2',N'Van Draanen Wendelin', 210000, 'Flipped.jpg');
INSERT INTO Book VALUES('BOOK6',N'Think and Grow Rich','CAT2',N'Napoleon Hill', 230400, 'TAGR.jpg');
INSERT INTO Book VALUES('BOOK7',N'Bí Mật Tư Duy Triệu Phú (Tái Bản 2021)','CAT3',N'T Harv Eker', 78840, 'BMTDTP.jpg');
INSERT INTO Book VALUES('BOOK8',N'Người Giàu Có Nhất Thành Babylon','CAT3',N'Van Draanen Wendelin', 71540, 'NGCNTB.jpg');
INSERT INTO Book VALUES('BOOK9',N'Ai Toàn Năng: Chinh Phục Thời Đại Số','CAT3',N'Ajay Agrawal, Joshua Gans', 126750, 'AI.jpg');
INSERT INTO Book VALUES('BOOK10',N'Búp Sen Xanh (Tái Bản 2020)','CAT4',N'Sơn Tùng', 57600, 'BSX.jpg');
INSERT INTO Book VALUES('BOOK11',N'100 Kỹ Năng Sinh Tồn','CAT4',N'Clint Emerson', 70000, '100KNST.jpg');
INSERT INTO Book VALUES('BOOK12',N'Hoàng Tử Bé (Tái Bản 2022)','CAT4',N'Antoine De Saint-Exupéry', 22750, 'HTB.jpg');
INSERT INTO Book VALUES('BOOK13',N'Con Đường Chẳng Mấy Ai Đi','CAT5',N'M. Scott Peck', 99000, 'CDCMAD.jpg');
INSERT INTO Book VALUES('BOOK14',N'Tư Duy Ngược','CAT5',N'Nguyễn Anh Dũng', 65330, 'TDN.jpg');
INSERT INTO Book VALUES('BOOK15',N'Manifest - 7 Bước Để Thay Đổi Cuộc Đời Bạn Mãi Mãi','CAT5',N'Roxie Nafousi', 62300, 'MNF.jpg');

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
		BookID VARCHAR(50) PRIMARY KEY,
		SupplierID VARCHAR(55) FOREIGN KEY REFERENCES Suppliers(Supplier_ID),
		CategoryID VARCHAR(10) FOREIGN KEY REFERENCES BookCategory(CategoryID),
		BookName NVARCHAR(100) NOT NULL,
		ImportDate DATETIME DEFAULT GETDATE(),
	    Quantity INT NOT NULL CHECK (Quantity >= 0)
);
go

	INSERT INTO Stock VALUES('BOOK1','SUP1','CAT1',N'Cây Cam Ngọt Của Tôi','2025-03-12', 250);
	INSERT INTO Stock VALUES('BOOK2','SUP1','CAT1',N'25 Độ Âm','2025-03-12', 200);
	INSERT INTO Stock VALUES('BOOK3','SUP2','CAT1',N'Người Đua Diều','2025-03-10', 300);
	INSERT INTO Stock VALUES('BOOK4','SUP3','CAT2',N'Sapiens : A Brief History of Humankind','2025-03-20', 400);
	INSERT INTO Stock VALUES('BOOK5','SUP3', 'CAT2',N'Flipped','2025-03-20', 350);
	INSERT INTO Stock VALUES('BOOK6','SUP4', 'CAT2',N'Think and Grow Rich','2025-03-20', 200);
	INSERT INTO Stock VALUES('BOOK7','SUP5', 'CAT3',N'Bí Mật Tư Duy Triệu Phú (Tái Bản 2021)','2025-03-15', 400);
	INSERT INTO Stock VALUES('BOOK8','SUP5','CAT3',N'Người Giàu Có Nhất Thành Babylon','2025-03-10', 500);
	INSERT INTO Stock VALUES('BOOK9','SUP6','CAT3',N'Ai Toàn Năng: Chinh Phục Thời Đại Số','2025-03-15', 500);
	INSERT INTO Stock VALUES('BOOK10','SUP6','CAT4',N'Búp Sen Xanh (Tái Bản 2020)','2025-03-15', 600);
	INSERT INTO Stock VALUES('BOOK11','SUP2','CAT4',N'100 Kỹ Năng Sinh Tồn','2025-03-05', 500);
	INSERT INTO Stock VALUES('BOOK12','SUP2','CAT4',N'Hoàng Tử Bé (Tái Bản 2022)','2025-03-05', 550);
	INSERT INTO Stock VALUES('BOOK13','SUP5','CAT5',N'Con Đường Chẳng Mấy Ai Đi','2025-03-05', 1000);
	INSERT INTO Stock VALUES('BOOK14','SUP1','CAT5',N'Tư Duy Ngược','2025-03-01', 800);
	INSERT INTO Stock VALUES('BOOK15','SUP6','CAT5',N'Manifest - 7 Bước Để Thay Đổi Cuộc Đời Bạn Mãi Mãi','2025-03-01', 1000);
go
	SELECT * FROM Stock
	ORDER BY CAST(SUBSTRING(BookID, 5, LEN(BookID)) AS INT);


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
INSERT INTO Customers (PhoneNumber, FullName) 
VALUES 
    ('0987654321', N'Tin'),
	('0987654322', N'Hân Hân'),
    ('0987654323', N'Mỹ Diên');
go

CREATE TABLE Orders (
    Order_ID VARCHAR(55) NOT NULL PRIMARY KEY, 
	PhoneNumber NVARCHAR(15) NOT NULL,
    Employee_ID VARCHAR(30), 
    Order_Date DATETIME NOT NULL DEFAULT GETDATE(), 
	Status NVARCHAR(20) DEFAULT N'Chờ xác nhận' CHECK (Status IN (N'Chờ xác nhận', N'Đang vận chuyển', N'Đã hoàn thành', N'Đã hủy')),

    -- Thiết lập khóa ngoại
    CONSTRAINT FK_Orders_Employee FOREIGN KEY (Employee_ID) REFERENCES Users(User_ID)
);
go

INSERT INTO Orders (Order_ID, PhoneNumber, Employee_ID, Order_Date, Status) 
VALUES 
    ('ORD1', '0987654321', NULL , '2025-03-24', N'Đang vận chuyển'),
    ('ORD2', '0987654322', NULL, '2025-03-25', N'Chờ xác nhận'),
    ('ORD3', '0987654323', 'S3', '2025-03-26', N'Đã hoàn thành'),
    ('ORD4', '0987654321', NULL, '2025-04-01', N'Đã hủy'),
    ('ORD5', '0987654323', NULL, '2025-04-02', N'Chờ xác nhận'),
	('ORD6', '0987654323', 'S2', '2025-04-25', N'Đã hoàn thành'),
    ('ORD7', '0987654321', 'S1', '2025-04-26', N'Đã hoàn thành'),
	('ORD8', '0987654322', 'S3', '2025-04-27', N'Đã hoàn thành');
go

CREATE TABLE OrderDetails (
    OrderDetail_ID INT IDENTITY(1,1) PRIMARY KEY, 
    Order_ID VARCHAR(55) NOT NULL,
    BookID VARCHAR(50) NOT NULL, 
    Qty_sold INT CHECK (Qty_sold > 0),
	PriceAtOrderTime INT NOT NULL -- Cập nhật OrderDetails để lưu giá tại thời điểm đặt hàng

    -- Thiết lập khóa ngoại
    CONSTRAINT FK_OrderDetails_Order FOREIGN KEY (Order_ID) REFERENCES Orders(Order_ID),
    CONSTRAINT FK_OrderDetails_Stock FOREIGN KEY (BookID) REFERENCES Stock(BookID)
);
go

INSERT INTO OrderDetails (Order_ID, BookID, Qty_sold, PriceAtOrderTime)
VALUES ('ORD1', 'BOOK1', 2, 80400),  -- 2 cuốn "Cây Cam Ngọt Của Tôi"
       ('ORD1', 'BOOK3', 1, 96750),  -- 1 cuốn "Người Đua Diều"
       ('ORD2', 'BOOK4', 1, 276250),  
       ('ORD2', 'BOOK5', 1, 210000),
	   ('ORD3', 'BOOK15', 1, 62300),  
	   ('ORD3', 'BOOK14', 3, 65330),
	   ('ORD4', 'BOOK8', 1, 71540),  
	   ('ORD5', 'BOOK9', 1, 126750),
	   ('ORD6', 'BOOK7', 1, 78840),
	   ('ORD6', 'BOOK8', 1, 71540),
	   ('ORD7', 'BOOK2', 1, 210000),
	   ('ORD7', 'BOOK5', 1, 210000),
	   ('ORD8', 'BOOK6', 2, 230400),
	   ('ORD8', 'BOOK10', 1, 57600);
go
SELECT * FROM OrderDetails
 
SELECT O.Order_ID, O.Order_Date, OD.BookID, S.BookName, OD.Qty_sold
FROM Orders O
JOIN OrderDetails OD ON O.Order_ID = OD.Order_ID
JOIN Stock S ON OD.BookID = S.BookID
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
	JOIN Stock S ON OD.BookID = S.BookID
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
	('PAY5', 'BILLORD5', '0987654323', N'Ví điện tử', 'TXN_005', '2025-04-01', 126750),
	('PAY6', 'BILLORD6', '0987654323', N'Ví điện tử', 'TXN_006', '2025-04-25', 150380),
	('PAY7', 'BILLORD7', '0987654321', N'Tiền mặt', NULL, '2025-04-26', 420000),
	('PAY8', 'BILLORD8', '0987654322', N'Chuyển khoản ngân hàng', 'TXN_008','2025-04-27', 518400); 

go

SELECT * FROM PAYMENTS;
go


CREATE TABLE Rules (
    RuleKey NVARCHAR(150) PRIMARY KEY,
    RuleValue INT
);

INSERT INTO Rules (RuleKey, RuleValue)
VALUES (N'Nhập tối thiểu', 150),
       (N'Chỉ nhập khi số lượng sách trong kho dưới', 300);
GO


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

		IF @OldStatus = N'Chờ xác nhận' AND @NewStatus NOT IN (N'Đang vận chuyển', N'Đã hoàn thành', N'Đã hủy')
		BEGIN
			RAISERROR(N'Trạng thái không hợp lệ! Không thể chuyển từ "Chờ xác nhận" sang "%s".', 16, 1, @NewStatus)
			ROLLBACK TRANSACTION;
			RETURN;
		END

		IF @OldStatus = N'Đang vận chuyển' AND @NewStatus NOT IN (N'Đã hoàn thành', N'Đã hủy')
		BEGIN
			RAISERROR(N'Trạng thái không hợp lệ! Không thể chuyển từ "Đang vận chuyển" sang "%s".', 16, 1, @NewStatus)
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

--Update 25/04
CREATE OR ALTER TRIGGER trg_Update_PaymentDate_When_OrderCompleted
ON Orders
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE P
    SET Payment_Date = GETDATE()
    FROM Payments P
    INNER JOIN Bill_Generate B ON P.Bill_ID = B.Bill_ID
    INNER JOIN inserted i ON B.Order_ID = i.Order_ID
    WHERE i.Status = N'Đã hoàn thành' AND P.Payment_Date IS NULL;
END


SELECT 
    MONTH(b.Bill_Date) AS Month,
    YEAR(b.Bill_Date) AS Year,
    SUM(b.Total_Cost) AS TotalRevenue,
    COUNT(DISTINCT b.Order_ID) AS OrderCount
FROM 
    Bill_Generate b
JOIN Payments p ON p.Bill_ID = b.Bill_ID
JOIN Orders o ON o.Order_ID = b.Order_ID
WHERE 
    YEAR(b.Bill_Date) = 2025
    AND o.Status = N'Đã hoàn thành'
    AND p.Payment_Date IS NOT NULL
GROUP BY 
    MONTH(b.Bill_Date), YEAR(b.Bill_Date)
ORDER BY 
    Month;

UPDATE b
SET b.Bill_Date = o.Order_Date
FROM Bill_Generate b
JOIN Orders o ON b.Order_ID = o.Order_ID
go