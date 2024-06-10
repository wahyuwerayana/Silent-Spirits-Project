using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_Book : MonoBehaviour
{
    private bool inside = false;
    public GameObject dialogueTrigger, Chapter1;
    public PlayerTeleport teleportScript;

    void Update(){
        if(Input.GetKeyDown(KeyCode.F) && inside){
            dialogueTrigger.SetActive(true);
            Chapter1.SetActive(true);
            teleportScript.enabled = true;
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        inside = true;
    }

    private void OnTriggerExit2D(Collider2D other){
        inside = false;
    }
}