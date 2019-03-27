CREATE DATABASE ProyectoFinalDb
GO
USE ProyectoFinalDb
GO

Create table Usuarios(
UsuarioId int identity (1,1) primary key,
Fecha date,
Nombre varchar (30),
NombreUser varchar (15),
Clave varchar (15),
Tipo varchar (15)

);

INSERT INTO Usuarios(Fecha,Nombre,NombreUser,Clave,Tipo) VALUES('2019/03/27','Oscar','Oscar Slater','123','Administrador' );

create table Clientes(

ClienteId int identity (1,1) primary key,
Nombre varchar (30),
Cedula varchar (15),
Direccion varchar (30),
Sexo varchar (10),
Telefono varchar (15),
FechaNacimiento date,
FechaRegistro date,
VehiculosRentados int

);

create table RentasDetalle(
DetalleId int identity (1,1) primary key,
ClienteId int,
VehiculoId int,
RentaId int,
Anio int,
Marca varchar (30),
Modelo varchar (30),
Precio decimal
);

create table Renta(
RentaId int identity (1,1) primary key,
FechaRegistro date,
FechaDevuelta date
);


create table Vehiculos(
VehiculoId int identity (1,1) primary key,
FechaRegistro date,
Tipo varchar (30),
Marca varchar (30),
Modelo varchar (30),
Placa varchar(20),
Anio int,
Color varchar (15),
Descripcion varchar (60),
PrecioRenta decimal
);