using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeDayFunction : MonoBehaviour
{
    public float inicio;
    public int hora;
    public int dia;
    public double ultimoSegundo;
    public TextMeshPro texto;
    public SpriteRenderer fondoEscena;
    public float red;
    public float green;
    public float blue;

    public float red1;
    public float green1;
    public float blue1;

    public double segundoActual;
    public JsonData jsonData;

    public SpriteRenderer ninaCalle;
    public SpriteRenderer ninoCalle;

    public SpriteRenderer ninaCoorp;
    public SpriteRenderer ninoCoorp;
    public SpriteRenderer calvoGrandeCoorp;
    public SpriteRenderer calvoPequenoCoorp;
    public SpriteRenderer nino2Coorp;
    public SpriteRenderer balon;



    // Start is called before the first frame update
    void Start()
    {
        if(!File.Exists(Application.dataPath + "/Gamedata.json"))
        {
            dia = 1;
            red = 1.0f;
            green = 1.0f;
            blue = 1.0f;

            red1 = 1.0f;
            green1 = 1.0f;
            blue1 = 1.0f;

            inicio = Time.time;
            hora = 6;
            ultimoSegundo = 0.0;
            segundoActual = 0.0;
        }
        else
        {
            
            jsonData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Gamedata.json"));
            dia = (int)jsonData[0];
            hora = (int)jsonData[3];
            inicio = (float)((double.Parse(jsonData[5].ToString())));        
            ultimoSegundo = double.Parse(jsonData[6].ToString());
            segundoActual = double.Parse(jsonData[7].ToString());
            if(hora<17)
            {
                red = 1.0f;
                green = 1.0f;
                blue = 1.0f;
            }
            else if(hora==17 || hora == 18)
            {
                red = 0.8f;
                green = 0.8f;
                blue = 0.8f;
                
            }
            else if(hora==19)
            {
                red = 0.7f;
                green = 0.7f;
                blue = 0.7f;
                
            }
            else if (hora == 20)
            {
                red = 0.6f;
                green = 0.6f;
                blue = 0.6f;
                
            }
            else if (hora == 21)
            {
                red = 0.5f;
                green = 0.5f;
                blue = 0.5f;
            }
            else if (hora == 22)
            {
                red = 0.4f;
                green = 0.4f;
                blue = 0.4f;
                
            }
            else if (hora == 23)
            {
                red = 0.3f;
                green = 0.3f;
                blue = 0.3f;
                
            }
            else if (hora == 24)
            {
                red = 0.2f;
                green = 0.2f;
                blue = 0.2f;
            }


        }
        
    }

    public void oscurecer(){
        
        red = 0.2f;
        green = 0.2f;
        blue = 0.2f;
            
    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject player = GameObject.Find("Personaje");
        
            if (hora < 25)
            {
                float t = Time.time - inicio;
                string minutos = ((int)t / 60).ToString();
                string segundos = (t % 60).ToString("f1");
            //print(minutos + ":"+segundos);            
            
            Color color = new Color(red, green, blue, 1)
            {
                
                r = red,
                g = green,
                b = blue,
                a = 1
            };
            fondoEscena.color = color;

            if(ninaCalle!=null)
            {
                ninaCalle.color = color;
            }
            if (ninoCalle != null)
            {
                ninoCalle.color = color;
            }
            if (ninaCoorp != null)
            {
                ninaCoorp.color = color;
            }
            if (ninoCoorp != null)
            {
                ninoCoorp.color = color;
            }
            if (calvoGrandeCoorp != null)
            {
                calvoGrandeCoorp.color = color;
            }
            if (calvoPequenoCoorp != null)
            {
                calvoPequenoCoorp.color = color;
            }
            if (nino2Coorp != null)
            {
                nino2Coorp.color = color;
            }
            if(balon!= null)
            {
                balon.color = color;
            }

             segundoActual = double.Parse(segundos);
            
            if (segundoActual != 0.0 && segundoActual % 12.50 == 0)
                {

                    double valorAbsoluto = Math.Abs(ultimoSegundo - segundoActual);

                    if (valorAbsoluto != 0) 
                    {
                    if (hora < 17)
                    {
                        hora = hora + 1;

                        red = 1.0f;
                        green = 1.0f;
                        blue = 1.0f;

                        color = new Color(red, green, blue, 1)
                        {

                            r = red,
                            g = green,
                            b = blue,
                            a = 1
                        };
                        fondoEscena.color = color;

                        if (ninaCalle != null)
                        {
                            ninaCalle.color = color;
                        }
                        if (ninoCalle != null)
                        {
                            ninoCalle.color = color;
                        }
                        if (ninaCoorp != null)
                        {
                            ninaCoorp.color = color;
                        }
                        if (ninoCoorp != null)
                        {
                            ninoCoorp.color = color;
                        }
                        if (calvoGrandeCoorp != null)
                        {
                            calvoGrandeCoorp.color = color;
                        }
                        if (calvoPequenoCoorp != null)
                        {
                            calvoPequenoCoorp.color = color;
                        }
                        if (nino2Coorp != null)
                        {
                            nino2Coorp.color = color;
                        }
                        if(balon!= null)
                        {
                            balon.color = color;
                        }
                    }
                    else if (hora == 17 || hora == 18)
                    {
                        hora = hora + 1;

                        red = 0.8f;
                        green = 0.8f;
                        blue = 0.8f;

                        color = new Color(red, green, blue, 1)
                        {

                            r = red,
                            g = green,
                            b = blue,
                            a = 1
                        };
                        fondoEscena.color = color;

                        if (ninaCalle != null)
                        {
                            ninaCalle.color = color;
                        }
                        if (ninoCalle != null)
                        {
                            ninoCalle.color = color;
                        }
                        if (ninaCoorp != null)
                        {
                            ninaCoorp.color = color;
                        }
                        if (ninoCoorp != null)
                        {
                            ninoCoorp.color = color;
                        }
                        if (calvoGrandeCoorp != null)
                        {
                            calvoGrandeCoorp.color = color;
                        }
                        if (calvoPequenoCoorp != null)
                        {
                            calvoPequenoCoorp.color = color;
                        }
                        if (nino2Coorp != null)
                        {
                            nino2Coorp.color = color;
                        }
                        if (balon != null)
                        {
                            balon.color = color;
                        }


                    }
                    else if (hora == 19)
                    {
                        hora = hora + 1;

                        red = 0.7f;
                        green = 0.7f;
                        blue = 0.7f;

                        color = new Color(red, green, blue, 1)
                        {

                            r = red,
                            g = green,
                            b = blue,
                            a = 1
                        };
                        fondoEscena.color = color;

                        if (ninaCalle != null)
                        {
                            ninaCalle.color = color;
                        }
                        if (ninoCalle != null)
                        {
                            ninoCalle.color = color;
                        }
                        if (ninaCoorp != null)
                        {
                            ninaCoorp.color = color;
                        }
                        if (ninoCoorp != null)
                        {
                            ninoCoorp.color = color;
                        }
                        if (calvoGrandeCoorp != null)
                        {
                            calvoGrandeCoorp.color = color;
                        }
                        if (calvoPequenoCoorp != null)
                        {
                            calvoPequenoCoorp.color = color;
                        }
                        if (nino2Coorp != null)
                        {
                            nino2Coorp.color = color;
                        }
                        if (balon != null)
                        {
                            balon.color = color;
                        }

                    }
                    else if (hora == 20)
                    {
                        hora = hora + 1;

                        red = 0.6f;
                        green = 0.6f;
                        blue = 0.6f;

                        color = new Color(red, green, blue, 1)
                        {

                            r = red,
                            g = green,
                            b = blue,
                            a = 1
                        };
                        fondoEscena.color = color;

                        if (ninaCalle != null)
                        {
                            ninaCalle.color = color;
                        }
                        if (ninoCalle != null)
                        {
                            ninoCalle.color = color;
                        }
                        if (ninaCoorp != null)
                        {
                            ninaCoorp.color = color;
                        }
                        if (ninoCoorp != null)
                        {
                            ninoCoorp.color = color;
                        }
                        if (calvoGrandeCoorp != null)
                        {
                            calvoGrandeCoorp.color = color;
                        }
                        if (calvoPequenoCoorp != null)
                        {
                            calvoPequenoCoorp.color = color;
                        }
                        if (nino2Coorp != null)
                        {
                            nino2Coorp.color = color;
                        }
                        if (balon != null)
                        {
                            balon.color = color;
                        }

                    }
                    else if (hora == 21)
                    {
                        hora = hora + 1;

                        red = 0.5f;
                        green = 0.5f;
                        blue = 0.5f;

                        color = new Color(red, green, blue, 1)
                        {

                            r = red,
                            g = green,
                            b = blue,
                            a = 1
                        };
                        fondoEscena.color = color;

                        if (ninaCalle != null)
                        {
                            ninaCalle.color = color;
                        }
                        if (ninoCalle != null)
                        {
                            ninoCalle.color = color;
                        }
                        if (ninaCoorp != null)
                        {
                            ninaCoorp.color = color;
                        }
                        if (ninoCoorp != null)
                        {
                            ninoCoorp.color = color;
                        }
                        if (calvoGrandeCoorp != null)
                        {
                            calvoGrandeCoorp.color = color;
                        }
                        if (calvoPequenoCoorp != null)
                        {
                            calvoPequenoCoorp.color = color;
                        }
                        if (nino2Coorp != null)
                        {
                            nino2Coorp.color = color;
                        }
                        if (balon != null)
                        {
                            balon.color = color;
                        }
                    }
                    else if (hora == 22)
                    {
                        hora = hora + 1;

                        red = 0.4f;
                        green = 0.4f;
                        blue = 0.4f;

                        color = new Color(red, green, blue, 1)
                        {

                            r = red,
                            g = green,
                            b = blue,
                            a = 1
                        };
                        fondoEscena.color = color;

                        if (ninaCalle != null)
                        {
                            ninaCalle.color = color;
                        }
                        if (ninoCalle != null)
                        {
                            ninoCalle.color = color;
                        }
                        if (ninaCoorp != null)
                        {
                            ninaCoorp.color = color;
                        }
                        if (ninoCoorp != null)
                        {
                            ninoCoorp.color = color;
                        }
                        if (calvoGrandeCoorp != null)
                        {
                            calvoGrandeCoorp.color = color;
                        }
                        if (calvoPequenoCoorp != null)
                        {
                            calvoPequenoCoorp.color = color;
                        }
                        if (nino2Coorp != null)
                        {
                            nino2Coorp.color = color;
                        }
                        if (balon != null)
                        {
                            balon.color = color;
                        }

                    }
                    else if (hora == 23)
                    {
                        hora = hora + 1;

                        red = 0.3f;
                        green = 0.3f;
                        blue = 0.3f;

                        color = new Color(red, green, blue, 1)
                        {

                            r = red,
                            g = green,
                            b = blue,
                            a = 1
                        };
                        fondoEscena.color = color;

                        if (ninaCalle != null)
                        {
                            ninaCalle.color = color;
                        }
                        if (ninoCalle != null)
                        {
                            ninoCalle.color = color;
                        }
                        if (ninaCoorp != null)
                        {
                            ninaCoorp.color = color;
                        }
                        if (ninoCoorp != null)
                        {
                            ninoCoorp.color = color;
                        }
                        if (calvoGrandeCoorp != null)
                        {
                            calvoGrandeCoorp.color = color;
                        }
                        if (calvoPequenoCoorp != null)
                        {
                            calvoPequenoCoorp.color = color;
                        }
                        if (nino2Coorp != null)
                        {
                            nino2Coorp.color = color;
                        }
                        if (balon != null)
                        {
                            balon.color = color;
                        }

                    }
                    else if (hora == 24)
                    {
                        red = 0.2f;
                        green = 0.2f;
                        blue = 0.2f;

                        color = new Color(red, green, blue, 1)
                        {

                            r = red,
                            g = green,
                            b = blue,
                            a = 1
                        };
                        fondoEscena.color = color;

                        if (ninaCalle != null)
                        {
                            ninaCalle.color = color;
                        }
                        if (ninoCalle != null)
                        {
                            ninoCalle.color = color;
                        }
                        if (ninaCoorp != null)
                        {
                            ninaCoorp.color = color;
                        }
                        if (ninoCoorp != null)
                        {
                            ninoCoorp.color = color;
                        }
                        if (calvoGrandeCoorp != null)
                        {
                            calvoGrandeCoorp.color = color;
                        }
                        if (calvoPequenoCoorp != null)
                        {
                            calvoPequenoCoorp.color = color;
                        }
                        if (nino2Coorp != null)
                        {
                            nino2Coorp.color = color;
                        }
                        if (balon != null)
                        {
                            balon.color = color;
                        }
                    }
                }

                    ultimoSegundo = segundoActual;
                }
                texto.text = "Día " + dia + " - Hora: " + hora + ":00";
            }
          

        
        
    }
}
