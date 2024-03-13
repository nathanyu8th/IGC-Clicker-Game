using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject[] bullet;
    public Transform bulletTransform;
    public bool canFire;
    public List<float> timerList = new List<float>();
    public float timeBetweenFiring;
    private int moveNumber;
    public TextMeshProUGUI currentText;

    public List<AttackData>  attackList = new List<AttackData>();

    public static Shooting instance;

    

    //Dictionary<AttackData, float> cooldownDict = new Dictionary<AttackData, float>();

    void Start(){
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        moveNumber = 0;
        foreach(AttackData AttackData in attackList){
            timerList.Add(AttackData.bulletCooldown);
        }
        foreach(AttackData AttackData in attackList){
                if(AttackData.bulletCooldown > 0){
                    
                    AttackData.bulletCooldown =0;
                }
            }

        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }

    }

    public void addAttackList(AttackData attack){
        attackList.Add(attack);
        timerList.Add(attack.bulletCooldown);
        attack.bulletCooldown = 0;
    }

    void Update(){
        currentText.SetText("Current Move: " + attackList[moveNumber].name + "\n" + "Cooldown: " + Mathf.Round(attackList[moveNumber].bulletCooldown * 100f)/100f);
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        // if(!canFire){
        //     timer+= Time.deltaTime;
        //     if(timer > timeBetweenFiring){
        //         canFire = true;
        //         timer = 0;
        //     }
        // }
        
            foreach(AttackData AttackData in attackList){
                if(AttackData.bulletCooldown > 0){
                    
                    AttackData.bulletCooldown -= Time.deltaTime;
                }
            }
        

        if(Input.GetMouseButton(0) && attackList[moveNumber].bulletCooldown <= 0){
            //canFire = false;
             
             if(attackList[moveNumber].playerPosition){
                Instantiate(attackList[moveNumber].attackPrefab, bulletTransform.position, Quaternion.identity);
             }
             else{
                Instantiate(attackList[moveNumber].attackPrefab, mousePos, Quaternion.identity);
             }
             attackList[moveNumber].bulletCooldown = timerList[moveNumber];
        }


        if(Input.GetKeyDown(KeyCode.F)){
             if(moveNumber == attackList.Count-1){
                 moveNumber = 0;
             }
             else{
                 moveNumber+= 1;
             }
         }


        // foreach (float cooldown in cooldownDict.Values) {
        //     cooldownDict[cooldown] -= Time.deltaTime;
        // }


        //[0] should be a shooting move straight
        //[1] should be the bomb
        //[2] big AoE, less dmg
        //[3] try beam
        //[4] big bomb that goes thru enemies
        //[5] vertical lightning attack


        // if(Input.GetMouseButton(0) && canFire){
        //     canFire = false;
        //     if(moveNumber == 0){
        //         Instantiate(bullet[moveNumber], bulletTransform.position, Quaternion.identity);
        //     }
        //     else if(moveNumber == 1){
        //         Instantiate(bullet[moveNumber], mousePos, Quaternion.identity);
        //     }
        // }

        // if(Input.GetKeyDown(KeyCode.F)){
        //     if(moveNumber == bullet.Length-1){
        //         moveNumber = 0;
        //     }
        //     else{
        //         moveNumber+= 1;
        //     }
        // }

    }


}

[System.Serializable]
public class AttackData {
    public GameObject attackPrefab;
    public float bulletCooldown;
    public string name;
    public bool playerPosition;
    //public static AttackData instance;
    public float damage;
    public float speed;
    

}
