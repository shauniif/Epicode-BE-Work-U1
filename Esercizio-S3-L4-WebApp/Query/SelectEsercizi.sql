-- a. Visualizzare tutti gli impiegati oltre i 29 anni;  
	SELECT CONCAT(e.LastName, ' ', e.FirstName) as Employee, e.FiscalCode as FiscalCode, e.Age as Age, e.MonthlyIncome as MonthlyIncome, e.TaxDeduction as TaxDeduction 
	FROM Employees AS e
	WHERE e.Age > 29
-- b. Visualizzare tutti gli impiegati con un reddito di almeno 800 euro mensili; 
	SELECT CONCAT(e.LastName, ' ', e.FirstName) as Employee, e.FiscalCode as FiscalCode, e.Age as Age, e.MonthlyIncome as MonthlyIncome, e.TaxDeduction as TaxDeduction 
	FROM Employees AS e
	WHERE e.MonthlyIncome > 800.00
-- c. Visualizzare tutti gli impiegati che posseggono la detrazione fiscale;  
	SELECT CONCAT(e.LastName, ' ', e.FirstName) as Employee, e.FiscalCode as FiscalCode, e.Age as Age, e.MonthlyIncome as MonthlyIncome, e.TaxDeduction as TaxDeduction 
	FROM Employees AS e
	WHERE TaxDeduction = 1
-- d. Visualizzare tutti gli impiegati che non posseggono la detrazione fiscale;  
	SELECT CONCAT(e.LastName, ' ', e.FirstName) as Employee, e.FiscalCode as FiscalCode, e.Age as Age, e.MonthlyIncome as MonthlyIncome, e.TaxDeduction as TaxDeduction 
	FROM Employees AS e
	WHERE TaxDeduction = 0
-- e. Visualizzare tutti gli impiegati cui il cognome cominci con una lettera G e li visualizzi in ordine alfabetico; 
	SELECT CONCAT(e.LastName, ' ', e.FirstName) as Employee, e.FiscalCode as FiscalCode, e.Age as Age, e.MonthlyIncome as MonthlyIncome, e.TaxDeduction as TaxDeduction 
	FROM Employees AS e
	WHERE e.LastName LIKE 'G%'
	ORDER BY e.LastName ASC
-- f. Visualizzare il numero totale degli impiegati registrati nella base dati;  
	SELECT  COUNT(*) as NumberOfEmployee
	FROM Employees AS e
-- g. Visualizzare il totale dei redditi mensili di tutti gli impiegati;  
	SELECT SUM(e.MonthlyIncome) as TotalIncome
	FROM Employees AS e
-- h. Visualizzare la media dei redditi mensili di tutti gli impiegati;  
	SELECT AVG(e.MonthlyIncome) as TotalIncome
	FROM Employees AS e
-- i. Visualizzare l’importo del reddito mensile maggiore; 
	SELECT MAX(e.MonthlyIncome) as TotalIncome
	FROM Employees AS e
-- j. Visualizzare l’importo del reddito mensile minore;  
	SELECT MIN(e.MonthlyIncome) as TotalIncome
	FROM Employees AS e
-- k. Visualizzare gli impiegati assunti dall’ 01/01/2007 all’ 01/01/2008;  
	SELECT CONCAT(e.LastName, ' ', e.FirstName) as Employee, e.FiscalCode as FiscalCode, e.Age as Age, e.MonthlyIncome as MonthlyIncome, e.TaxDeduction as TaxDeduction 
	FROM Employees AS e	JOIN Employments AS em ON e.EmployeeID = em.EmployeeID
	WHERE em.DateHire BETWEEN '01-01-2007' AND '01-01-2008'
	
-- l. Tramite una query parametrica che identifichi il tipo di impiego, visualizzare tutti gli impiegati che corrispondono a quel tipo di impiego;  
	SELECT CONCAT(e.LastName, ' ', e.FirstName) as Employee, em.Type as TypeEmployement
	FROM Employees e
	JOIN Employments em ON e.EmployeeID = em.EmployeeID
-- m. Visualizzare l’età media dei lavoratori all’interno dell’azienda.  
	SELECT AVG(e.Age) as AvarageAge
	FROM Employees AS e