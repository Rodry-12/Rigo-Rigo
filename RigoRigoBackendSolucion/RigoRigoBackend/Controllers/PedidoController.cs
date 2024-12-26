using Microsoft.AspNetCore.Mvc;
using RigoRigo.Model.Dto;
using RigoRigo.Negocio.Services.Interfaces;

namespace RigoRigoBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost("CrearPedido")]
        public IActionResult CrearPedido([FromBody] PedidoDto nuevoPedido)
        {
            var pedidoId = _pedidoService.CrearPedido(nuevoPedido);
            return CreatedAtAction(nameof(CrearPedido), new { id = pedidoId }, nuevoPedido);
        }

    }
}