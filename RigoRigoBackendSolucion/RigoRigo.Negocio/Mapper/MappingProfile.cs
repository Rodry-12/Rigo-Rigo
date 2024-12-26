using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RigoRigo.Model.Dto;
using RigoRigo.Model.Entidades;

namespace RigoRigo.Negocio.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Mapea PedidoDto a Pedido
            CreateMap<PedidoDto, Pedido>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)) 
                .ForMember(dest => dest.CedulaCliente, opt => opt.MapFrom(src => src.CedulaCliente)) 
                .ForMember(dest => dest.DireccionEntrega, opt => opt.MapFrom(src => src.DireccionEntrega))
                .ForMember(dest => dest.Detalles, opt => opt.MapFrom(src => src.Productos));

            // Mapea ProductoDto a DetallePedido
            CreateMap<ProductoDto, DetallePedido>()
                .ForMember(dest => dest.PedidoId, opt => opt.MapFrom(src => 0)) 
                .ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.Id)) 
                .ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.Cantidad));
        }
    }
}
