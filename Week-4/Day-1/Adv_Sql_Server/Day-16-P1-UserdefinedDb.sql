CREATE DATABASE UserdefinedDb;
GO

USE UserdefinedDb;
GO

CREATE TABLE Categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100)
);

CREATE TABLE Brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(100)
);
CREATE TABLE Products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    brand_id INT,
    category_id INT,
    price DECIMAL(10,2),

    FOREIGN KEY (brand_id) REFERENCES Brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES Categories(category_id)
);

CREATE TABLE Customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    city VARCHAR(50)
);

CREATE TABLE Stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100),
    city VARCHAR(50)
);
INSERT INTO Categories VALUES
(1,'Cars'),
(2,'Bikes'),
(3,'Trucks'),
(4,'Electric Vehicles'),
(5,'SUV');

INSERT INTO Brands VALUES
(1,'Toyota'),
(2,'Honda'),
(3,'Ford'),
(4,'Tesla'),
(5,'Hyundai');

INSERT INTO Products VALUES
(1,'Toyota Corolla',1,1,20000),
(2,'Honda Civic',2,1,22000),
(3,'Ford F150',3,3,30000),
(4,'Tesla Model 3',4,4,40000),
(5,'Hyundai Creta',5,5,25000);

INSERT INTO Customers VALUES
(1,'Ravi','Teja','Hyderabad'),
(2,'Siva','Shankar','Delhi'),
(3,'Raj','Kumar','Hyderabad'),
(4,'Priya','Reddy','Chennai'),
(5,'Sree','Lakshmi','Mumbai');

INSERT INTO Stores VALUES
(1,'AutoHub Hyderabad','Hyderabad'),
(2,'AutoHub Delhi','Delhi'),
(3,'AutoHub Chennai','Chennai'),
(4,'AutoHub Mumbai','Mumbai'),
(5,'AutoHub Bangalore','Bangalore');

SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.price
FROM Products p
JOIN Brands b ON p.brand_id = b.brand_id
JOIN Categories c ON p.category_id = c.category_id;

SELECT *
FROM Customers
WHERE city = 'Hyderabad';

SELECT 
    c.category_name,
    COUNT(p.product_id) AS total_products
FROM Categories c
LEFT JOIN Products p 
ON c.category_id = p.category_id
GROUP BY c.category_name;


