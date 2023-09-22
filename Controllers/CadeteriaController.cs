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

    [HttpGet] 
    [Route("Cadetes")]
    public ActionResult<IEnumerable<Pedido>> GetCadetes()
    {
        var cadetes = cadeteria.ListadoCadetes;
        return Ok(cadetes);
    }

    [HttpPost("AgregarPedido")] //agrega datos
    public ActionResult<Pedido> AgregarPedido(string obs, string nomCliente, string direccion, int telefono, string referencia)
    {
        
        var nuevoPedido = cadeteria.DarAltaPedido(obs, nomCliente, direccion,  telefono, referencia);
        return Ok(nuevoPedido);
    }

    [HttpPut("AsignarPedido")] //modifica datos
    public ActionResult<Pedido> AsignarPedido(int idPedido, int idCadete)
    {
        var updPed = cadeteria.AsignarPedido(idCadete, idPedido);
        return Ok(updPed);
    }
   
    [HttpPut("CambiarEstadoPedido")] //modifica datos
    public ActionResult<Pedido> CambiarEstadoPedido(int idPedido, int estado)
    {
        var updPed = cadeteria.CambiarEstadoPedido(idPedido, estado);
        return Ok(updPed);
    }

    [HttpPut("CambiarCadetePedido")] //modifica datos
    public ActionResult<Pedido> CambiarCadetePedido(int idPedido, int idNuevoCadete)
    {
        var updPed = cadeteria.ReasignarPedido(idPedido, idNuevoCadete);
        return Ok(updPed);
    }
}