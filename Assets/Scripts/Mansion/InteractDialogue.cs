using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDialogue : MonoBehaviour
{
    public bool onrange = false;
    public GameObject dialogueTrigger;
    public DialogueTrigger requirement;

    void Update(){
        if(Input.GetKeyDown(KeyCode.F)){
            if(requirement.enabled == false && onrange){
                dialogueTrigger.GetComponent<DialogueTrigger>().TriggerDialogue();
                this.GetComponent<BoxCollider2D>().enabled = false;
                this.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
            onrange = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player"))
            onrange = false;
    }
}