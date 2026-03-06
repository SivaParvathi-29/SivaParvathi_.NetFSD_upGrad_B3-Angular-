CREATE DATABASE EcommDb;
GO

USE EcommDb;
GO

CREATE TABLE Categories(
category_id INT PRIMARY KEY,
category_name VARCHAR(50)
);

CREATE TABLE Brands(
brand_id INT PRIMARY KEY,
brand_name VARCHAR(50)
);

CREATE TABLE Products(
product_id INT PRIMARY KEY,
product_name VARCHAR(50),
brand_id INT,
category_id INT,
price DECIMAL(10,2),
FOREIGN KEY (brand_id) REFERENCES Brands(brand_id),
FOREIGN KEY (category_id) REFERENCES Categories(category_id)
);

CREATE TABLE Customers(
customer_id INT PRIMARY KEY,
first_name VARCHAR(50),
last_name VARCHAR(50),
city VARCHAR(50)
);

CREATE TABLE Stores(
store_id INT PRIMARY KEY,
store_name VARCHAR(50),
city VARCHAR(50)
);

INSERT INTO Categories VALUES
(1,'Cars'),
(2,'Bikes'),
(3,'Trucks'),
(4,'Electric Vehicles'),
(5,'Accessories');

INSERT INTO Brands VALUES
(1,'Toyota'),
(2,'Honda'),
(3,'Tesla'),
(4,'Ford'),
(5,'BMW');

INSERT INTO Products VALUES
(1,'Toyota Corolla',1,1,20000),
(2,'Honda Civic',2,1,22000),
(3,'Tesla Model 3',3,4,35000),
(4,'Ford F150',4,3,30000),
(5,'BMW Bike',5,2,15000);

INSERT INTO Customers VALUES
(1,'Jai','Krishna','Nellore'),
(2,'Siva','Reddy','Hyderabad'),
(3,'Padma','Sree','Vizag'),
(4,'Sree','Keerthi','Nellore'),
(5,'Kiran','Kumar','Hyderabad');

INSERT INTO Stores VALUES
(1,'AutoHub Zone','Nellore'),
(2,'Speed Motors','Hyderabad'),
(3,'Car World','Vizag'),
(4,'Ride Center','Chennai'),
(5,'Vehicle Zone','Bangalore');

SELECT 
p.product_name,
b.brand_name,
c.category_name
FROM Products p
JOIN Brands b ON p.brand_id = b.brand_id
JOIN Categories c ON p.category_id = c.category_id;

----Retrieve Customers From a Specific City---
SELECT *
FROM Customers
WHERE city = 'Hyderabad';

---Count Total Products in Each Category--
SELECT 
c.category_name,
COUNT(p.product_id) AS total_products
FROM Categories c
LEFT JOIN Products p
ON c.category_id = p.category_id
GROUP BY c.category_name;

