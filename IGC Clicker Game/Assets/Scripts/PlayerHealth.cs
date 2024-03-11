using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int currentHP;
    public int MaxHP;
    //public int moneyGives;
    public Image healthBarFill;
    private GameObject player;
    public static PlayerHealth instance;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }

    }
    public void Damage(){
        currentHP--;
        healthBarFill.fillAmount = (float)currentHP/(float)MaxHP;
        

        if(currentHP <= 0){
            Die();
        }
    }

    

    public void Die(){
        //GameManager.instance.AddMoney(moneyGives);
        //EnemyManager.instance.ReplaceEnemy(gameObject);
        Debug.Log("you died");
        Destroy(player);
    }
}
