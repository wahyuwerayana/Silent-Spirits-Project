using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager_Bedroom : MonoBehaviour
{
    public GameObject nameBox, nextTrigger;
    public Animator transition;
    public int counter = 0;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Animator animator;
    private bool showWholeSentence = false;
    private bool canClick = true;
    private Queue<string> charName;
    private Queue<string> sentences;
    void Start(){
        sentences = new Queue<string>();
        charName = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue){
        animator.SetBool("isOpen", true);
        charName.Clear();
        
        foreach (string name in dialogue.charNumber){
            charName.Enqueue(name);
        }
        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if(!canClick){
            showWholeSentence = true;
            canClick = true;
            return;
        } else if(canClick){
            canClick = false;
        }
        if(sentences.Count == 0){
            canClick = true;
            EndDialogue();
            return;
        }

        string currName = charName.Dequeue();
        nameText.text = currName;
        string sentence = sentences.Dequeue();

        if(currName.Length == 0){
            nameBox.SetActive(false);
        } else if(currName.Length >= 1){
            nameBox.SetActive(true);
        }
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence){
        dialogueText.text = "";
        showWholeSentence = false;
        foreach(char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            if(!showWholeSentence)
            yield return new WaitForSeconds(.025f);
        }
        canClick = true;
    }

    IEnumerator changeScene(){
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Dream Start");
    }

    void EndDialogue(){
        counter++;
        if(counter == 1){
            transition.SetTrigger("startTransition");
        } else if(counter == 2){
            StartCoroutine("changeScene");
        }
        animator.SetBool("isOpen", false);
        if(nextTrigger != null)
        nextTrigger.SetActive(true);
    }

    public void getNextTrigger(GameObject objectTrigger){
        nextTrigger = objectTrigger;
    }
}