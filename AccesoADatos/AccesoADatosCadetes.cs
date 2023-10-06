using System.Text.Json;
using System.Text.Json.Serialization;
namespace Web_Api;

public class AccesoADatosCadetes{
    private string path = "cadetes.json";
    public List<Cadete> Obtener(){
        List<Cadete> cadetes = new List<Cadete>();
        if(File.Exists(path)){
            string textCadetes = File.ReadAllText(path);
            cadetes = JsonSerializer.Deserialize<List<Cadete>>(textCadetes);
        }
        return cadetes;
    }
}