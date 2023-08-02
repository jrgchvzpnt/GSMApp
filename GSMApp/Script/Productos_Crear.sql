CREATE PROCEDURE Productos_Crear
    @NombreProducto VARCHAR(50),
    @DescripcionProducto VARCHAR(200),
    @Precio DECIMAL(18, 4),
    @Existencia DECIMAL(18, 4),
    @TipoProducto_Id INT,
    @FechaRegistro DATE,
    @FechaEliminado DATE
AS
BEGIN
    DECLARE @FechaRegistroCompleta DATETIME = CONVERT(DATETIME, @FechaRegistro);
    DECLARE @FechaEliminadoCompleta DATETIME = CONVERT(DATETIME, @FechaEliminado);

    IF @FechaRegistroCompleta IS NULL
        SET @FechaRegistroCompleta = GETDATE();

    INSERT INTO Producto (NombreProducto, DescripcionProducto, Precio, Existencia, TipoProducto_Id, FechaRegistro, FechaEliminado)
    VALUES (@NombreProducto, @DescripcionProducto, @Precio, @Existencia, @TipoProducto_Id, @FechaRegistroCompleta, @FechaEliminadoCompleta);
END