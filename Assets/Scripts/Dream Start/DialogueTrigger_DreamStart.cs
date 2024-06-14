using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger_DreamStart : MonoBehaviour
{
    public Dialogue dialogue;
    public float secondtoWait;
    private PlayerMovement movementScript;
    private Rigidbody2D rb;
    private Animator movement;
    private GameObject player;

    void Start(){
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody2D>();
        movementScript = player.GetComponent<PlayerMovement>();
        movement = player.GetComponent<Animator>();
    }

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager_DreamStart>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        movementScript.enabled = false;
        rb.velocity = new Vector2(0, 0);
        movement.SetBool("isWalking", false);
        if(this.name == "Second Dialogue")
            GameObject.Find("A").GetComponent<FollowPlayer>().speed = 0.5f;
        StartCoroutine("startdialogue");
    }

    IEnumerator startdialogue(){
        yield return new WaitForSeconds(secondtoWait);
        if(this.name == "Second Dialogue")
            GameObject.Find("A").GetComponent<FollowPlayer>().speed = 0;
        TriggerDialogue();
        Destroy(gameObject);
    }
}