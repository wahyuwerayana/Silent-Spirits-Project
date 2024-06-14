using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBorderController : MonoBehaviour
{
    public PlayerMovement movementScript;
    public Rigidbody2D rb;
    public BoxCollider2D invisibleBorder;
    public Animator player;
    void Start(){
        movementScript.enabled = false;
        invisibleBorder.enabled = false;
        rb.velocity = new Vector2(4f, 0);
        player.SetBool("isWalking", true);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            movementScript.enabled = true;
            invisibleBorder.enabled = true;
            player.SetBool("isWalking", false);
            Destroy(gameObject);
        }
    }
}