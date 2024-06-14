using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger_MansionSpecial : MonoBehaviour
{
    public Dialogue dialogue;
    public BoxCollider2D dialogueCollider;
    public SpriteRenderer spriteRenderer, pants, shirt, boots, hair, sword;
    public PlayerMovement movementScript;
    public Rigidbody2D rb;
    public Animator movement;
    public int targetNumber;
    
    void Start(){
        dialogueCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager_Mansion>().StartDialogue(dialogue);
        FindObjectOfType<DialogueManager_Mansion>().setGameobject(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            spriteRenderer.color = new Color(1, 1, 1, 255);
            pants.color = new Color(1, 1, 1, 255);
            shirt.color = new Color(1, 1, 1, 255);
            boots.color = new Color(1, 1, 1, 255);
            hair.color = new Color(1, 1, 1, 255);
            sword.color = new Color(1, 1, 1, 255);
            dialogueCollider.enabled = false;
            movementScript.enabled = false;
            rb.velocity = new Vector2(0, 0);
            movement.SetBool("isWalking", false);
            StartCoroutine("delay");
        }
    }

    IEnumerator delay(){
        yield return new WaitForSeconds(1f);
        TriggerDialogue();
    }
}