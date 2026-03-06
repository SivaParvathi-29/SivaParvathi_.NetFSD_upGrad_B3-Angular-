CREATE DATABASE OrderMaintenanceDB;
GO

USE OrderMaintenanceDB;
GO

CREATE TABLE Customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);
CREATE TABLE Orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    order_status INT,  -- 1 = Pending, 2 = Completed, 3 = Rejected
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id)
);
INSERT INTO Customers VALUES
(1, 'Ravi', 'Kumar'),
(2, 'Sneha', 'Reddy'),
(3, 'Arjun', 'Varma');

INSERT INTO Orders VALUES
(101, 1, '2023-01-10', '2023-01-20', '2023-01-18', 2), -- Completed
(102, 1, '2022-01-05', '2022-01-15', '2022-01-14', 3), -- Rejected (old)
(103, 2, '2024-02-01', '2024-02-10', '2024-02-15', 2), -- Delayed
(104, 3, '2024-03-01', '2024-03-10', '2024-03-08', 2); -- On time


----Create archive table--
CREATE TABLE Archived_Orders (
    order_id INT,
    customer_id INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    order_status INT
);

---Insert Rejected & Older than 1 Year Orders into Archive--
INSERT INTO Archived_Orders
SELECT *
FROM Orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR, -1, GETDATE());


---Delete Rejected & Older Than 1 Year Orders---
DELETE FROM Orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR, -1, GETDATE());

-----Customers Whose ALL Orders Are Completed--
SELECT c.customer_id,
       c.first_name + ' ' + c.last_name AS full_name
FROM Customers c
WHERE NOT EXISTS (
    SELECT 1
    FROM Orders o
    WHERE o.customer_id = c.customer_id
    AND o.order_status <> 2
);

-----Display order Prosessing Delay---
SELECT 
    order_id,
    DATEDIFF(DAY, order_date, shipped_date) AS processing_delay_days
FROM Orders;


-----Mark orders as delayed or on Time--
SELECT 
    order_id,
    order_date,
    required_date,
    shipped_date,

    CASE 
        WHEN shipped_date > required_date THEN 'Delayed'
        ELSE 'On Time'
    END AS delivery_status
FROM Orders;



