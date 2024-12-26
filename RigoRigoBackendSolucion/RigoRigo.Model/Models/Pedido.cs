using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RigoRigo.Model.Entidades
{
    public class Pedido
    {
        private int _id;
        private string _cedulaCliente;
        private string _direccionEntrega;
        private List<DetallePedido> _detalles;
        private decimal _total;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string CedulaCliente
        {
            get { return _cedulaCliente; }
            set { _cedulaCliente = value; }
        }

        public string DireccionEntrega
        {
            get { return _direccionEntrega; }
            set { _direccionEntrega = value; }
        }

        public List<DetallePedido> Detalles
        {
            get { return _detalles; }
            set { _detalles = value; }
        }

        public decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }
    }
}
