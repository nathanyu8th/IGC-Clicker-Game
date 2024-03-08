using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBomb : MonoBehaviour
{
    public float deathTime;
    public float timeBetweenFiring;
    private float cooldown;
    public float damage;
    private bool canAttack;
    public SpriteRenderer sr;
    public float timeCanAttack;
    private float attackTime;


    void Start(){
        cooldown = timeBetweenFiring;
        attackTime = timeCanAttack;
    }
    void Update(){

        if(deathTime <=0){
            Destroy(gameObject);
        }
        deathTime -= Time.deltaTime;

        if(!canAttack){
            sr.color = new Color(1f,1f,1f,1f);
            if(cooldown > 0){
                cooldown -= Time.deltaTime;
            }
            else{
                canAttack = true;
                attackTime = timeCanAttack;

            }
        }
        else{
            sr.color = new Color(0f,0f,0f,1f);
            if(attackTime > 0){
                attackTime -= Time.deltaTime;
            }
            else{
                canAttack = false;
                cooldown = timeBetweenFiring;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Enemy"){
            if(canAttack){
                other.GetComponent<EnemyHealth>().TakeDamage(damage);
                
                
            }
            
        }
    }
}
