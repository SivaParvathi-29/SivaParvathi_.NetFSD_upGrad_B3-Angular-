CREATE DATABASE CustomerDB;
GO
 
USE CustomerDB;
GO


CREATE TABLE Customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);

CREATE TABLE Orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_amount DECIMAL(10,2),
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id)
);

INSERT INTO Customers VALUES
(1, 'sree', 'chandana'),
(2, 'Sri', 'Ram'),
(3, 'Arjun', 'Kumar'),
(4, 'Padma', 'Sri'),
(5, 'Jai', 'Sree');

INSERT INTO Orders VALUES
(101, 1, 6000),
(102, 1, 7000),
(103, 2, 3000),
(104, 3, 12000),
(105, 3, 5000);


SELECT 
    c.first_name + ' ' + c.last_name AS full_name,

    (SELECT SUM(o2.order_amount) 
     FROM Orders o2 
     WHERE o2.customer_id = c.customer_id) 
        AS total_order_value,

    CASE 
        WHEN (SELECT SUM(o3.order_amount) 
              FROM Orders o3 
              WHERE o3.customer_id = c.customer_id) > 10000 
            THEN 'Premium'

        WHEN (SELECT SUM(o3.order_amount) 
              FROM Orders o3 
              WHERE o3.customer_id = c.customer_id) BETWEEN 5000 AND 10000 
            THEN 'Regular'

        ELSE 'Basic'
    END AS customer_type

FROM Customers c
JOIN Orders o 
    ON c.customer_id = o.customer_id
GROUP BY c.customer_id, c.first_name, c.last_name

UNION

SELECT 
    c.first_name + ' ' + c.last_name AS full_name,
    0 AS total_order_value,
    'No Orders' AS customer_type

FROM Customers c
WHERE c.customer_id NOT IN 
    (SELECT customer_id FROM Orders);

 