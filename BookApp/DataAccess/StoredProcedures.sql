USE [BookAppDb]
GO

/****** Object:  StoredProcedure [dbo].[AddBook]    Script Date: 26.02.2025 18:42:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddBook]
    @Title NVARCHAR(100),
    @Author NVARCHAR(100),
    @Price DECIMAL(18, 2),
    @Stock INT,
    @CategoryID INT
AS
BEGIN
    INSERT INTO Books (Title, Author, Price, Stock, CategoryID, IsDeleted)
    VALUES (@Title, @Author, @Price, @Stock, @CategoryID, 0)
END
GO


----------------------------------------------

USE [BookAppDb]
GO

/****** Object:  StoredProcedure [dbo].[DeleteBook]    Script Date: 26.02.2025 18:46:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteBook]
    @BookID INT
AS
BEGIN
    UPDATE Books
    SET IsDeleted = 1
    WHERE BookID = @BookID
END
GO


------------------------------------------------
USE [BookAppDb]
GO

/****** Object:  StoredProcedure [dbo].[GetAllBooks]    Script Date: 26.02.2025 18:47:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllBooks]
AS
BEGIN
    SELECT 
        b.BookID,
        b.Title,
        b.Author,
        b.Price,
        b.Stock,
        c.CategoryName
    FROM Books b
    INNER JOIN Categories c ON b.CategoryID = c.CategoryID
    WHERE b.IsDeleted = 0
END
GO


-------------------------------------------------

USE [BookAppDb]
GO

/****** Object:  StoredProcedure [dbo].[UpdateBook]    Script Date: 26.02.2025 18:47:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateBook]
    @BookID INT,
    @Title NVARCHAR(100),
    @Author NVARCHAR(100),
    @Price DECIMAL(18, 2),
    @Stock INT,
    @CategoryID INT
AS
BEGIN
    UPDATE Books
    SET Title = @Title,
        Author = @Author,
        Price = @Price,
        Stock = @Stock,
        CategoryID = @CategoryID
    WHERE BookID = @BookID
END
GO



