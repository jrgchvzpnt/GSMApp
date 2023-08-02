namespace GSMApp.Controllers
{
    using GSMApp.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using Microsoft.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
   using System.Data;


    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly string _connectionString;

        public ProductosController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private DataTable EjecutarSP(string nombreSP, SqlParameter[] parametros)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(nombreSP, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                    {
                        command.Parameters.AddRange(parametros);
                    }

                    DataTable dataTable = new DataTable();
                    connection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                    }

                    return dataTable;
                }
            }
        }

        // GET api/productos/lista
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> ObtenerProductos()
        {
            DataTable dataTable = EjecutarSP("Productos_Leer", null);

            List<Producto> productos = new List<Producto>();
            foreach (DataRow row in dataTable.Rows)
            {
                productos.Add(new Producto
                {
                    Id = Convert.ToInt32(row["Id"]),
                    NombreProducto = row["NombreProducto"].ToString(),
                    DescripcionProducto = row["DescripcionProducto"].ToString(),
                    Precio = Convert.ToDouble(row["Precio"]),
                    FechaRegistro = Convert.ToDateTime(row["FechaRegistro"]),
                    Existencia = Convert.ToDouble(row["Existencia"]),
                    TipoProducto_Id = Convert.ToInt32(row["TipoProducto_Id"])
                });
            }

            return Ok(productos);
        }

        // GET api/productos/5
        [HttpGet("{id}")]
        public ActionResult<Producto> ObtenerProductoPorId(int id)
        {
            SqlParameter[] parametros = { new SqlParameter("@Id", id) };

            DataTable dataTable = EjecutarSP("Productos_LeerPorId", parametros);

            if (dataTable.Rows.Count == 0)
                return NotFound();

            DataRow row = dataTable.Rows[0];
            Producto producto = new Producto
            {
                Id = Convert.ToInt32(row["Id"]),
                NombreProducto = row["NombreProducto"].ToString(),
                DescripcionProducto = row["DescripcionProducto"].ToString(),
                Precio = Convert.ToDouble(row["Precio"]),
                FechaRegistro = Convert.ToDateTime(row["FechaRegistro"]),
                Existencia = Convert.ToDouble(row["Existencia"]),
                TipoProducto_Id = Convert.ToInt32(row["TipoProducto_Id"])
            };

            return Ok(producto);
        }

        // POST api/productos
        [HttpPost]
        public IActionResult CrearProducto([FromBody] Producto producto)
        {
            SqlParameter[] parametros = {
            new SqlParameter("@NombreProducto", producto.NombreProducto),
            new SqlParameter("@DescripcionProducto", producto.DescripcionProducto),
            new SqlParameter("@Precio", producto.Precio),
            new SqlParameter("@Existencia", producto.Existencia),
            new SqlParameter("@TipoProducto_Id", producto.TipoProducto_Id),
            new SqlParameter("@FechaRegistro", SqlDbType.DateTime) { Value = producto.FechaRegistro },
            new SqlParameter("@FechaEliminado", SqlDbType.DateTime) { Value = producto.FechaEliminado  }
        };

        

            EjecutarSP("Productos_Crear", parametros);

            return CreatedAtAction(nameof(ObtenerProductoPorId), new { id = producto.Id }, producto);
        }

        // PUT api/productos/5
        [HttpPut("{id}")]
        public IActionResult ActualizarProducto(int id, [FromBody] Producto productoActualizado)
        {
            SqlParameter[] parametros = {
            new SqlParameter("@Id", id),
            new SqlParameter("@NombreProducto", productoActualizado.NombreProducto),
            new SqlParameter("@DescripcionProducto", productoActualizado.DescripcionProducto),
            new SqlParameter("@Precio", productoActualizado.Precio),
            new SqlParameter("@Existencia", productoActualizado.Existencia),
            new SqlParameter("@TipoProducto_Id", productoActualizado.TipoProducto_Id)
        };

            EjecutarSP("Productos_Actualizar", parametros);

            return NoContent();
        }

        // DELETE api/productos/5
        [HttpDelete("{id}")]
        public IActionResult EliminarProducto(int id)
        {
            SqlParameter[] parametros = { new SqlParameter("@Id", id) };

            EjecutarSP("Productos_Eliminar", parametros);

            return NoContent();
        }
    }




}
