namespace GSMApp.Models
{
    // Archivo: Producto.cs

    using System;

    // Modelo para representar el objeto Producto
    public class Producto
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public double Precio { get; set; }
        public double Existencia { get; set; }
        public int TipoProducto_Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaEliminado { get; set; }


    }

}
