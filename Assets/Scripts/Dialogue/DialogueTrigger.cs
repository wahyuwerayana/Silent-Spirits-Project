using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public float x = 0;
    public float y = 0;

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager_Mansion>().setGameobject(gameObject);
        FindObjectOfType<DialogueManager_Mansion>().StartDialogue(dialogue);
        if(x != 0 && y != 0)
            FindObjectOfType<DialogueManager_Mansion>().setCamLoc(x, y);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
            TriggerDialogue();
    }
}