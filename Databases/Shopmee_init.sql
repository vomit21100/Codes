-- create database
DROP DATABASE IF EXISTS shopmee;
CREATE DATABASE shopmee;
USE shopmee;

-- create tables
CREATE TABLE member(
    ID INTEGER PRIMARY KEY AUTO_INCREMENT,
    Email varchar(50) NOT NULL UNIQUE,
    Password varchar(30) NOT NULL,
    Name varchar(10) NOT NULL,
    Phone_No varchar(10) NOT NULL UNIQUE,
    Sex varchar(1) NULL,
    RigisterDate timestamp DEFAULT current_timestamp,
    Token INTEGER DEFAULT 1
);

/* 
Token 代號
1   僅有買家功能
2   有賣家功能
3   停用功能
預設開啟賣家功能
*/

CREATE TABLE customer(
    ID INTEGER,
    Address varchar(50) NOT NULL,
    CreditCard varchar(20) NOT NULL,
    FOREIGN KEY (ID) REFERENCES member(ID) ON UPDATE CASCADE ON DELETE CASCADE,
    PRIMARY KEY (ID)
);

CREATE TABLE seller(
    ID INTEGER,
    BankAccount varchar(20) NOT NULL,
    FOREIGN KEY (ID) REFERENCES member(ID) ON UPDATE CASCADE ON DELETE CASCADE,
    PRIMARY KEY (ID)
);

CREATE TABLE Coupon (
    ID INTEGER PRIMARY KEY AUTO_INCREMENT,
    Name varchar(20),
    StartDate timestamp NOT NULL DEFAULT current_timestamp,
    EndDate timestamp NOT NULL DEFAULT current_timestamp,
    Discount varchar(15) NOT NULL,
    Limit_Money INTEGER,
    quantity INTEGER NOT NULL CHECK(quantity >= 0)
);

CREATE TABLE Category(
    ID INTEGER PRIMARY KEY AUTO_INCREMENT,
    Name varchar(20) NOT NULL 
);

CREATE TABLE product(
    ID INTEGER PRIMARY KEY AUTO_INCREMENT,
    Name varchar(20) NOT NULL,
    price INTEGER NOT NULL,
    Description varchar(500) NOT NULL,
    quantity INT NOT NULL,
    Sold_Out INT NOT NULL,
    CategoryID INTEGER NOT NULL,
    imgPath varchar(50),
    LaunchDate timestamp DEFAULT current_timestamp,
    ModifiedDate timestamp DEFAULT current_timestamp,
    Status Boolean DEFAULT True,
    sellerID INTEGER NOT NULL,
    FOREIGN KEY (sellerID) REFERENCES seller(ID) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (CategoryID) REFERENCES Category(ID) ON UPDATE CASCADE ON DELETE CASCADE
);

/*
Category 代號
1   紅茶
2   綠茶
3   派大星
...
*/

CREATE TABLE Orders(
    ID INTEGER PRIMARY KEY AUTO_INCREMENT,
    BuyerID INTEGER NOT NULL,
    SellerID INTEGER NOT NULL,
    CouponID INTEGER,
    Address varchar(50),
    OrderDate timestamp DEFAULT current_timestamp,
    ShipDate timestamp DEFAULT current_timestamp,
    Payment INTEGER NOT NULL,
    Receiving_Method varchar(20),
    status INTEGER NOT NULL,
    total INTEGER,
    FOREIGN KEY (SellerID) REFERENCES seller(ID) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (BuyerID) REFERENCES customer(ID) ON UPDATE CASCADE ON DELETE CASCADE
);

/*
status 代號
1   未出貨
2   配送中
3   等待取貨
4   完成
5   訂單取消
6   棄單
7   未下單(在購物車中)

Payment 代號
1   7-11取貨付款
2   全家取貨付款
3   郵寄
4   未定(在購物車中)
*/

CREATE TABLE order_list(
    OrderID INTEGER,
    ProductID INTEGER,
    Amount INTEGER,
    FOREIGN KEY (OrderID) REFERENCES Orders(ID) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES product(ID) ON UPDATE CASCADE ON DELETE CASCADE,
    PRIMARY KEY (OrderID, ProductID)
);

CREATE TABLE rate(
    Star INTEGER CHECK(Star >= 0 and Star <= 5),
    BuyerID INTEGER NOT NULL,
    SellerID INTEGER NOT NULL,
    OrderID INTEGER NOT NULL,
    RateTime timestamp DEFAULT current_timestamp,
    comment varchar(500),
    FOREIGN KEY (BuyerID) REFERENCES customer(ID) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (SellerID) REFERENCES seller(ID) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (OrderID) REFERENCES Orders(ID) ON UPDATE CASCADE ON DELETE CASCADE
);

