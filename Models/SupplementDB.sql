DROP TABLE IF EXISTS Transactions;
DROP TABLE IF EXISTS OrderItems;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS Users;
DROP TABLE IF EXISTS Addresses;
DROP TABLE IF EXISTS Cities;
DROP TABLE IF EXISTS States;
DROP TABLE IF EXISTS Countries;
DROP TABLE IF EXISTS Sales;

CREATE TABLE Countries (
    CountryID INT PRIMARY KEY IDENTITY(1,1),
    CountryName VARCHAR(100) NOT NULL
    -- Add more fields as needed
);

CREATE TABLE States (
    StateID INT PRIMARY KEY IDENTITY(1,1),
    StateName VARCHAR(100) NOT NULL,
    CountryID INT NOT NULL,
    FOREIGN KEY (CountryID) REFERENCES Countries(CountryID)
    -- Add more fields as needed
);

CREATE TABLE Cities (
    CityID INT PRIMARY KEY IDENTITY(1,1),
    CityName VARCHAR(100) NOT NULL,
    StateID INT NOT NULL,
    FOREIGN KEY (StateID) REFERENCES States(StateID)
    -- Add more fields as needed
);

CREATE TABLE Addresses (
    AddressID INT PRIMARY KEY IDENTITY(1,1),
    StreetAddress VARCHAR(255) NOT NULL,
    CityID INT NOT NULL,
    FOREIGN KEY (CityID) REFERENCES Cities(CityID)
    -- Add more fields as needed
);

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    PasswordHash VARCHAR(100) NOT NULL,
    ShippingAddressID INT NOT NULL,
    BillingAddressID INT NOT NULL,
    FOREIGN KEY (ShippingAddressID) REFERENCES Addresses(AddressID),
    FOREIGN KEY (BillingAddressID) REFERENCES Addresses(AddressID)
    -- Add more fields as needed
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    Description TEXT,
    Price DECIMAL(10, 2) NOT NULL,
    QuantityInStock INT NOT NULL

    -- Add more fields as needed
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    OrderDate DATETIME NOT NULL,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    Status VARCHAR(50) NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
    -- Add more fields as needed
);

CREATE TABLE OrderItems (
    OrderItemID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
    -- Add more fields as needed
);

CREATE TABLE Transactions (
    TransactionID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT NOT NULL,
    TransactionDate DATETIME NOT NULL,
    PaymentMethod VARCHAR(50) NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
    -- Add more fields as needed
);

CREATE TABLE Sales (
    SalesID INT PRIMARY KEY IDENTITY(1,1),
    StartDate DATETIME NOT NULL, 
    EndDate DATETIME NOT NULL,
    ProductID INT NOT NULL,
    Price DECIMAL(10, 2),
    Name VARCHAR(100),
    SalesPercentage DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
    -- Add more fields as needed
);

-- Entering dummy data

-- Insert data into Countries table
INSERT INTO Countries (CountryName) VALUES 
('United States'), 
('Canada'), 
('United Kingdom');

-- Insert data into States table
INSERT INTO States (StateName, CountryID) VALUES 
('California', 1), 
('New York', 1),
('Ontario', 2),
('Quebec', 2),
('London', 3),
('Manchester', 3);

-- Insert data into Cities table
INSERT INTO Cities (CityName, StateID) VALUES 
('Los Angeles', 1),
('San Francisco', 1),
('New York City', 2),
('Toronto', 3),
('Ottawa', 4),
('London', 5),
('Manchester', 6);

-- Insert data into Addresses table
INSERT INTO Addresses (StreetAddress, CityID) VALUES 
('123 Main St', 1),
('456 Elm St', 2),
('789 Oak St', 3),
('101 Maple Ave', 4),
('202 Pine St', 5),
('303 Cedar Ave', 6);

-- Insert data into Users table
INSERT INTO Users (Username, Email, PasswordHash, ShippingAddressID, BillingAddressID) VALUES 
('user1', 'user1@example.com', 'password1', 1, 1),
('user2', 'user2@example.com', 'password2', 2, 3),
('user3', 'user3@example.com', 'password3', 4, 5);

