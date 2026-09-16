CREATE DATABASE BillingDB;
GO
USE BillingDB;
GO
CREATE TABLE CUSTOMERS(
customerID INT PRIMARY KEY,
customername NVARCHAR(50),
Age INT)
DROP TABLE IF EXISTS Invoices;
CREATE TABLE Invoices(
InovicesID INT PRIMARY KEY,
CustomerID INT,
Itemname NVARCHAR(50),
price DECIMAL(10, 2),
FOREIGN KEY(CUSTOMERID) REFERENCES Customers(customerID));
INSERT INTO CUSTOMERS (customerID, customername, Age) 
VALUES (1, 'Musbah', 21),
       (2, 'Ahmad', 25),
       (3, 'Sami', 30); 

INSERT INTO Invoices (InovicesID, CustomerID, Itemname, price)
VALUES (101, 1, 'Keyboard', 150.00),
       (102, 1, 'Medical Item', 50.00),
       (103, 2, 'Mouse', 20.00);
SELECT CUSTOMERS.customername, Invoices.Itemname, Invoices.price
FROM CUSTOMERS
INNER JOIN Invoices ON CUSTOMERS.customerID = Invoices.CustomerID;

SELECT CUSTOMERS.customername, Invoices.Itemname, Invoices.price
FROM CUSTOMERS
LEFT JOIN Invoices ON CUSTOMERS.customerID = Invoices.CustomerID;
CREATE PROCEDURE GetCustomerInvoices 
    @CustID INT
AS
BEGIN
    SELECT * 
    FROM Invoices 
    WHERE CustomerID = @CustID;
END;
GO
EXEC GetCustomerInvoices @CustID = 1;

CREATE INDEX IX_Invoices_CustomerID
ON Invoices (CustomerID);
GO
EXEC sp_helpindex 'Invoices';
