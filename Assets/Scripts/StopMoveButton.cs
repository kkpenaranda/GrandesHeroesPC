using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StopMoveButton : MonoBehaviour
{
    public Animator animationBtn;
    public JsonData jsonData;

    void Start()
    {        
        if ( this.name.Equals("ButtonGift") && File.Exists(Application.dataPath + "/Gamedata.json"))
        {   
            jsonData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Gamedata.json"));
            print("YES! "+(("0").Equals(""+jsonData[4])));
            animationBtn.enabled = (("0").Equals(""+jsonData[4]));
        }
        else{
            animationBtn.enabled = true;
        }
    }

    public void clickBtn()
    {
        animationBtn.enabled = false;
    }
}
