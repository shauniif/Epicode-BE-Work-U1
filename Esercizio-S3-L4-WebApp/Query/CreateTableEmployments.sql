﻿CREATE TABLE Employments (
IdEmployment INT IDENTITY NOT NULL,
Type NVARCHAR(200) NOT NULL,
DateHire DATETIME2(7) NOT NULL,
EmployeeID INT NULL,
FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
)