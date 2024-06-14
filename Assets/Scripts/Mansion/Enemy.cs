using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public DialogueTrigger dialTrigScr;
    public PlayerMelee meleeScript;
    public int maxHealth = 100;
    public int currentHealth;
    public Type ScriptType;
    [SerializeField] private Component script;
    [SerializeField] private string scriptName;
    void Start(){
        currentHealth = maxHealth;
        ScriptType = Type.GetType(scriptName);
        script = gameObject.GetComponent(ScriptType);
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        if(currentHealth <= 0){
            Die();
        }
    }

    void Die(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<Animator>().SetBool("isWalking", false);
        ((MonoBehaviour)script).enabled = false;
        this.enabled = false;
    }
}