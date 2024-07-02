--1) Selezione di tutti i prodotti (tutti i campi); --
SELECT ProductId, ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued
FROM Products 

-- 2) Selezione di tutti i prodotti con uno quantità disponibile (UnitsInStock) di almeno 40 pezzi; --
SELECT ProductId, ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued
FROM Products
WHERE UnitsInStock > 40

-- 3) Selezione di tutti i clienti (Employees) che abitano a Londra
SELECT EmployeeID, LastName, FirstName, Title, TitleofCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath
FROM Employees
WHERE City = 'London'

-- 4) Selezione di tutti gli ordini, ordinati in ordine decrescente per spese di trasporto (Freight),
SELECT OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName,ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry
FROM Orders
ORDER BY Freight desc

-- 5) Selezione degli ordini il cui importo del trasporto è superiore a 90 e inferiore i 200 -- 
SELECT OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName,ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry
FROM Orders
WHERE Freight BETWEEN 90 AND 200

-- 6) Selezione di tutti i prodotti la cui categoria è "1" -- 
SELECT OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName,ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry
FROM Orders
WHERE ShipVia = 1

-- 7) Selezione di tutte le righe dei dettagli degli ordini che hanno applicato uno sconto -- 
SELECT ORDERID, ProductID, UnitPrice, Quantity, Discount
FROM [Order Details]
WHERE Discount > 0

-- 8) Selezione di tutti gli ordini del cliente con ID "BOTTM" le cui spese di trasporto superano l'importo di 50.
SELECT OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName,ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry
FROM Orders
WHERE CustomerID = 'BOTTM' AND Freight > 50
