CREATE DATABASE AutoStoreDB;
GO

USE AutoStoreDB;
GO

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100)
);

CREATE TABLE Stocks (
    ProductID INT,
    StockQuantity INT,
    PRIMARY KEY(ProductID),
    FOREIGN KEY(ProductID) REFERENCES Products(ProductID)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    OrderDate DATE
);

CREATE TABLE Order_Items (
    OrderItemID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    
    FOREIGN KEY(OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY(ProductID) REFERENCES Products(ProductID)
);
GO

INSERT INTO Products VALUES
(1,'Car'),
(2,'Bike'),
(3,'Truck');

INSERT INTO Stocks VALUES
(1,10),
(2,5),
(3,8);

INSERT INTO Orders VALUES
(101,'2026-03-09');

GO
CREATE TRIGGER trg_UpdateStock
ON Order_Items
AFTER INSERT
AS
BEGIN

BEGIN TRY

    -- Check if stock is sufficient
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Stocks s
        ON i.ProductID = s.ProductID
        WHERE s.StockQuantity < i.Quantity
    )
    BEGIN
        RAISERROR('Stock is insufficient. Order cannot be placed.',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Update stock
    UPDATE s
    SET s.StockQuantity = s.StockQuantity - i.Quantity
    FROM Stocks s
    JOIN inserted i
    ON s.ProductID = i.ProductID;

END TRY

BEGIN CATCH
    ROLLBACK TRANSACTION;
    DECLARE @ErrorMsg NVARCHAR(4000);
    SET @ErrorMsg = ERROR_MESSAGE();
    RAISERROR(@ErrorMsg,16,1);
END CATCH

END;
GO

INSERT INTO Order_Items VALUES
(1,101,1,2);

INSERT INTO Order_Items VALUES
(2,101,2,10);

SELECT * FROM Stocks;