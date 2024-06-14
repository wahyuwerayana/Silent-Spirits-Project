using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LysanderDie : MonoBehaviour
{
    [SerializeField] private Enemy lysander;
    [SerializeField] private PlayerMelee meleeScript;
    void Start(){
        lysander = GetComponent<Enemy>();
    }

    void Update(){
        if(lysander.currentHealth <= 0){
            GameObject.Find("Killer Defeated").GetComponent<DialogueTrigger>().TriggerDialogue();
            meleeScript.enabled = false;
            Destroy(gameObject);
        }
    }
}