CREATE DATABASE RetailStoreDB;
GO

USE RetailStoreDB;
GO

CREATE TABLE Stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(50)
);
CREATE TABLE Products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    list_price DECIMAL(10,2)
);
CREATE TABLE Stocks (
    store_id INT,
    product_id INT,
    quantity INT,
    PRIMARY KEY (store_id, product_id),
    FOREIGN KEY (store_id) REFERENCES Stores(store_id),
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
);
CREATE TABLE Orders (
    order_id INT PRIMARY KEY,
    store_id INT,
    order_date DATE,
    FOREIGN KEY (store_id) REFERENCES Stores(store_id)
);
CREATE TABLE Order_Items (
    order_id INT,
    product_id INT,
    quantity INT,
    discount DECIMAL(10,2),
    FOREIGN KEY (order_id) REFERENCES Orders(order_id),
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

INSERT INTO Stores VALUES
(1, 'Hyderabad Store'),
(2, 'Vijayawada Store');

INSERT INTO Products VALUES
(1, 'Laptop', 50000),
(2, 'Mobile', 20000),
(3, 'Tablet', 30000);
INSERT INTO Stocks VALUES
(1, 1, 5),
(1, 2, 0),   
(2, 3, 10);

INSERT INTO Orders VALUES
(101, 1, GETDATE()),
(102, 1, GETDATE()),
(103, 2, GETDATE());

INSERT INTO Order_Items VALUES
(101, 1, 2, 2000),
(102, 2, 3, 1500),
(103, 3, 1, 1000);

SELECT *
FROM (
    SELECT o.store_id, oi.product_id
    FROM Orders o
    JOIN Order_Items oi ON o.order_id = oi.order_id
) AS SoldProducts;

SELECT o.store_id, oi.product_id
FROM Orders o
JOIN Order_Items oi ON o.order_id = oi.order_id

EXCEPT

SELECT store_id, product_id
FROM Stocks
WHERE quantity > 0;

SELECT 
    s.store_name,
    p.product_name,
    SUM(oi.quantity) AS total_quantity_sold,

----- Revenue Calculation
SUM((oi.quantity * p.list_price) - oi.discount) AS total_revenue

FROM Orders o
JOIN Order_Items oi ON o.order_id = oi.order_id
JOIN Stores s ON o.store_id = s.store_id
JOIN Products p ON oi.product_id = p.product_id
JOIN Stocks st ON st.store_id = s.store_id 
               AND st.product_id = p.product_id

WHERE st.quantity = 0
GROUP BY s.store_name, p.product_name;

UPDATE Stocks
SET quantity = 0
WHERE store_id = 2
AND product_id = 3;



