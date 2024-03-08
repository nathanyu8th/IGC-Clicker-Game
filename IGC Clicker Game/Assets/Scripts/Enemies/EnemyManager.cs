using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Enemy currentEnemy;
    public Transform canvas;
    public static EnemyManager instance;
    private int enemyCount = 0;

    void Awake(){
        instance = this;
    }

    //Spawn Enemy
    public void SpawnEnemy(){
        //Random.Range(0, enemyPrefabs.Length)
        enemyCount++;
        GameObject enemyToSpawn = enemyPrefabs[enemyCount];
        GameObject obj = Instantiate(enemyToSpawn, canvas);
        
        currentEnemy = obj.GetComponent<Enemy>();
    }

    //Replace Enemy
    public void ReplaceEnemy(GameObject enemy){
        Destroy(enemy);
        SpawnEnemy();

    }
}
