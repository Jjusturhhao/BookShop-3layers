CREATE PROC uspAddBook
	@BookID VARCHAR(50),
	@BookName NVARCHAR(100),
	@CategoryID VARCHAR(10),
	@Author NVARCHAR(100),
	@Price INT,
	@BookImage NVARCHAR(255)
AS
BEGIN
	INSERT INTO Stock (BookID,BookName,CategoryID,Author,Price,BookImage )
	VALUES (@BookID,@BookName,@CategoryID,@Author,@Price,@BookImage)
END

