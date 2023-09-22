namespace Web_Api;

public class Cliente{
    private string nombre;
    private string direccion;
    private int telefono;
    private string referencia;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public string Referencia { get => referencia; set => referencia = value; }

    public Cliente(string nombre, string direccion, int telefono, string referencia){
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        Referencia = referencia;
    }
}