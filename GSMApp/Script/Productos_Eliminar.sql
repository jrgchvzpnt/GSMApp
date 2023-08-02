CREATE PROCEDURE Productos_Eliminar
    @Id INT
AS
BEGIN
    DELETE FROM Producto
    WHERE Id = @Id;
END