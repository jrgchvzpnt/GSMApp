
CREATE PROCEDURE Productos_Actualizar
    @Id INT,
    @NombreProducto VARCHAR(50),
    @DescripcionProducto VARCHAR(200),
    @Precio DECIMAL(18, 4),
    @Existencia DECIMAL(18, 4),
    @TipoProducto_Id INT
AS
BEGIN
    UPDATE Producto
    SET NombreProducto = @NombreProducto,
        DescripcionProducto = @DescripcionProducto,
        Precio = @Precio,
        Existencia = @Existencia,
        TipoProducto_Id = @TipoProducto_Id
    WHERE Id = @Id;
END