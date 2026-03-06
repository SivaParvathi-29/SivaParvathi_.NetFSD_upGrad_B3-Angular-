USE EcommDb;

CREATE VIEW vw_ProductDetails
AS
SELECT 
p.product_name,
b.brand_name,
c.category_name,
p.price
FROM products p
JOIN brands b 
ON p.brand_id = b.brand_id
JOIN categories c 
ON p.category_id = c.category_id;

SELECT * FROM vw_ProductDetails;

CREATE TABLE orders(
order_id INT PRIMARY KEY,
customer_id INT,
store_id INT,
staff_id INT,
order_date DATE
);
CREATE TABLE Staffs(
staff_id INT PRIMARY KEY,
first_name VARCHAR(50),
last_name VARCHAR(50),
store_id INT
);

INSERT INTO Staffs VALUES
(1,'Ravi','Kumar',1),
(2,'Anil','Sharma',2),
(3,'Priya','Reddy',3),
(4,'Kiran','Patel',4),
(5,'Meena','Singh',5);

INSERT INTO orders VALUES
(1,1,1,1,'2024-01-10'),
(2,2,2,2,'2024-02-12'),
(3,3,3,3,'2024-03-15'),
(4,4,4,4,'2024-04-18'),
(5,5,5,5,'2024-05-20');

CREATE VIEW vw_OrderSummary
AS
SELECT
o.order_id,
c.first_name + ' ' + c.last_name AS customer_name,
s.store_name,
st.first_name + ' ' + st.last_name AS staff_name,
o.order_date
FROM orders o
JOIN customers c
ON o.customer_id = c.customer_id
JOIN stores s
ON o.store_id = s.store_id
JOIN Staffs st
ON o.staff_id = st.staff_id;

SELECT * FROM vw_OrderSummary;

SELECT name 
FROM sys.views;