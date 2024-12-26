using Microsoft.Extensions.Configuration;
using RigoRigo.AccesoDatos.Exceptions;
using RigoRigo.AccesoDatos.Extensions;
using RigoRigo.Infrastructure.Repositories.Interfaces;
using RigoRigo.Model;
using RigoRigo.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RigoRigo.Infrastructure.Repositories.Implementations
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly string _connectionString;

        public ProductoRepository(Configuracion configuration)
        {
            _connectionString = configuration.CadenaConexion();
        }

        public async Task<IEnumerable<Producto>> ObtenerProductosAsync()
        {
            try
            {
                var productos = new List<Producto>();

                using (SqlConnection connection = Conexion())
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("Sp_ObtenerProductos", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                productos.Add(new Producto
                                {
                                    Id = reader.GetInt32(0),
                                    Nombre = reader.GetString(1),
                                    Precio = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }

                return productos;
            }
            catch (SqlException ex)
            {
                throw new RigoRigoException("Hubo un error al obtener los productos.", ex);
            }
            catch (Exception ex)
            {
                throw new RigoRigoException("Un error inesperado ocurrió.", ex);
            }
        }

        private SqlConnection Conexion()
        {
            return new SqlConnection(_connectionString);
        }

    }
}
