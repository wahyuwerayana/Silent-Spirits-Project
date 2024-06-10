using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger_MansionSpecial : MonoBehaviour
{
    public Dialogue dialogue;
    public BoxCollider2D dialogueCollider;
    public Color alpha;
    
    void Start(){
        dialogueCollider = GetComponent<BoxCollider2D>();
        alpha = GetComponent<SpriteRenderer>().color;
    }

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        alpha.a = 255;
        TriggerDialogue();
        dialogueCollider.enabled = false;
    }
}