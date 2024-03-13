using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScipt : MonoBehaviour
{

    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    private float force;
    public float deathTime;
    private float damage;


    // Start is called before the first frame update
    void Start()
    {
        force = Shooting.instance.attackList[0].speed;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot + 90);

        
    }

    // Update is called once per frame
    void Update()
    {
        force = Shooting.instance.attackList[0].speed;
        damage = Shooting.instance.attackList[0].damage;
        if(deathTime <=0){
            Destroy(gameObject);
        }
        deathTime -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Enemy"){
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
