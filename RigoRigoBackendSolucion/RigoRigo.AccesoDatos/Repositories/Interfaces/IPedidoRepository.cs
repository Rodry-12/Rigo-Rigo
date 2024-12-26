using RigoRigo.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RigoRigo.Infrastructure.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        Task<int> InsertarPedido(Pedido pedido);
        Task<bool> InsertarDetallePedido(Pedido pedido);
    }
}
