using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger_Bedroom : MonoBehaviour
{
    public Dialogue dialogue;
    public float seconds;
    public GameObject nextTrigger;

    void Start(){
        StartCoroutine("dialogueStart");
    }

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager_Bedroom>().StartDialogue(dialogue);
        FindObjectOfType<DialogueManager_Bedroom>().getNextTrigger(nextTrigger);
    }

    IEnumerator dialogueStart(){
        yield return new WaitForSeconds(seconds);
        TriggerDialogue();
    }

    // private void OnTriggerEnter2D(Collider2D other) {
    //     TriggerDialogue();
    //     Destroy(gameObject);
    // }
}