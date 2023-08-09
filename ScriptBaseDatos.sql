create database PruebaPracticaCooperex;

USE PruebaPracticaCooperex;

CREATE TABLE Producto(
	idProducto int identity primary key,
	CodigoProducto varchar(20) NOT NULL,
	NombreProducto varchar(50) NOT NULL,
	Cantidad int,
	Descripcion varchar(200),
	Estado int
)

CREATE TABLE Kardex(
	idKardex int identity primary key,
	idProducto int,
	Movimiento varchar(20) NOT NULL,
	Cantidad int,
	Fecha DATE,
	CONSTRAINT fk_Producto FOREIGN KEY (idProducto) REFERENCES Producto (idProducto)
)

CREATE PROCEDURE InsertarProducto
	@CodigoProducto varchar(20),
	@NombreProducto varchar(50),
	@Cantidad int,
	@Descripcion varchar(200)
AS
	DECLARE @Identity INT

	INSERT INTO Producto(CodigoProducto,NombreProducto,Cantidad,Descripcion,Estado) VALUES (@CodigoProducto,@NombreProducto,@Cantidad,@Descripcion,1)
	SET @Identity = SCOPE_IDENTITY()

	INSERT INTO Kardex(idProducto,Movimiento,Cantidad,Fecha) VALUES (@Identity,'Entrada',@Cantidad,GETDATE())
GO


CREATE PROCEDURE ActualizarProducto
	@id int,
	@CodigoProducto varchar(20),
	@NombreProducto varchar(50),
	@Cantidad int,
	@Descripcion varchar(200)
AS

	UPDATE Producto SET CodigoProducto = @CodigoProducto, NombreProducto = @NombreProducto, Cantidad = @Cantidad, Descripcion = @Descripcion WHERE idProducto = @id

	INSERT INTO Kardex(idProducto,Movimiento,Cantidad,Fecha) VALUES (@id,'Entrada',@Cantidad,GETDATE())
GO


CREATE PROCEDURE SalidaProducto
	@id int,
	@Cantidad int
AS
	UPDATE Producto SET Cantidad = Cantidad - @Cantidad WHERE idProducto = @id

	INSERT INTO Kardex(idProducto,Movimiento,Cantidad,Fecha) VALUES (@id,'Salida',@Cantidad,GETDATE())
GO


CREATE PROCEDURE EntradaProducto
	@id int,
	@Cantidad int
AS
	UPDATE Producto SET Cantidad = Cantidad + @Cantidad WHERE idProducto = @id

	INSERT INTO Kardex(idProducto,Movimiento,Cantidad,Fecha) VALUES (@id,'Salida',@Cantidad,GETDATE())
GO


