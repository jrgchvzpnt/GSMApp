-- Script para crear la tabla "TiposProductos"

CREATE TABLE TiposProductos (
    Id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    nombreTipoProducto VARCHAR(50),
    descripcionTipoProducto VARCHAR(200),
    FechaRegistro DATETIME,
    FechaEliminado DATETIME
);

INSERT INTO TiposProductos (nombreTipoProducto, descripcionTipoProducto, FechaRegistro, FechaEliminado)
VALUES ('Electrónicos', 'Productos electrónicos en general', GETDATE(), NULL);

INSERT INTO TiposProductos (nombreTipoProducto, descripcionTipoProducto, FechaRegistro, FechaEliminado)
VALUES ('Ropa', 'Prendas de vestir y accesorios', GETDATE(), NULL);

INSERT INTO TiposProductos (nombreTipoProducto, descripcionTipoProducto, FechaRegistro, FechaEliminado)
VALUES ('Alimentos', 'Productos comestibles', GETDATE(), NULL);

INSERT INTO TiposProductos (nombreTipoProducto, descripcionTipoProducto, FechaRegistro, FechaEliminado)
VALUES ('Hogar', 'Artículos para el hogar', GETDATE(), NULL);

INSERT INTO TiposProductos (nombreTipoProducto, descripcionTipoProducto, FechaRegistro, FechaEliminado)
VALUES ('Deportes', 'Artículos deportivos y recreativos', GETDATE(), NULL);




CREATE TABLE Producto (
    Id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    NombreProducto VARCHAR(50),
    DescripcionProducto VARCHAR(200),
    Precio DECIMAL(18, 4),
    Existencia DECIMAL(18, 4),
    TipoProducto_Id INT,
    FechaRegistro DATETIME,
    FechaEliminado DATETIME,
    FOREIGN KEY (TipoProducto_Id) REFERENCES TiposProductos (Id)
);

INSERT INTO Producto (NombreProducto, DescripcionProducto, Precio, Existencia, TipoProducto_Id, FechaRegistro, FechaEliminado)
VALUES ('Smartphone', 'Teléfono inteligente de última generación', 599.99, 50, 1, GETDATE(), NULL);

INSERT INTO Producto (NombreProducto, DescripcionProducto, Precio, Existencia, TipoProducto_Id, FechaRegistro, FechaEliminado)
VALUES ('Televisor', 'Televisor LED de 55 pulgadas', 799.99, 30, 1, GETDATE(), NULL);

INSERT INTO Producto (NombreProducto, DescripcionProducto, Precio, Existencia, TipoProducto_Id, FechaRegistro, FechaEliminado)
VALUES ('Camiseta', 'Camiseta de algodón de color blanco', 19.99, 100, 2, GETDATE(), NULL);


INSERT INTO Producto (NombreProducto, DescripcionProducto, Precio, Existencia, TipoProducto_Id, FechaRegistro, FechaEliminado)
VALUES ('Cafetera', 'Cafetera automática con molinillo integrado', 129.99, 20, 3, GETDATE(), NULL);

INSERT INTO Producto (NombreProducto, DescripcionProducto, Precio, Existencia, TipoProducto_Id, FechaRegistro, FechaEliminado)
VALUES ('Pelota de fútbol', 'Pelota oficial para partidos de fútbol', 24.99, 50, 4, GETDATE(), NULL);


INSERT INTO Producto (NombreProducto, DescripcionProducto, Precio, Existencia, TipoProducto_Id, FechaRegistro, FechaEliminado)
VALUES ('Crema 12312312312', 'Crema marca GOICOECHEA', 125.99, 2, 1, GETDATE(), NULL);


