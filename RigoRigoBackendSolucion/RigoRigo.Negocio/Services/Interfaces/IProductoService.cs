using RigoRigo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RigoRigo.Negocio.Services.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> ObtenerProductos();
    }
}
