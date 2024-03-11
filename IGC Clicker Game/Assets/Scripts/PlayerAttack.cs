using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;


    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(bullet,firePoint.position,firePoint.rotation);
        }
    }
}
