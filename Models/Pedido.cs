// See https://aka.ms/new-console-template for more information
namespace Web_Api;

public enum Estados{
    pendiente,
    entregado,
    cancelado
}
public class Pedido{
    private int numero;
    private string observacion;
    private Cliente client;
    private int idCadete;
    private Estados estado;

    public Pedido(int numero, string observacion, string nombre, string direccion, int telefono, string referencia){
        Client = new Cliente(nombre, direccion, telefono, referencia);
        Numero = numero;
        Observacion = observacion;
        Estado = Estados.pendiente;
    }

    public int Numero { get => numero; set => numero = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    public Cliente Client { get => client; set => client = value; }
    public Estados Estado { get => estado; set => estado = value; }
    public int IdCadete { get => idCadete; set => idCadete = value; }

    public void VerDireccionCliente(){
        Console.WriteLine("Direccion: {0}", this.Client.Direccion);
        Console.WriteLine("Referencias: {0}", this.Client.Referencia);
    }

    public void VerDatosCliente(){
        Console.WriteLine("Nombre: {0}", Client.Nombre);
        Console.WriteLine("Telefono: {0}", Client.Telefono);
    }

    public void CambiarEstado(Estados estado){
        if(this.estado == Estados.pendiente){
            this.estado = estado;
        }else{
            Console.WriteLine("No es valido el cambio de estado");
        }
    }

    public void MostrarInfo(){
        Console.WriteLine("==================");
        Console.WriteLine("Numero pedido: {0}", numero);
        Console.WriteLine("Observacion: {0}", observacion);
        Console.WriteLine("Estado: {0}", estado);
        Console.WriteLine("------ Cliente ------");
        VerDatosCliente();
        Console.WriteLine("==================");
    }
}