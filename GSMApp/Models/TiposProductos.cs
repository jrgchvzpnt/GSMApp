namespace GSMApp.Models
{
    public class TiposProductos
    {
        public int Id { get; set; }
        public string NombreTipoProducto { get; set; }
        public string DescripcionTipoProducto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaEliminado { get; set; }

    }
}
