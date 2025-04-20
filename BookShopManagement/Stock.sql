USE BookStoreManagement
GO

CREATE PROC uspAddStock 
@StockID VARCHAR(50),
		@SupplierID VARCHAR(55),
		@BookID VARCHAR(50),
		@CategoryID VARCHAR(10),
		@BookName NVARCHAR(100),
		@ImportDate DATETIME ,
	    @Quantity INT 
AS
BEGIN
	INSERT INTO Stock (SupplierID,BookID,CategoryID, BookName,ImportDate,Quantity )
	VALUES (@SupplierID,@BookID,@CategoryID,@BookName,@ImportDate,@Quantity)
END


GO

CREATE PROC uspDeleteStock
    @StockID VARCHAR(50)
AS
BEGIN
    DELETE FROM Stock WHERE StockID = @StockID
END