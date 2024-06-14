using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSoldierDie : MonoBehaviour
{
    public Enemy commander, soldier1, soldier2;
    public PlayerMelee meleeScript;

    void Update(){
        if(commander.currentHealth <= 0 && soldier1.currentHealth <= 0 && soldier2.currentHealth <= 0){
            meleeScript.enabled = false;
            GameObject.Find("After Combat - Chapter 2").GetComponent<DialogueTrigger>().TriggerDialogue();
            this.enabled = false;
        }
    }
}