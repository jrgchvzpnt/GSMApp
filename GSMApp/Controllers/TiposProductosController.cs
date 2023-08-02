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
    public class TiposProductosController : ControllerBase
    {
        private readonly string _connectionString;

        public TiposProductosController(IConfiguration configuration)
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

        // GET api/TiposProductos
        [HttpGet]
        public ActionResult<IEnumerable<TiposProductos>> ObtenerTipoProductos()
        {
            DataTable dataTable = EjecutarSP("TipoProductos_Leer", null);

            List<TiposProductos> TiposProductos = new List<TiposProductos>();
            foreach (DataRow row in dataTable.Rows)
            {
                TiposProductos.Add(new TiposProductos
                {
                    Id = Convert.ToInt32(row["Id"]),
                    NombreTipoProducto = row["nombreTipoProducto"].ToString(),
                    DescripcionTipoProducto = row["descripcionTipoProducto"].ToString(),
                    FechaRegistro = Convert.ToDateTime(row["FechaRegistro"]),
                   


                });
            }

            return Ok(TiposProductos);
        }


    }
}
