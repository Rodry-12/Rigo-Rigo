using AutoMapper;
using RigoRigo.AccesoDatos.Exceptions;
using RigoRigo.Infrastructure.Repositories.Interfaces;
using RigoRigo.Model;
using RigoRigo.Model.Dto;
using RigoRigo.Model.Entidades;
using RigoRigo.Negocio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RigoRigo.Negocio.Services.Implementations
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<Producto>> ObtenerProductos()
        {
            try
            {
                return await _productoRepository.ObtenerProductosAsync();
            }
            catch (Exception ex)
            {
                throw new RigoRigoException("Hubo un problema al obtener los productos.", ex);
            }
        }
    }
}
