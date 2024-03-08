using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager1 : MonoBehaviour
{
    public float timer;
    public float startTime;
    public GameObject enemy;
    public int numOfEnemies;


    void Start(){
        //spawnTimer = setTimer(timer);
        StartCoroutine("Spawner");
    }

    IEnumerator Spawner(){
        yield return new WaitForSeconds(startTime);
        for(int i = 0; i < numOfEnemies; i++){
        yield return new WaitForSeconds(setTimer(timer));
        Instantiate(enemy, transform.position, transform.rotation);
        }


    }

    private float setTimer(float timer){
        return Random.Range(timer - 2f, timer + 2f);
    }
}
