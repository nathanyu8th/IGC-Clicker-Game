using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float speed;
    public float deathTime;
    //private float damage;
    private GameObject player;
    private float distance;
    private BoxCollider2D bc;
    private Rigidbody2D rb;
    

    void Awake(){
        player = GameObject.FindWithTag("Player");
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //damage = Shooting.instance.attackList[0].damage;
        if(deathTime <=0){
            Destroy(gameObject);
        }
        deathTime -= Time.deltaTime;

        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //if(Mathf.Abs(player.transform.position.x - transform.position.x) > 0.6f && Mathf.Abs(player.transform.position.y - transform.position.y) > 0.6f)
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            PlayerHealth.instance.Damage();
            //other.transform.position = CheckPointManager.instance.checkPointPos;
            //StartCoroutine(Stop());
            Destroy(gameObject);
        }
    }
}
