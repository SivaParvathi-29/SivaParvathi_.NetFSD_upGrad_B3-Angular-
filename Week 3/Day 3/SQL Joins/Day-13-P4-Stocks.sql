CREATE DATABASE StockDB;
GO
USE StockDB;
GO
CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50)
);
CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(50)
);
CREATE TABLE stocks (
    store_id INT,
    product_id INT,
    quantity INT,
    PRIMARY KEY (store_id, product_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);
CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    store_id INT,
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);
CREATE TABLE order_items (
    item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);
INSERT INTO products VALUES
(1, 'TV'),
(2, 'Mobile'),
(3, 'Laptop');

INSERT INTO stores VALUES
(1, 'Store A'),
(2, 'Store B');

INSERT INTO stocks VALUES
(1, 1, 10),   -- Store A TV stock
(1, 2, 20),
(2, 1, 15),
(2, 3, 5);    -- Laptop exists but not sold

INSERT INTO orders VALUES
(101, 1),
(102, 2);

INSERT INTO order_items VALUES
(1, 101, 1, 2),  
(2, 101, 2, 5),  
(3, 102, 1, 3); 

SELECT 
    p.product_name,
    s.store_name,
    st.quantity AS stock_quantity,
    ISNULL(SUM(oi.quantity), 0) AS total_sold
FROM stocks st
INNER JOIN products p
    ON st.product_id = p.product_id
INNER JOIN stores s
    ON st.store_id = s.store_id
LEFT JOIN orders o
    ON s.store_id = o.store_id
LEFT JOIN order_items oi
    ON o.order_id = oi.order_id
    AND st.product_id = oi.product_id
GROUP BY 
    p.product_name,
    s.store_name,
    st.quantity
ORDER BY 
    p.product_name;
