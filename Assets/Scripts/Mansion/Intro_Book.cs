using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_Book : MonoBehaviour
{
    private bool inside2 = false;
    public GameObject dialogueTrigger;

    void Update(){
        if(Input.GetKeyDown(KeyCode.F) && inside2){
            dialogueTrigger.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        inside2 = true;
    }

    private void OnTriggerExit2D(Collider2D other){
        inside2 = false;
    }
}