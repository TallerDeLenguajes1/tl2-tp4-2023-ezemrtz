namespace Web_Api;

public class Cadeteria{
    private string nombre;
    private int telefono;
    private List<Cadete> listadoCadetes;
    private List<Pedido> listadoPedidos;
    private static Cadeteria cadeteriaSingleton;

    public string Nombre { get => nombre; set => nombre = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value;}
    public List<Pedido> ListadoPedidos { get => listadoPedidos;}
    
    /* public Cadeteria()
    {
        _pedidos = new List<Pedido>();
        _nombre = "Cadeteria la prueba";
        _pedidos.Add(new Pedido{
            Nro = 1,
            Observacion = " Es el primer pedido"
        });
        _pedidos.Add(new Pedido{
            Nro = 2,
            Observacion = " Es el segundo pedido"
        });
        _pedidos.Add(new Pedido{
            Nro = 3,
            Observacion = " Es el tercer pedido"
        });
    } */
    public Cadeteria(string nombre, int telefono){
        Nombre = nombre;
        Telefono = telefono;
        listadoPedidos = new List<Pedido>();
    }
    public static Cadeteria GetCadeteria()
    {
        if (cadeteriaSingleton==null)
        {
            cadeteriaSingleton = new Cadeteria();
        }
        return cadeteriaSingleton;
    }

    public void DarAltaPedido(string obs, string nomCliente, string direccion, int telefono, string referencia){
        Pedido miPedido = new Pedido(listadoPedidos.Count+1, obs, Estados.pendiente, nomCliente, direccion, telefono, referencia);
        listadoPedidos.Add(miPedido);
    }
    
    public void AsignarCadeteAPedido(int idCadete, int numPedido){
        Pedido pedido = listadoPedidos.Find(ped => ped.Numero == numPedido);
        if(pedido != null){
            pedido.IdCadete = idCadete;
        }
    }

    public void ReasignarPedido(int numPedido, int idCadeteNuevo){
        Pedido pedido = listadoPedidos.Find(ped => ped.Numero == numPedido);
        if(pedido != null){
            pedido.IdCadete = idCadeteNuevo;
        }

        
    }

    public void CambiarEstadoPedido(int numPedido, int estado){
        Pedido pedido;
        Estados nuevoEstado = Estados.entregado;
        if(estado == 2) nuevoEstado = Estados.cancelado;
        foreach (var item in listadoPedidos){
            if(item.Numero == numPedido){
                item.CambiarEstado(nuevoEstado);
            }
        }
    }

    public float JornalACobrar(int id){
        float jornal = 0;
        foreach (var pedido in listadoPedidos)
        {
            if(pedido.IdCadete == id && pedido.Estado == Estados.entregado){
                jornal += 500;
            }
        }
        return jornal;
    }

public int CantidadPedidos(){
        int cant = 0;
        foreach (var item in listadoPedidos)
        {
            cant++;
        }
        return cant;
    }

    public int CantidadPedidosEnviados(){
        int cant = 0;
        foreach (var item in listadoPedidos)
        {
            if(item.Estado == Estados.entregado){
                cant++;
            }
        }
        return cant;

    }
    
}