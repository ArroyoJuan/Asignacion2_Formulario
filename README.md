# Base de datos
CREATE DATABASE TiendaDB;


CREATE TABLE Productos(
Id int identity primary key,
Nombre VarChar(100) not null,
Descripcion VarChar(200) not null,
Precio decimal (10,2),
Stock int 
);




INSERT INTO Productos (Nombre, Descripcion, Precio, Stock)
VALUES ('Producto A', 'Descripción del producto A', 100.50, 10),
       ('Producto B', 'Descripción del producto B', 200.75, 5),
       ('Producto C', 'Descripción del producto C', 50.00, 20);

	 
select *  from Productos;


CREATE PROCEDURE spInsertarProducto
    @Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(255),
    @Precio DECIMAL(10, 2),
    @Stock INT
AS
BEGIN
    INSERT INTO Productos (Nombre, Descripcion, Precio, Stock)
    VALUES (@Nombre, @Descripcion, @Precio, @Stock);
END;


CREATE PROCEDURE spObtenerProductos
AS
BEGIN
    SELECT * FROM Productos;
END;


CREATE PROCEDURE spActualizarProducto
    @Id INT,
    @Precio DECIMAL(10, 2),
    @Stock INT
AS
BEGIN
    UPDATE Productos
    SET Precio = @Precio, Stock = @Stock
    WHERE Id = @Id;
END;

CREATE PROCEDURE spEliminarProducto
    @Id INT
AS
BEGIN
    DELETE FROM Productos
    WHERE Id = @Id;
END;
