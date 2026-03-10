CREATE DATABASE AutoRetailDB;
GO

USE AutoRetailDB;
GO
 
CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    phone VARCHAR(20)
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
    PRIMARY KEY (store_id, product_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_status INT,
    order_date DATE,
    store_id INT,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

CREATE TABLE order_items (
    order_id INT,
    item_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2),
    PRIMARY KEY (order_id, item_id),
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO customers VALUES (1,'Ravi','Kumar','9876543210');

INSERT INTO stores VALUES (1,'Main Store');

INSERT INTO products VALUES
(1,'Car Battery',5000),
(2,'Car Tyre',3000);

INSERT INTO stocks VALUES
(1,1,10),
(1,2,5);

CREATE TRIGGER trg_UpdateStock
ON order_items
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM stocks s
        JOIN inserted i
        ON s.product_id = i.product_id AND s.store_id = 1
        WHERE s.quantity < i.quantity
    )
    BEGIN
        RAISERROR ('Insufficient Stock',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    UPDATE s
    SET s.quantity = s.quantity - i.quantity
    FROM stocks s
    JOIN inserted i
    ON s.product_id = i.product_id AND s.store_id = 1;
END;

BEGIN TRANSACTION;

BEGIN TRY

INSERT INTO orders
VALUES (101,1,1,GETDATE(),1);

INSERT INTO order_items
VALUES
(101,1,1,2,5000,0),
(101,2,2,1,3000,0);

COMMIT TRANSACTION;

END TRY

BEGIN CATCH
ROLLBACK TRANSACTION;
PRINT 'Order Failed due to insufficient stock';
END CATCH;

SELECT * FROM order_items;

---Stock insufficient--
INSERT INTO order_items
VALUES (101,3,2,10,3000,0);


SELECT * FROM stocks;