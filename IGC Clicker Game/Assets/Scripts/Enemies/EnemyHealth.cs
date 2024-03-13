using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth {get; private set;}
    public int moneyGives;
    //public static EnemyHealth instance;


    // Start is called before the first frame update
    void Awake()
    {
        // if(instance == null){
        //     instance = this;
        // }else{
        //     Destroy(gameObject);
        // }
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage){
        Debug.Log(currentHealth);
        if (currentHealth > 0){
            currentHealth = Mathf.Clamp(currentHealth - _damage,0 , startingHealth);
            if(currentHealth <=0){
                GameManager.instance.AddMoney(moneyGives);
                Destroy(gameObject);
            }
        
        }
        else{
            //GameManager.instance.AddMoney(moneyGives);
            Destroy(gameObject);
        }
        }
}
