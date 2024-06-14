using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager_DreamStart : MonoBehaviour
{
    public int counter = 0;
    public GameObject nameBox;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Animator animator, movement, appear;
    public PlayerMovement movementScript;
    public Rigidbody2D rb;
    private bool showWholeSentence = false;
    private bool canClick = true;
    private Queue<string> charName;
    private Queue<string> sentences;
    public GameObject thirdDialogue, BG1, BG2;
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

    IEnumerator sceneFinish(){
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Bedroom");
    }

    void EndDialogue(){
        counter++;
        animator.SetBool("isOpen", false);
        movementScript.enabled = true;
        if(counter == 2){
            thirdDialogue.SetActive(true);
            appear.SetTrigger("backgroundAppear");
            BG1.SetActive(true);
            BG2.SetActive(true);
        } else if(counter == 3){
            GameObject.Find("A").GetComponent<FollowPlayer>().speed = 3.2f;
        }
    }
}