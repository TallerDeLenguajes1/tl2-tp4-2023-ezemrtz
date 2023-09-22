namespace Web_Api;

public class Cadete{
    private int id;
    private string nombre;
    private string direccion;
    private int telefono;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }

    public Cadete(int id, string nombre, string direccion, int telefono){
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
    }

    public void MostrarInfo(){
        Console.WriteLine("==================");
        Console.WriteLine("ID: {0}", id);
        Console.WriteLine("Nombre: {0}", nombre);
        Console.WriteLine("Direccion: {0}", direccion);
        Console.WriteLine("==================");
    }
}