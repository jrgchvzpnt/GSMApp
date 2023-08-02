CREATE PROCEDURE Productos_LeerPorId
    @Id INT
AS
BEGIN
    SELECT *
    FROM Producto
    WHERE Id = @Id;
END