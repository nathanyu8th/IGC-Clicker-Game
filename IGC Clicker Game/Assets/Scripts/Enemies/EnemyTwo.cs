using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    private GameObject player;
    private BoxCollider2D bc;
    private Rigidbody2D rb;
    public float speed;
    private float distance;
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
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if(Mathf.Abs(player.transform.position.x - transform.position.x) > 0.6f && Mathf.Abs(player.transform.position.y - transform.position.y) > 0.6f)
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

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
            Debug.Log("in");
            if(canAttack){
            
            PlayerHealth.instance.Damage();
            canAttack = false;
            cooldown = attackCooldown;
            }
        }
    }
}

