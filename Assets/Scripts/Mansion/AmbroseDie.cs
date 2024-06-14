using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AmbroseDie : MonoBehaviour
{
    [SerializeField] private Enemy ambrose;
    [SerializeField] private DialogueTrigger dialTrigScr;
    [SerializeField] private PlayerMelee meleeScript;

    void Update(){
        if(ambrose.currentHealth <= 0){
            if(meleeScript != null)
                meleeScript.enabled = false;
            if(dialTrigScr != null)
                dialTrigScr.TriggerDialogue();
            this.enabled = false;
        }
    }
}