using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : MonoBehaviour
{
    public float speed;
    private GameObject player;
    private BoxCollider2D bc;
    private Rigidbody2D rb;
    public float attackCooldown;
    private float cooldown;
    private bool canAttack = false;


    void Awake(){
        player = GameObject.FindWithTag("Player");
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        cooldown = attackCooldown;
        Physics2D.IgnoreLayerCollision(6, 6);
    }

    void Update(){
        
        if(player.transform.position.x -1 > this.transform.position.x){
            rb.velocity = new Vector3(1 * speed, 0,0);
            transform.localScale = Vector3.one;
        }
        else if(player.transform.position.x + 1 < this.transform.position.x){
            rb.velocity = new Vector3(-1 * speed, 0,0);
            transform.localScale = new Vector3(-1,1,1);
        }
        if(cooldown > 0){
            cooldown -= Time.deltaTime;
        }
        
        if(cooldown <= 0){
            //attack();
            canAttack = true;
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Player"){
            if(canAttack){
            PlayerHealth.instance.Damage();
            canAttack = false;
            cooldown = attackCooldown;
            }
        }
    }
}
