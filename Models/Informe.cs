namespace Web_Api;

public class Informe{
    private List<InformeCadete> listaInfomesCadetes;
    private float montoTotal;
    private float promedioEnvios;

    public Informe(List<InformeCadete> listaInfomesCad, float total, float prom){
        this.listaInfomesCadetes = listaInfomesCad;
        this.montoTotal = total;
        this.promedioEnvios = prom;
    }

    public List<InformeCadete> ListaInfomesCadetes { get => listaInfomesCadetes;}
    public float MontoTotal { get => montoTotal;}
    public float PromedioEnvios { get => promedioEnvios;}
}

public class InformeCadete{
    private int cantidadPedidos;
    private int cantidadPedidosEnviados;
    private float montoGanado;

    public InformeCadete(int cantPed, int CantPedEnv, float jornal){
        this.cantidadPedidos = cantPed;
        this.cantidadPedidosEnviados = CantPedEnv;
        this.montoGanado = jornal;
    }

    public int CantidadPedidos { get => cantidadPedidos;}
    public int CantidadPedidosEnviados { get => cantidadPedidosEnviados;}
    public float MontoGanado { get => montoGanado;}
}