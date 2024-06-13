using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager_Mansion>().StartDialogue(dialogue);
        FindObjectOfType<DialogueManager_Mansion>().setGameobject(gameObject);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        TriggerDialogue();
    }
}