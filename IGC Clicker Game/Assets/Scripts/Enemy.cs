using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int currentHP;
    public int MaxHP;
    public int moneyGives;
    public Image healthBarFill;
    public void Damage(){
        currentHP--;
        healthBarFill.fillAmount = (float)currentHP/(float)MaxHP;

        if(currentHP <= 0){
            Die();
        }
    }

    public void Die(){
        GameManager.instance.AddMoney(moneyGives);
        EnemyManager.instance.ReplaceEnemy(gameObject);
    }
}
