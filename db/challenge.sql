IF OBJECT_ID('Region') IS NOT NULL
DROP TABLE Region;
IF OBJECT_ID('Order') IS NOT NULL
DROP TABLE [Order];
IF OBJECT_ID('Product') IS NOT NULL
DROP TABLE Product;
IF OBJECT_ID('Category') IS NOT NULL
DROP TABLE Category;
IF OBJECT_ID('Customer') IS NOT NULL
DROP TABLE Customer;
IF OBJECT_ID('Segment') IS NOT NULL
DROP TABLE Segment;
IF OBJECT_ID('Shipping') IS NOT NULL
DROP TABLE Shipping;






CREATE TABLE Category ( 
    CatID INT,
    CatName NVARCHAR(100),
    PRIMARY KEY (CatID)
);

CREATE TABLE Segment (
    SegID INT,
    SegName NVARCHAR(100),
    PRIMARY KEY (SegID)
);

CREATE TABLE Product (
    ProdID NVARCHAR(100),
    CatID INT,
    [Description] NVARCHAR(100),
    UnitPrice Money,
    PRIMARY KEY (ProdID),
    FOREIGN KEY (CatID) REFERENCES Category
);

CREATE TABLE Customer (
    CustID NVARCHAR(100), 
    FullName NVARCHAR(100),
    SegID INT,
    Country NVARCHAR(100),
    City NVARCHAR(100),
    [State] NVARCHAR(100),
    PostCode INT,
    Region NVARCHAR(100)
    PRIMARY KEY (CustID),
    FOREIGN KEY (SegID) REFERENCES Segment
);

CREATE TABLE Shipping (
    ShipMode NVARCHAR(100)
    PRIMARY KEY(ShipMode)
)
CREATE TABLE [Order] (
    CustID NVARCHAR(100), 
    ProdID NVARCHAR(100),
    OrderDate DATETIME,
    Quantity INT,
    ShipDate DATETIME,
    ShipMode NVARCHAR(100),
    PRIMARY KEY (OrderDate),
    FOREIGN KEY (ProdID) REFERENCES Product,
    FOREIGN KEY (CustID) REFERENCES Customer,
    FOREIGN KEY (ShipMode) REFERENCES Shipping
);

CREATE TABLE REGION (
    Region NVARCHAR(100)
    PRIMARY KEY (REGION)
)

INSERT INTO CATEGORY (CatID, CatName)
VALUES (1, 'Furniture'),
       (2, 'Office Supplies'),
       (3, 'Technology')

INSERT INTO Segment (SegID, SegName) VALUES
(1, 'Consumer'),
(2, 'Corporate'),
(3, 'Home Office')

INSERT INTO Product (ProdID, CatID, [Description], UnitPrice) VALUES
('FUR-BO-10001798', 1, 'Bush Somerset Collection Bookcase', 261.96),
('FUR-CH-10000454', 3, 'Mitel 5320 IP Phone VoIP phone', 731.94),
('OFF-LA-10000240', 2, 'Self-Adhesive Address Labels for Typewriters by Universal', 14.62)

INSERT INTO Customer (CustID, FullName, SegID, Country, City, [State], PostCode, Region) VALUES
('CG-12520', 'Claire Gute', 1, 'United States', 'Henderson', 'Oklahoma', 42420, 'Central'),
('DV-13045', 'Darrin Van Huff', 2, 'United States', 'Los Angeles', 'California', 90036, 'West'),
('SO-20335', 'Sean ODonnell', 1, 'United States Fort', 'Lauderdale', 'Florida', 33311, 'South'),
('BH-11710', 'Brosina Hoffman', 3, 'United States', 'Los Angeles', 'California', 90032, 'West');

INSERT INTO Shipping (ShipMode) VALUES
('Second Class'),
('Standard Class'),
('First Class'),
('Overnight Express');

INSERT INTO [Order] (CustID, ProdID, OrderDate, Quantity, ShipDate, ShipMode) VALUES
    ('CG-12520','FUR-BO-10001798','2016-11-09 00:00:00',2,'2016-11-11 00:00:00','Second Class'),
    ('CG-12520','FUR-CH-10000454','2016-11-08 00:00:00',3,'2016-11-11 00:00:00','Second Class'),
    ('CG-12520','OFF-LA-10000240','2016-06-12 00:00:00',2,'2016-06-16 00:00:00','Second Class'),
    ('DV-13045','OFF-LA-10000240','2015-11-21 00:00:00',2,'2015-11-26 00:00:00','Second Class'),
    ('DV-13045','OFF-LA-10000240','2014-10-11 00:00:00',1,'2014-10-15 00:00:00','Standard Class'),
    ('DV-13045','FUR-CH-10000454','2016-11-12 00:00:00',9,'2016-11-16 00:00:00','Standard Class'),
    ('SO-20335','OFF-LA-10000240','2016-09-02 00:00:00',5,'2016-09-08 00:00:00','Standard Class'),
    ('SO-20335','FUR-BO-10001798','2017-08-25 00:00:00',2,'2017-08-29 00:00:00','Overnight Express'),
    ('SO-20335','FUR-CH-10000454','2017-06-22 00:00:00',2,'2017-06-26 00:00:00','Standard Class'),
    ('SO-20335','FUR-BO-10001798','2017-05-01 00:00:00',3,'2017-05-02 00:00:00','First Class');

INSERT INTO REGION (Region) VALUES
('South'),
('Central'),
('West'),
('East'),
('North');


select * from Category
Select * from Segment
select * from Product
select * from [Order]
Select * from Customer
select * from Shipping
select * from REGION