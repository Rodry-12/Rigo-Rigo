using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RigoRigo.Model.Entidades
{
    public class DetallePedido
    {
        private int _pedidoId;
        private int _productoId;
        private int _cantidad;

        public int PedidoId
        {
            get { return _pedidoId; }
            set { _pedidoId = value; }
        }

        public int ProductoId
        {
            get { return _productoId; }
            set { _productoId = value; }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }
    }
}
