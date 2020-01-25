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
	FechaNacimiento dateTime


);