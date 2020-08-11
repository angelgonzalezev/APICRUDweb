CREATE DATABASE Clientes; 

select * from DataClient

CREATE TABLE DataClient(
	id	INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Nombre nvarchar(50) NOT NULL,
	PrimerApellido NVARCHAR (50) NOT NULL,
	SegundoApellido NVARCHAR(50) NOT NULL,
	FechaAfiliacion	NVARCHAR(50) NOT NULL,
	)

CREATE OR ALTER PROCEDURE spInsertClient (@Name nvarchar(50), @F_Surname NVARCHAR(50), @S_Surname NVARCHAR(50), @DATE NVARCHAR(50))
AS		
	INSERT INTO DataClient (Nombre, PrimerApellido, SegundoApellido, FechaAfiliacion) VALUES (@Name, @F_Surname, @S_Surname, @DATE)
GO

CREATE OR ALTER PROCEDURE spDeleteClientById (@id int)
AS		
	DELETE FROM DataClient WHERE id = @id;
GO

CREATE OR ALTER PROCEDURE spShowClientByNameOrderDesc (@name nvarchar(50))
AS		
	SELECT * FROM DataClient WHERE Nombre=(@name) ORDER BY Nombre DESC
GO

CREATE OR ALTER PROCEDURE spShowClientById (@id int)
AS
	SELECT * FROM DataClient WHERE id=(@id)
GO

CREATE OR ALTER PROCEDURE spShowAllClients
AS
	SELECT * FROM DataClient
GO

CREATE OR ALTER PROCEDURE spUpdateUser (@id int, @name NVARCHAR(50), @fSurname NVARCHAR(50), @sSurname NVARCHAR(50))
AS
	UPDATE DataClient SET Nombre = @name, PrimerApellido =  @fSurname, SegundoApellido= @sSurname

	where id=@id
GO

CREATE PROCEDURE [dbo].[spGetClientByParameter] (@name nvarchar(50), @fechaInicio nvarchar(50), @fechaFinal nvarchar(50))
AS		
	SELECT * FROM DataClient WHERE Nombre=(@name) AND FechaAfiliacion >= (@fechaInicio) AND FechaAfiliacion <= (@fechaFinal)

select * from DataClient


--EXEC spShowClientById '3'