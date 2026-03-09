CREATE DATABASE RevenueDB;
GO

USE RevenueDB;
GO

CREATE TABLE Stores (
    StoreID INT PRIMARY KEY,
    StoreName VARCHAR(100)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    StoreID INT,
    Order_Status INT,
    FOREIGN KEY (StoreID) REFERENCES Stores(StoreID)
);

CREATE TABLE Order_Items (
    ItemID INT PRIMARY KEY,
    OrderID INT,
    ProductName VARCHAR(100),
    Quantity INT,
    Price DECIMAL(10,2),
    Discount DECIMAL(10,2),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);

INSERT INTO Stores VALUES
(1,'Hyderabad Store'),
(2,'Chennai Store');

INSERT INTO Orders VALUES
(101,1,4),
(102,1,4),
(103,2,2),
(104,2,4);

INSERT INTO Order_Items VALUES
(1,101,'Car',1,20000,500),
(2,101,'Bike',2,8000,200),
(3,102,'Truck',1,30000,1000),
(4,104,'Car',1,20000,0);

CREATE TABLE #RevenueTemp (
    StoreID INT,
    OrderID INT,
    Revenue DECIMAL(18,2)
);

BEGIN TRY
BEGIN TRANSACTION

DECLARE @OrderID INT
DECLARE @StoreID INT
DECLARE @Revenue DECIMAL(18,2)

DECLARE order_cursor CURSOR FOR
SELECT OrderID, StoreID
FROM Orders
WHERE Order_Status = 4

OPEN order_cursor

FETCH NEXT FROM order_cursor INTO @OrderID, @StoreID

WHILE @@FETCH_STATUS = 0
BEGIN

SELECT @Revenue = SUM((Price * Quantity) - Discount)
FROM Order_Items
WHERE OrderID = @OrderID

INSERT INTO #RevenueTemp VALUES(@StoreID,@OrderID,@Revenue)

FETCH NEXT FROM order_cursor INTO @OrderID, @StoreID

END

CLOSE order_cursor
DEALLOCATE order_cursor

COMMIT TRANSACTION
END TRY

BEGIN CATCH
ROLLBACK TRANSACTION
PRINT 'Error occurred'
END CATCH

---Store Revenue Summary--
SELECT 
s.StoreName,
SUM(r.Revenue) AS TotalRevenue
FROM #RevenueTemp r
JOIN Stores s ON r.StoreID = s.StoreID
GROUP BY s.StoreName;