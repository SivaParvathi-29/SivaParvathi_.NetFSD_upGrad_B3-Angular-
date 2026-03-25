CREATE DATABASE InventoryDB;
GO

USE InventoryDB;
GO


CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);

---INSERT-----
CREATE PROCEDURE sp_InsertProduct
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Products(ProductName, Category, Price)
    VALUES (@ProductName, @Category, @Price)
END


----VIEW---
CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT * FROM Products
END



------UPDATE---
CREATE PROCEDURE sp_UpdateProduct
    @ProductId INT,
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    UPDATE Products
    SET ProductName=@ProductName,
        Category=@Category,
        Price=@Price
    WHERE ProductId=@ProductId
END

----DELETE--
CREATE PROCEDURE sp_DeleteProduct
    @ProductId INT
AS
BEGIN
    DELETE FROM Products WHERE ProductId=@ProductId
END

----Get ProductBy Id---
CREATE PROCEDURE GetProductById
    @ProductId INT
AS
BEGIN
    SELECT *FROM Products WHERE ProductId=@ProductId
END
