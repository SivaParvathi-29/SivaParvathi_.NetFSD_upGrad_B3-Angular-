CREATE DATABASE ProductDB;
GO

USE ProductDB;
GO

CREATE TABLE brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(100)
);

CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100)
);

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),
    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);
INSERT INTO brands VALUES
(1, 'Nike'),
(2, 'Adidas');

INSERT INTO categories VALUES
(1, 'Shoes'),
(2, 'Clothing');

INSERT INTO products VALUES
(101, 'Air Zoom', 1, 1, 2024, 800),
(102, 'Ultra Boost', 2, 1, 2023, 950),
(103, 'Sports T-Shirt', 1, 2, 2024, 400),
(104, 'Track Jacket', 2, 2, 2023, 600);

SELECT p.product_name,
       b.brand_name,
       c.category_name,
       p.model_year,
       p.list_price
FROM products p
INNER JOIN brands b
ON p.brand_id = b.brand_id
INNER JOIN categories c
ON p.category_id = c.category_id
WHERE p.list_price > 500
ORDER BY p.list_price ASC;

