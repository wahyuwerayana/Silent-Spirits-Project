using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger_EndGame : MonoBehaviour
{
    public Dialogue dialogue;

    void Start(){
        StartCoroutine("starting");
    }

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager_EndGame>().StartDialogue(dialogue);
    }

    IEnumerator starting(){
        yield return new WaitForSeconds(1.5f);
        TriggerDialogue();
    }

}