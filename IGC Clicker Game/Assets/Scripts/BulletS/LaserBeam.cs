using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    private Camera mainCam;
    public float activeTime;
    public LineRenderer lr;
    private GameObject player;
    private Vector3 mousePos;
    private bool canAttack = true;
    private RaycastHit2D[] hitList;
    public float attackCooldown;
    private float cooldown;
    private float damage;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        cooldown = attackCooldown;
        //lr.setActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        damage = Shooting.instance.attackList[0].damage;
        StartCoroutine(Fire());
        if(cooldown <= 0){

        Vector3 direction = mousePos - transform.position;
        hitList = Physics2D.RaycastAll((Vector2)transform.position, (Vector2)direction.normalized, direction.magnitude);

        for(int i = 0; i < hitList.Length; i++){
            if(hitList[i].transform.gameObject.tag == "Enemy"){
                hitList[i].transform.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                //Destroy(gameObject);
            }
        }
        cooldown = attackCooldown;

        }
        else{
            cooldown -= Time.deltaTime;
        }
        
    }

    IEnumerator Fire(){
        //lr.SetActive(true);
        lr.SetPosition(0, player.transform.position);
        lr.SetPosition(1, mousePos);
        yield return new WaitForSeconds(activeTime);
        Destroy(gameObject);
    }

    

}
