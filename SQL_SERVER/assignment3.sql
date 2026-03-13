/*====================================================
DAY 2 – HANDS ON SQL PRACTICE
Tables + Sample Data + Queries
====================================================*/


/*====================================================
CREATE TABLES
====================================================*/

CREATE TABLE customers(
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);

CREATE TABLE stores(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100)
);

CREATE TABLE brands(
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(100)
);

CREATE TABLE categories(
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100)
);

CREATE TABLE products(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),

    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

CREATE TABLE orders(
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_status INT,
    order_date DATE,
    store_id INT,

    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

CREATE TABLE order_items(
    order_item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2),

    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

CREATE TABLE stocks(
    store_id INT,
    product_id INT,
    quantity INT,

    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);


/*====================================================
INSERT SAMPLE DATA
====================================================*/

INSERT INTO customers VALUES
(1,'Aman','Sharma'),
(2,'Rohit','Verma'),
(3,'Priya','Singh');

INSERT INTO stores VALUES
(1,'Jamshedpur Store'),
(2,'Delhi Store');

INSERT INTO brands VALUES
(1,'Samsung'),
(2,'Apple'),
(3,'Sony');

INSERT INTO categories VALUES
(1,'Mobile'),
(2,'Laptop'),
(3,'Headphones');

INSERT INTO products VALUES
(1,'Galaxy S21',1,1,2023,700),
(2,'iPhone 14',2,1,2023,900),
(3,'Sony Headset',3,3,2022,300),
(4,'MacBook Air',2,2,2023,1200);

INSERT INTO orders VALUES
(1,1,1,'2025-01-10',1),
(2,2,4,'2025-01-15',1),
(3,3,4,'2025-02-01',2);

INSERT INTO order_items VALUES
(1,1,1,2,700,0.10),
(2,2,2,1,900,0.05),
(3,3,4,1,1200,0.15);

INSERT INTO stocks VALUES
(1,1,50),
(1,2,30),
(1,4,10),
(2,1,20),
(2,3,40);



/*====================================================
LEVEL 1 – PROBLEM 1
Basic Customer Order Report
====================================================*/

SELECT 
c.first_name,
c.last_name,
o.order_id,
o.order_date,
o.order_status
FROM customers c
INNER JOIN orders o
ON c.customer_id = o.customer_id
WHERE o.order_status = 1
OR o.order_status = 4
ORDER BY o.order_date DESC;



/*====================================================
LEVEL 1 – PROBLEM 2
Product Price Listing by Category
====================================================*/

SELECT
p.product_name,
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



/*====================================================
LEVEL 2 – PROBLEM 1
Store Wise Sales Summary
====================================================*/

SELECT
s.store_name,
SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS TotalSales
FROM stores s
INNER JOIN orders o
ON s.store_id = o.store_id
INNER JOIN order_items oi
ON o.order_id = oi.order_id
WHERE o.order_status = 4
GROUP BY s.store_name
ORDER BY TotalSales DESC;



/*====================================================
LEVEL 2 – PROBLEM 2
Product Stock and Sales Analysis
====================================================*/

SELECT
p.product_name,
st.store_name,
s.quantity AS AvailableStock,
SUM(oi.quantity) AS TotalSold
FROM stocks s
INNER JOIN products p
ON s.product_id = p.product_id
INNER JOIN stores st
ON s.store_id = st.store_id
LEFT JOIN order_items oi
ON s.product_id = oi.product_id
GROUP BY p.product_name, st.store_name, s.quantity
ORDER BY p.product_name;