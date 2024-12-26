using AutoMapper;
using RigoRigo.AccesoDatos.Exceptions;
using RigoRigo.Infrastructure.Repositories.Interfaces;
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
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidoService(IPedidoRepository pedidoRepositorio, IMapper mapper)
        {
            _pedidoRepository = pedidoRepositorio;
            _mapper = mapper;
        }

        public async Task<bool> CrearPedido(PedidoDto pedidoDto)
        {
            Pedido pedido = _mapper.Map<Pedido>(pedidoDto);

            try
            {
                pedido.Id = await _pedidoRepository.InsertarPedido(pedido);

                if (pedido.Id > 0)
                {
                    bool detallesInsertados = await _pedidoRepository.InsertarDetallePedido(pedido);

                    return detallesInsertados;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new RigoRigoException("Hubo un problema al crear el pedido.", ex);
            }
        }
    }
}
