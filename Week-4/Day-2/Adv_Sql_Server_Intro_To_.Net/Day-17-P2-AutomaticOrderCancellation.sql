CREATE DATABASE AutoRetailCancelDB;
GO

USE AutoRetailCancelDB;
GO

CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);

CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100)
);

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    list_price DECIMAL(10,2)
);

CREATE TABLE stocks (
    store_id INT,
    product_id INT,
    quantity INT,
    PRIMARY KEY(store_id, product_id),
    FOREIGN KEY(store_id) REFERENCES stores(store_id),
    FOREIGN KEY(product_id) REFERENCES products(product_id)
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_status INT,
    order_date DATE,
    store_id INT,
    FOREIGN KEY(customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY(store_id) REFERENCES stores(store_id)
);

CREATE TABLE order_items (
    order_id INT,
    item_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2),
    PRIMARY KEY(order_id,item_id),
    FOREIGN KEY(order_id) REFERENCES orders(order_id),
    FOREIGN KEY(product_id) REFERENCES products(product_id)
);

INSERT INTO customers VALUES (1,'Ravi','Kumar');

INSERT INTO stores VALUES (1,'Main Store');

INSERT INTO products VALUES
(1,'Car Battery',5000),
(2,'Car Tyre',3000);

INSERT INTO stocks VALUES
(1,1,8),
(1,2,4);

INSERT INTO orders VALUES
(101,1,1,GETDATE(),1);

INSERT INTO order_items VALUES
(101,1,1,2,5000,0),
(101,2,2,1,3000,0);

SELECT * FROM stocks;

BEGIN TRANSACTION;

BEGIN TRY

-- Savepoint before restoring stock
SAVE TRANSACTION RestoreStockPoint;

-- Restore stock quantities
UPDATE s
SET s.quantity = s.quantity + oi.quantity
FROM stocks s
JOIN order_items oi 
     ON s.product_id = oi.product_id
JOIN orders o 
     ON o.order_id = oi.order_id
WHERE oi.order_id = 101
AND s.store_id = o.store_id;

-- Update order status to Rejected (3)
UPDATE orders
SET order_status = 3
WHERE order_id = 101;

COMMIT TRANSACTION;

PRINT 'Order Cancelled Successfully';

END TRY

BEGIN CATCH

PRINT 'Error occurred while cancelling order';

ROLLBACK TRANSACTION RestoreStockPoint;

ROLLBACK TRANSACTION;

END CATCH;

----Check Stock After Cancellation--
SELECT * FROM stocks;


----Check Order Status--
SELECT * FROM orders;

