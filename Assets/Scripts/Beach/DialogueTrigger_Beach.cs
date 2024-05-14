using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger_Beach : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager_Beach>().StartDialogue(dialogue);
    }

    IEnumerator startDialogue(){
        yield return new WaitForSeconds(10);
        TriggerDialogue();
    }

    void Start(){
        StartCoroutine("startDialogue");
    }
}