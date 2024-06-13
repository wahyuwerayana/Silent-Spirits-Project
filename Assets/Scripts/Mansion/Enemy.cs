using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public DialogueTrigger dialTrigScr;
    public PlayerMelee meleeScript;
    public int maxHealth = 100;
    int currentHealth;
    void Start(){
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        if(currentHealth <= 0){
            Die();
        }
    }

    void Die(){
        GetComponent<Collider2D>().enabled = false;
        meleeScript.enabled = false;
        dialTrigScr.TriggerDialogue();
        this.enabled = false;
    }
}