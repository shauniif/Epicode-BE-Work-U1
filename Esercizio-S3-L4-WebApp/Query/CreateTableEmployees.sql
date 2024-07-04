﻿CREATE TABLE Employees
(
EmployeeID INT IDENTITY NOT NULL PRIMARY KEY,
LastName NVARCHAR(50) NOT NULL,
FirstName NVARCHAR(50) NOT NULL,
FiscalCode CHAR(16) NOT NULL,
Age int NOT NULL,
MonthlyIncome MONEY NOT NULL check(MonthlyIncome>0),
TaxDeduction BIT NOT NULL

)