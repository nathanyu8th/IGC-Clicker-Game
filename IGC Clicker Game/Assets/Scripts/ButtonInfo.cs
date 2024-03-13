using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonInfo : MonoBehaviour
{
    public int[] button1Info;
    public TextMeshProUGUI button1Text;

    public int[] button2Info;
    public TextMeshProUGUI button2Text;

    public int[] button3Info;
    public TextMeshProUGUI button3Text;

    public int[] button4Info;
    public TextMeshProUGUI button4Text;
    public GameObject bullet2;

    public int[] button5Info;
    public TextMeshProUGUI button5Text;
    public GameObject laserBeam;
    //[0] = cost
    //[1] = amount
    
    
    void Start(){
        button1Text.SetText("Cost " + button1Info[0].ToString() + ", Amount " + button1Info[1].ToString());
        button2Text.SetText("Cost " + button2Info[0].ToString() + ", Amount " + button2Info[1].ToString());
        button3Text.SetText("Cost " + button3Info[0].ToString() + ", Amount " + button3Info[1].ToString());
        button4Text.SetText("Cost " + button4Info[0].ToString() + ", Amount " + button4Info[1].ToString());
        button5Text.SetText("Cost " + button5Info[0].ToString() + ", Amount " + button5Info[1].ToString());
    }

    //Decrease Bullet Cooldown
    public void Button1(){
        
        if(GameManager.instance.money >= button1Info[0] && button1Info[1] > 0){
            //Debug.Log(Shooting.instance.timerList[0]);
            Shooting.instance.timerList[0] *= 0.8f;
            //Debug.Log(Shooting.instance.attackList[0].bulletCooldown);
            //Debug.Log(Shooting.instance.timerList[0]);
            GameManager.instance.TakeMoney(button1Info[0]);
            button1Info[0] *= 2;
            button1Info[1] -= 1;
            button1Text.SetText("Cost " + button1Info[0].ToString() + ", Amount " + button1Info[1].ToString());
        }
    }

    //Decrease Bullet Cooldown
    public void Button2(){
        
        if(GameManager.instance.money >= button2Info[0] && button2Info[1] > 0){
            Shooting.instance.timerList[1] *= 0.8f;
            
            GameManager.instance.TakeMoney(button2Info[0]);
            button2Info[0] *= 2;
            button2Info[1] -= 1;
            button2Text.SetText("Cost " + button2Info[0].ToString() + ", Amount " + button2Info[1].ToString());
        }
    }

    //Increase Bullet Damage
    public void Button3(){
        
        if(GameManager.instance.money >= button3Info[0] && button3Info[1] > 0){
            Shooting.instance.attackList[0].damage *= 1.5f;
            
            GameManager.instance.TakeMoney(button3Info[0]);

            button3Info[0] *= 2;
            button3Info[1] -= 1;
            button3Text.SetText("Cost " + button3Info[0].ToString() + ", Amount " + button3Info[1].ToString());
        }
    }

    //Add Non Destroy Bullet
    public void Button4(){
        
        if(GameManager.instance.money >= button4Info[0] && button4Info[1] > 0){

            AttackData newAttack = new AttackData();
            newAttack.attackPrefab = bullet2;
            newAttack.bulletCooldown = 5f;
            newAttack.name = "NonDestroyable Bullet";
            newAttack.playerPosition = true;
            newAttack.damage = 5f;
            newAttack.speed = 7f;
            Shooting.instance.addAttackList(newAttack);
            
            GameManager.instance.TakeMoney(button4Info[0]);

            //button4Info[0] *= 2;
            button4Info[1] -= 1;
            button4Text.SetText("Cost " + button4Info[0].ToString() + ", Amount " + button4Info[1].ToString());
        }
    }

    //Add Laser Beam
    public void Button5(){
        
        if(GameManager.instance.money >= button5Info[0] && button5Info[1] > 0){
            
            Shooting.instance.timerList[0] *= 0.8f;
            
            AttackData newAttack = new AttackData();
            newAttack.attackPrefab = laserBeam;
            newAttack.bulletCooldown = 5f;
            newAttack.name = "Laser Beam";
            newAttack.playerPosition = true;
            newAttack.damage = 5f;
            newAttack.speed = 7f;
            Shooting.instance.addAttackList(newAttack);
            GameManager.instance.TakeMoney(button5Info[0]);

            button5Info[0] *= 2;
            button5Info[1] -= 1;
            button5Text.SetText("Cost " + button5Info[0].ToString() + ", Amount " + button5Info[1].ToString());
        }
    }


}
