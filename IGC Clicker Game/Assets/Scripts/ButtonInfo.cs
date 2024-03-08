using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonInfo : MonoBehaviour
{
    public int button1Cost;
    public int button2Cost;
    
    
    
    public void Button1(){
        
        if(GameManager.instance.money > button1Cost){
            Debug.Log(Shooting.instance.timerList[0]);
            Shooting.instance.timerList[0] *= 0.8f;
            //Debug.Log(Shooting.instance.attackList[0].bulletCooldown);
            Debug.Log(Shooting.instance.timerList[0]);
            GameManager.instance.TakeMoney(button1Cost);
            button1Cost *= 2;
        }
    }

    public void Button2(){
        
        if(GameManager.instance.money > button2Cost){
            Shooting.instance.timerList[1] *= 0.8f;
            
            GameManager.instance.TakeMoney(button2Cost);
            button2Cost *= 2;
        }
    }


}
