CREATE DATABASE EmployeeDB

CREATE TABLE dbo.Department(
DepartmentId int identity(1,1),
DepartmentName varchar(500),
ManagerId int,
NoOfEmp int DEFAULT 0,
PRIMARY KEY(DepartmentId),
)


CREATE TABLE dbo.Employee(
EmployeeId int identity(1,1),
EmployeeName varchar(500),
DateOfJoining date DEFAULT GETDATE(),
PhotoFileName varchar(500),
PhoneNumber int,
EmailAddress varchar(500),
Position varchar(500),
Salary int,
DepId int
PRIMARY KEY(EmployeeId),
FOREIGN KEY(DepId)
REFERENCES dbo.Department(DepartmentId)
)

select *
from dbo.Employee