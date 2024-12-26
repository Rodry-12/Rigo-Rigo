using Microsoft.Extensions.Configuration;
using RigoRigo.AccesoDatos.Exceptions;
using RigoRigo.AccesoDatos.Extensions;
using RigoRigo.Infrastructure.Repositories.Interfaces;
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
    public class PedidoRepository : IPedidoRepository
    {
        private readonly string _connectionString;

        public PedidoRepository(Configuracion configuration)
        {
            _connectionString = configuration.CadenaConexion();
        }

        private SqlConnection Conexion()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<int> InsertarPedido(Pedido pedido)
        {
            int idPedido = 0;
            try
            {
                using (var sqlConexion = Conexion())
                {
                    using (var comm = new SqlCommand("[dbo].[Sp_InsertarPedido]", sqlConexion))
                    {
                        comm.CommandType = CommandType.StoredProcedure;

                        // Añadir parámetros
                        comm.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
                        comm.Parameters.AddWithValue("@CedulaCliente", pedido.CedulaCliente);
                        comm.Parameters.AddWithValue("@DireccionEntrega", pedido.DireccionEntrega);
                        comm.Parameters.AddWithValue("@Total", pedido.Total);
                        comm.Parameters["@Id"].Value = 0;

                        await sqlConexion.OpenAsync();
                        await comm.ExecuteNonQueryAsync();

                        // Obtener el valor del parámetro de salida
                        idPedido = Convert.ToInt32(comm.Parameters["@Id"].Value);
                    }
                }

                return idPedido;
            }
            catch (SqlException ex)
            {
                throw new RigoRigoException("Hubo un problema al insertar el pedido.", ex);
            }
            catch (Exception ex)
            {
                throw new RigoRigoException("Un error inesperado ocurrió.", ex);
            }
        }

        public async Task<bool> InsertarDetallePedido(Pedido pedido)
        {

            try
            {
                using (var sqlConexion = Conexion())
                {
                    await sqlConexion.OpenAsync();

                    foreach (var detalle in pedido.Detalles)
                    {
                        using (var command = new SqlCommand("[dbo].[Sp_InsertarDetallePedido]", sqlConexion))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            // Añadir parámetros
                            command.Parameters.AddWithValue("@PedidoId", pedido.Id);
                            command.Parameters.AddWithValue("@ProductoId", detalle.ProductoId);
                            command.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);

                            // Ejecutar la consulta sin verificación explícita del resultado
                            await command.ExecuteNonQueryAsync(); // Si falla, lanzará una excepción
                        }
                    }
                }

                return true;
            }
            catch (SqlException ex)
            {
                throw new RigoRigoException("Hubo un problema al insertar el detalle del pedido.", ex);
            }
            catch (Exception ex)
            {
                throw new RigoRigoException("Un error inesperado ocurrió.", ex);
            }
        }

    }
}
