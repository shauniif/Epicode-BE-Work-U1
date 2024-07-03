-- 1) Numero totale degli ordini,

SELECT COUNT(*) as TotaleOrdini
FROM Orders

-- 2) Numero totale di clienti,

SELECT COUNT(*) as TotaleClienti
FROM Customers

-- 3) Numero totale di clienti che abitano a Londra,

SELECT COUNT(*) as TotaleClienti
FROM Customers
WHERE City = 'London'

-- 4) La media aritmetica del costo del trasporto di tutti gli ordini effettuati
SELECT AVG(Freight) as MediaDeicostiDiTrasporto
FROM Orders
-- 5) La media aritmetica del costo del trasporto dei soli ordini effettuati dal cliente "BOTTM"
SELECT AVG(Freight) as TotaleCostiDiTrasporto
FROM Orders
WHERE CustomerID = 'BOTTM'
-- 6) Totale delle spese di trasporto effettuate raggruppate per id cliente
SELECT CustomerID,SUM(Freight) as TotaleCostiDiTrasporto
FROM Orders
GROUP BY CustomerID
-- 7) Numero totale di clienti raggruppati per città di appartenenza
SELECT City, COUNT(*) as NumerodeiClientiPerCitta
FROM Customers
GROUP BY City
-- 8) Totale di UnitPrice * Quantity raggruppato per ogni ordine
SELECT OrderId, SUM(UnitPrice * Quantity) as TotaleOrdini
FROM [Order Details]
GROUP BY OrderID
ORDER BY OrderID asc
-- 9) Totale di UnitPrice * Quantity solo dell'ordine con id=10248
SELECT OrderId, SUM(UnitPrice * Quantity) as TotaleOrdini
FROM [Order Details]
GROUP BY OrderID
HAVING OrderID = 10248
-- 10) Numero di prodotti censiti per ogni categoria 
SELECT CategoryID, COUNT(*) as ProdottiCensiti
FROM Products
GROUP BY CategoryID
-- 11) Numero totale di ordini raggruppati per paese di spedizione (ShipCountry)
SELECT ShipCountry, COUNT(*) as NumeroOrdiniPerPaese
FROM Orders
GROUP BY ShipCountry
-- 12) La media del costo del trasporto raggruppati per paese di spedizione (ShipCountry)
SELECT ShipCountry, AVG(Freight) as SpesaMediaPerPaese
FROM Orders
GROUP BY ShipCountry