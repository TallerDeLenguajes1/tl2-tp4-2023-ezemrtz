using System.Text.Json;
using System.Text.Json.Serialization;
namespace Web_Api;

public class AccesoADatosPedidos{
    private string path = "pedidos.json";
    public List<Pedido> Obtener(){
        List<Pedido> pedidos = new List<Pedido>();
        if(File.Exists(path)){
            string textPedidos = File.ReadAllText(path);
            pedidos = JsonSerializer.Deserialize<List<Pedido>>(textPedidos);
        }
        return pedidos;
    }

    public void Guardar(List<Pedido> pedidos){
        if(File.Exists(path)){
            string textPedidos = JsonSerializer.Serialize(pedidos);
            File.WriteAllText(path, textPedidos);
        }
    }
}