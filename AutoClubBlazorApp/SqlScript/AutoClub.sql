CREATE DATABASE AutoClub
GO

USE AutoClub

CREATE TABLE Owners 
(
 Id INT PRIMARY KEY IDENTITY,
 LastName NVARCHAR(200),
 FirstName NVARCHAR(200),
 Birthday DateTime2
);
GO
 CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY,
	CarBrand NVARCHAR(200),
	[Type] NVARCHAR(200),
	LicensePlate NVARCHAR(8),
	TimeOfProduction DateTime2
);
GO

CREATE TABLE OwnersAndCarsConnection
(
   Id INT PRIMARY KEY IDENTITY,
   OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
   CarId INT FOREIGN KEY REFERENCES Cars(Id)
);

GO

ALTER TABLE OwnersAndCarsConnection   
ADD CONSTRAINT UN_OwnerId_CarId UNIQUE (OwnerId, CarId);   
GO  


CREATE PROCEDURE dbo.GetOwnerCars @OwnerId int OUT
AS
SELECT c.Id, c.CarBrand, c.[Type], c.LicensePlate, c.TimeOfProduction FROM [AutoClub].[dbo].[Cars] AS c INNER JOIN [AutoClub].[dbo].[OwnersAndCarsConnection] AS oc ON c.Id = oc.CarId WHERE OC.OwnerId=@OwnerId