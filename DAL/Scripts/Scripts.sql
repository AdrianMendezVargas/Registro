create database PersonasDb
go
use PersonasDb
go
create table Personas
(
	PersonaID int primary key identity,
	Nombre varchar(30),
	Telefono varchar(15),
	Cedula varchar(15),
	Direccion varchar(max),
	Balance decimal,
	FechaNacimiento dateTime

);

Create Table Inscripciones
(
	InscripcionId int primary key identity,
	PersonaId int,
	Fecha dateTime,
	Comentario varchar(50),
	Monto decimal,
	Balance decimal

);