-- init data
INSERT INTO member(Email, Password, Name, Phone_No, Sex)
VALUE('member1@example.com', '123', 'Jerry', '0123456789', 'M'); 
UPDATE member SET Token = 2 WHERE ID = 1;
INSERT INTO member(Email, Password, Name, Phone_No, Sex)
VALUE('member2@example.com', '123', 'Tom', '0123456780', 'M'); 
UPDATE member SET Token = 2 WHERE ID = 2;
INSERT INTO member(Email, Password, Name, Phone_No, Sex)
VALUE('member3@example.com', '123', 'Mia', '0123456788', 'F');
UPDATE member SET Token = 2 WHERE ID = 3;

INSERT INTO customer VALUE(1, 'Taipei', '123456');
INSERT INTO customer VALUE(2, 'Taipei', '234567');
INSERT INTO customer VALUE(3, 'Taipei', '345678');
INSERT INTO seller VALUE(2, '11111111111');
INSERT INTO seller VALUE(3, '22222222222');

INSERT INTO Coupon(Name, StartDate, EndDate, Discount, Limit_Money, quantity)
VALUE('7折', '2021-12-01', '2025-12-01', '70%', 5000, 500);
INSERT INTO Coupon(Name, StartDate, EndDate, Discount, Limit_Money, quantity)
VALUE('200元', '2021-12-01', '2025-12-01', '200', 500, 10000);
INSERT INTO Coupon(Name, StartDate, EndDate, Discount, Limit_Money, quantity)
VALUE('免運', '2021-12-01', '2025-12-01', 'free delivery', 700, 8000);

INSERT INTO Category VALUES
(1, 'redtea'),
(2, 'blacktea'),
(3, 'Patrick');

INSERT INTO product(Name, price, CategoryID, quantity, Sold_Out, imgPath, sellerID, Description, LaunchDate)
VALUE('Miaoli Maoli Black Tea', 675, 3, 20, 0, './img/64d6662d.jpg', 2, 'Taiwan-Tongluo-Agriculture and Forestry Tongluo Tea Garden', '2021-05-20');
INSERT INTO product(Name, price, CategoryID, quantity, Sold_Out, imgPath, sellerID, Description, LaunchDate)
VALUE('Daxi-Honey Fragrant Black Tea (Natural Farming Method)', 750, 1, 10, 0, './img/3e3ca728.jpg', 2, 'After being salivated by a small green leafhopper, the tender tea greens have a delicate fragrance, and the throat is full of sweet and mellow fragrance.', '2021-05-20');
INSERT INTO product(Name, price, CategoryID, quantity, Sold_Out, imgPath, sellerID, Description, LaunchDate)
VALUE('Organic Qinmi Black Tea', 950, 2, 30, 10, './img/b650222d.jpg', 3, 'Taiwan-Three Gorges-Agriculture and Forestry Xiongkong Ecological Organic Tea Garden', '2021-05-20');
INSERT INTO product(Name, price, CategoryID, quantity, Sold_Out, imgPath, sellerID, Description, LaunchDate)
VALUE('Qinmi Black Tea', 550, 3, 25, 3, './img/45e5363d.jpg', 3, 'Picked from Sanyi Agriculture and Forestry and Tongluo Tea Gardens, the tender tea greens have a delicate fragrance after being salivated by a small green leafhopper.', '2021-05-20');
INSERT INTO product(Name, price, CategoryID, quantity, Sold_Out, imgPath, sellerID, Description, LaunchDate)
VALUE('Selected Red Jade Black Tea', 750, 3, 20, 0, './img/94d72545.jpg', 3, 'Taiwan-Yuchi-Nonglin Yuchi Tea Garden', '2021-05-20');

INSERT INTO orders(BuyerID, SellerID, CouponID, Address, Payment, Receiving_Method, status, OrderDate) VALUES
(1, 2, NULL, 'taipei', 1, '7-11', 1, '2021-05-30'),
(1, 3, NULL, NULL, 4, NULL, 7, '2021-12-27');

INSERT INTO order_list VALUE(1, 1, 10);
INSERT INTO order_list VALUE(1, 2, 5);
INSERT INTO order_list VALUE(2, 4, 10);
INSERT INTO order_list VALUE(2, 5, 5);

INSERT INTO rate VALUE(4, 1, 2, 1, '2021-06-02', NULL);