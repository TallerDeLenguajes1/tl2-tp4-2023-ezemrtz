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
    
    public Cadeteria()
    {
        listadoPedidos = new List<Pedido>();
        nombre = "Cadeteria la prueba";
        listadoPedidos.Add(new Pedido(1,"primer pedido", "Manuel", "Av Roca 1000", 123456, ""));
        listadoPedidos.Add(new Pedido(2,"segundo pedido", "Martin", "Av Roca 2000", 163456, "sdf"));
        listadoPedidos.Add(new Pedido(3,"tercer pedido", "Marcos", "Av Roca 3000", 24353256, "gdgh"));
        listadoCadetes = new List<Cadete>();
        listadoCadetes.Add(new Cadete(0, "Ezequiel", "Av. Roca 3293", 38178237));
        listadoCadetes.Add(new Cadete(1, "Geronimo", "Av. Colon 2100", 38134437));
        listadoCadetes.Add(new Cadete(2, "Luca", "Av. Indep 1203", 38160237));
    } 
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

    public Pedido DarAltaPedido(string obs, string nomCliente, string direccion, int telefono, string referencia){
        Pedido miPedido = new Pedido(listadoPedidos.Count+1, obs, nomCliente, direccion, telefono, referencia);
        listadoPedidos.Add(miPedido);
        return miPedido;
    }
    
    public Pedido AsignarPedido(int idCadete, int numPedido){
        Pedido pedido = listadoPedidos.Find(ped => ped.Numero == numPedido);
        if(pedido != null){
            pedido.IdCadete = idCadete;
        }
        return pedido;
    }

    public Pedido ReasignarPedido(int numPedido, int idCadeteNuevo){
        Pedido pedido = listadoPedidos.Find(ped => ped.Numero == numPedido);
        if(pedido != null){
            pedido.IdCadete = idCadeteNuevo;
        }
        return pedido;

        
    }

    public Pedido CambiarEstadoPedido(int numPedido, int estado){
        Estados nuevoEstado = (Estados) estado;
        Pedido pedido = listadoPedidos.Find(ped => ped.Numero == numPedido);
        pedido.CambiarEstado(nuevoEstado);
        return pedido;
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

    public List<Pedido> GetPedidos(){
        return listadoPedidos;
    }

    public Pedido AgregarPedido(Pedido pedido){
        listadoPedidos.Add(pedido);
        return pedido;
    }
    
}