using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using LitJson;

public class EnergyBar : MonoBehaviour
{
	public Scrollbar energyBar;
    private JsonData gameData;
    public float Energy = 100;
    private int tiempo=0;

    //private JSONLoader jsonLoader;
    
    private JSONLoaderJuego0 jsonLoader;

    private void Start()
    {

        if (!File.Exists(Application.dataPath + "/Gamedata.json"))
        {
            Energy = 100;
        }
        else
        {
            gameData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Gamedata.json"));
            Energy = (float)((double.Parse(gameData[2].ToString()))); 
        }
    }

    void Awake()
    {
        jsonLoader = GameObject.FindObjectOfType<JSONLoaderJuego0>();
    }

    void Update()
    {
        tiempo ++;
        
        if (tiempo % 300 == 0)
        {
            print(tiempo);
            Hungry(0.08e-2f);
        }
    }

    public void Hungry(float value)
	{
        if(Energy>0)
        {
            Energy -= value;
            
        }
        energyBar.size = Energy / 100f;
    }

    public void Comer(int indice)
    {
        Energy += (float)jsonLoader.darPorcentajeEnergiaAlimento(indice);
        energyBar.size = Energy / 100f;
    }

}

