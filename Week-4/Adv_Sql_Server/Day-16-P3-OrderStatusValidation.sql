CREATE DATABASE OrderSystemDB;
GO

USE OrderSystemDB;
GO

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    OrderDate DATE,
    Shipped_Date DATE,
    Order_Status INT
);
GO

INSERT INTO Orders VALUES
(101,'Ravi','2026-03-01',NULL,1),
(102,'Anita','2026-03-02','2026-03-03',3),
(103,'Raj','2026-03-03',NULL,2);

SELECT * FROM Orders;

GO
CREATE TRIGGER trg_OrderStatusValidation
ON Orders
AFTER UPDATE
AS
BEGIN

BEGIN TRY

    -- Validate condition
    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE Order_Status = 4
        AND Shipped_Date IS NULL
    )
    BEGIN
        RAISERROR('Cannot set order status to Completed because Shipped_Date is NULL.',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

END TRY

BEGIN CATCH

    ROLLBACK TRANSACTION;

    DECLARE @ErrorMsg NVARCHAR(4000);
    SET @ErrorMsg = ERROR_MESSAGE();

    RAISERROR(@ErrorMsg,16,1);

END CATCH

END;
GO

UPDATE Orders
SET Order_Status = 4
WHERE OrderID = 101;

UPDATE Orders
SET Shipped_Date = '2026-03-05',
    Order_Status = 4
WHERE OrderID = 101;

SELECT * FROM Orders;
