using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using UnityEditor;

public class JSONWriter : MonoBehaviour
{
    public GameData infoPartida;
    JsonData jsonCreado;

    
    // Start is called before the first frame update
    void Start()
    {
        if(!File.Exists(Application.dataPath + "/Gamedata.json"))
        {
            infoPartida = new GameData(1, new int[] { 1,3,5,0,0,0,0,0 }, 100, 6, "0", Time.time, 0.0, 0.0, new string[] { "Arroz", "Huevos", "Agua", "Arroz con leche", "Chocolate", "Dulces", "Granos", "Pan" });
            jsonCreado = JsonMapper.ToJson(infoPartida);
            File.WriteAllText(Application.dataPath + "/Gamedata.json", jsonCreado.ToString());
            //AssetDatabase.SaveAssets();
            //AssetDatabase.Refresh();
        }        
    }

    public void reescribirJSON(int dia, int[] lista, int porcentajeBarra, int hora, string tomoRegaloCarta, double inicio, double ultimoSegundo, double segundoActual, string[] nombresAlimentos)
    {
        infoPartida = new GameData(dia, lista, porcentajeBarra, hora, tomoRegaloCarta, inicio, ultimoSegundo, segundoActual, nombresAlimentos);

        jsonCreado = JsonMapper.ToJson(infoPartida);
        File.WriteAllText(Application.dataPath + "/Gamedata.json", jsonCreado.ToString());
       // AssetDatabase.SaveAssets();
        //AssetDatabase.Refresh();
    }  


}

public class GameData
{
    public int diaActual;
    public int[] cantidadAlimentos;
    public int porcentajeEnergia;
    public int hora;
    public string tomoRegaloCarta;
    public double inicio ;
    public double ultimoSegundo ;
    public double segundoActual ;
    public string[] nombresAlimentos;

    public GameData(int dia, int[] cantidad, int porcentaje, int hora, string tomoRegaloCarta, double inicio, double ultimoSegundo, double segundoActual, string[] nombresAlimentos)
    {
        this.diaActual = dia;
        this.cantidadAlimentos = cantidad;
        this.porcentajeEnergia= porcentaje;
        this.hora = hora;
        
        this.tomoRegaloCarta = tomoRegaloCarta;
        this.inicio = inicio;
        this.ultimoSegundo = ultimoSegundo;
        this.segundoActual = segundoActual;
        this.nombresAlimentos = nombresAlimentos;

    }
}
