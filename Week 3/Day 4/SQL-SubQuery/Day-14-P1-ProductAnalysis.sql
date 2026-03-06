CREATE DATABASE AutomobileDB;
GO

USE AutomobileDB;
GO

CREATE TABLE Categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(50)
);

CREATE TABLE Products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    model_year INT,
    list_price DECIMAL(10,2),
    category_id INT,
    FOREIGN KEY (category_id) REFERENCES Categories(category_id)
);
INSERT INTO Categories VALUES
(1, 'Sedan'),
(2, 'SUV'),
(3, 'Sports');

INSERT INTO Products VALUES
(1, 'Honda City', 2017, 800000, 1),
(2, 'Hyundai Verna', 2018, 900000, 1),
(3, 'Toyota Fortuner', 2019, 3200000, 2),
(4, 'Mahindra XUV500', 2018, 1500000, 2),
(5, 'BMW Z4', 2020, 8500000, 3),
(6, 'Audi R8', 2021, 25000000, 3);

SELECT 
    p.product_name + ' (' + CAST(p.model_year AS VARCHAR) + ')' 
        AS product_details,
    p.list_price,
   
    (SELECT AVG(p2.list_price)
     FROM Products p2
     WHERE p2.category_id = p.category_id) 
        AS category_avg_price,
    
    p.list_price - 
    (SELECT AVG(p3.list_price)
     FROM Products p3
     WHERE p3.category_id = p.category_id) 
        AS price_difference

FROM Products p

WHERE p.list_price >
    (SELECT AVG(p4.list_price)
     FROM Products p4
     WHERE p4.category_id = p.category_id);