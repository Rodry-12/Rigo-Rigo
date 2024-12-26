using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RigoRigo.Model.Dto
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public string CedulaCliente { get; set; }
        public string DireccionEntrega { get; set; }
        public decimal Total { get; set; }
        public List<ProductoDto> Productos { get; set; }

    }
}
