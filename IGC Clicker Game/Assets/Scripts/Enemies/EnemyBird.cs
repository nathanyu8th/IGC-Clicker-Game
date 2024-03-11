using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBird : MonoBehaviour
{
    public Vector3 targetPosition;
    private Vector3 startPosition;

    public float moveSpeed;
    private bool movingToTargetPos;
    private GameObject player;
    public float attackMove;
    private float cooldown;
    private bool canAttack = false;
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        movingToTargetPos = true;
        player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreLayerCollision(6, 6);
        cooldown = attackMove;
    }

    // Update is called once per frame
    void Update()
    {
        if(movingToTargetPos==true){
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if(transform.position == targetPosition){
                movingToTargetPos = false;
            }
        }
        else{
            transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);

            if(transform.position == startPosition){
                movingToTargetPos = true;
            }
        }
        if(attackMove > 0){
            attackMove -= Time.deltaTime;
        }
        else{
            canAttack = true;
        }
        if(canAttack){
            Instantiate(projectile, this.transform.position, this.transform.rotation);
            attackMove = cooldown;
            canAttack = false;
        }
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){

            //other.transform.position = CheckPointManager.instance.checkPointPos;
            //StartCoroutine(Stop());
        }
    }

    
}