-- Insert data into Products table
INSERT INTO Products (Name, Description, Price, QuantityInStock) VALUES
('Whey Protein', 'High-quality protein powder for muscle building', 29.99, 5000),
('Multivitamin', 'Daily multivitamin for overall health', 19.99, 250),
('Creatine Monohydrate', 'Creatine supplement for strength and endurance', 24.99, 234),
('BCAA', 'Branched-chain amino acids for muscle recovery', 22.99, 690),
('Banana', 'A single ripe banana', 0.49, 500),
('Whey Protein - Chocolate', 'High-quality chocolate-flavored protein powder for muscle building', 29.99, 100),
('Whey Protein - Vanilla', 'High-quality vanilla-flavored protein powder for muscle building', 29.99, 100),
('Whey Protein - Strawberry', 'High-quality strawberry-flavored protein powder for muscle building', 29.99, 100),
('Casein Protein - Chocolate', 'Slow-digesting chocolate-flavored protein powder for nighttime muscle recovery', 34.99, 75),
('Casein Protein - Vanilla', 'Slow-digesting vanilla-flavored protein powder for nighttime muscle recovery', 34.99, 75),
('Casein Protein - Cookies and Cream', 'Slow-digesting cookies and cream-flavored protein powder for nighttime muscle recovery', 34.99, 75),
('XtremeGains Whey Protein', 'Premium whey protein powder for maximum gains', 39.99, 120),
('MuscleMax Nitro Whey Isolate', 'Advanced whey protein isolate formula for rapid muscle growth', 44.99, 90),
('EpicMuscle ISO100 Whey Protein', 'Fast-absorbing whey protein isolate for intense workouts', 49.99, 80),
('SuperVit Men Multivitamin', 'Specially formulated multivitamin for men to support overall health', 19.99, 50),
('SuperVit Women Multivitamin', 'Specially formulated multivitamin for women to support overall health', 19.99, 50),
('OrganicLife Organic Multivitamin', 'Certified organic multivitamin with whole food ingredients', 29.99, 40),
('PureGain Creatine Monohydrate', 'Pure creatine monohydrate powder for strength and endurance', 24.99, 75),
('MuscleFuel BCAA', 'Branched-chain amino acids for muscle recovery and growth', 22.99, 80),
('MaxPower Xtend BCAA', 'Intra-workout BCAA supplement for enhanced performance and recovery', 27.99, 70);



-- Insert data into Orders table
INSERT INTO Orders (UserID, OrderDate, TotalAmount, Status) VALUES 
(1, '2024-03-31 10:00:00', 29.99, 'Completed'),
(2, '2024-03-30 14:30:00', 69.98, 'Completed'),
(3, '2024-03-29 11:45:00', 42.98, 'Pending');

-- Insert data into OrderItems table
INSERT INTO OrderItems (OrderID, ProductID, Quantity) VALUES 
(1, 1, 1),
(2, 2, 2),
(2, 3, 1),
(3, 4, 1);

-- Insert data into Transactions table
INSERT INTO Transactions (OrderID, TransactionDate, PaymentMethod, Amount) VALUES 
(1, '2024-03-31 10:05:00', 'Credit Card', 29.99),
(2, '2024-03-30 14:35:00', 'PayPal', 69.98),
(3, '2024-03-29 11:50:00', 'Credit Card', 42.98);

-- Insert data into Sales table
INSERT INTO Sales (StartDate, EndDate, ProductID,  Price, Name, SalesPercentage) VALUES 
('2024-05-04 00:00:00', '2024-05-08 23:59:59', 1 , 0.00, 'Blank', .5),
('2024-05-04 00:00:00', '2024-05-08 23:59:59', 2 , 0.00, 'Blank',  .5),
('2024-05-04 00:00:00', '2024-05-08 23:59:59', 3 ,  0.00, 'Blank', .5),
('2024-03-03 10:00:00', '2024-03-10 23:59:59', 1 , 0.00, 'Blank', .5),
('2024-04-04 06:00:00', '2024-04-14 23:59:59', 2 ,  0.00, 'Blank', .5);



-- test queries

-- Retrieve all users along with their shipping addresses
SELECT u.Username, u.Email, a.StreetAddress, c.CityName, s.StateName, co.CountryName
FROM Users u
JOIN Addresses a ON u.ShippingAddressID = a.AddressID
JOIN Cities c ON a.CityID = c.CityID
JOIN States s ON c.StateID = s.StateID
JOIN Countries co ON s.CountryID = co.CountryID;

-- List all orders with their associated products and quantities
SELECT o.OrderID, p.Name AS ProductName, oi.Quantity
FROM Orders o
JOIN OrderItems oi ON o.OrderID = oi.OrderID
JOIN Products p ON oi.ProductID = p.ProductID;

-- Calculate total revenue for each order
SELECT OrderID, SUM(Amount) AS TotalRevenue
FROM Transactions
GROUP BY OrderID;

-- Find out which products are out of stock
SELECT Name AS OutOfStockProducts
FROM Products
WHERE QuantityInStock = 0;

-- List all users who have placed orders
SELECT DISTINCT u.Username
FROM Users u
JOIN Orders o ON u.UserID = o.UserID;


-- List all Sales with their Products
SELECT Sales.SalesID, Sales.StartDate, Sales.EndDate, Sales.SalesPercentage, Products.Price, Products.Name 
FROM Sales 
JOIN Products  ON Sales.ProductID = Products.ProductID;



