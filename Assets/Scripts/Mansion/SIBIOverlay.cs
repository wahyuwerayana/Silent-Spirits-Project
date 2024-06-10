using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIBIOverlay : MonoBehaviour
{
    public GameObject SIBI;
    public PlayerMovement moveScript;

    void Start(){
        enableOverlay();
        Time.timeScale = 0;
    }
    void Update(){
        if((Input.GetKeyDown(KeyCode.H) || Input.GetMouseButtonDown(0)) && SIBI.activeSelf == true){
            disableOverlay();
        } else if(Input.GetKeyDown(KeyCode.H) && SIBI.activeSelf == false){
            enableOverlay();
        }
    }

    public void disableOverlay(){
            Time.timeScale = 1;
            moveScript.enabled = true;
            SIBI.SetActive(false);
    }

    public void enableOverlay(){
        Time.timeScale = 0;
        moveScript.enabled = false;
        SIBI.SetActive(true);
    }
}