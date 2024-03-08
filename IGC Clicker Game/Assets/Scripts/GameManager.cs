using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public int money;
    public TextMeshProUGUI moneyText;
    public static GameManager instance;

    void Awake(){
        instance = this;
    }

    void Start(){
        moneyText.text = "$" + money.ToString();
    }

    public void AddMoney(int amount){        
        money += amount;
        //Debug.Log(money);
        moneyText.text = "$ " + money.ToString();
    }

    public void TakeMoney(int amount){
        money -= amount;
        moneyText.text = "$ " + money.ToString();
    }
    
}
