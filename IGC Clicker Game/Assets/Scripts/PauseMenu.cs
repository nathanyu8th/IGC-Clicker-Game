using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject PausePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        }
    }

    public void Pause(){
        
    }

    public void Continue(){
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }


}
