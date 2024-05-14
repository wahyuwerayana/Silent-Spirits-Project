using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger_Forest : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager_Forest>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        TriggerDialogue();
        Destroy(gameObject);
    }
}