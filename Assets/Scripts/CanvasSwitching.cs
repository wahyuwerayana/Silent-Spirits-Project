using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitching : MonoBehaviour
{
    public GameObject SIBI;

    void Update(){
        if((Input.GetKeyDown(KeyCode.H) || Input.GetMouseButtonDown(0)) && SIBI.activeSelf == true){
            SIBI.SetActive(false);
        } else if(Input.GetKeyDown(KeyCode.H) && SIBI.activeSelf == false){
            SIBI.SetActive(true);
        }
    }
}