using Microsoft.AspNetCore.Mvc;

namespace Web_Api.Controllers; //Namespace controller vinculado al namespace de las clases

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{
    private Cadeteria cadeteria;

    private readonly ILogger<CadeteriaController> _logger;

    public CadeteriaController(ILogger<CadeteriaController> logger)
    {
        _logger = logger;
        cadeteria = Cadeteria.GetCadeteria();//para poder usar el patron de diseño singleton de la cadeteria para tener persistencia de datos
    }

    [HttpGet] 
    public ActionResult<string> GetNombreCadeteria()
    {
        return Ok(cadeteria.Nombre);
    }

    [HttpGet] //muestra datos
    [Route("Pedidos")]
    public ActionResult<IEnumerable<Pedido>> GetPedidos()
    {
        var pedidos = cadeteria.GetPedidos();
        return Ok(pedidos);
    }

    [HttpPost("AddPedido")] //agrega datos
    public ActionResult<Pedido> AddPedido(Pedido pedido)
    {
        var nuevoPedido = cadeteria.AddPedido(pedido);
        return Ok(nuevoPedido);
    }

 [HttpPut("UpdatePedido")] //modifica datos
    public ActionResult<Pedido> UpdatePedido(Pedido pedido)
    {
        var updPed = cadeteria.UpdPedido(pedido);
        return Ok(updPed);
    }
   
}