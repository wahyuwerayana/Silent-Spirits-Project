using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager_Forest : MonoBehaviour
{
    public int counter = 0;
    public GameObject fifthDialogue;
    public GameObject nameBox;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Animator animator, movement, transition;
    public GameObject player;
    public Rigidbody2D rb;
    private bool showWholeSentence = false;
    private bool canClick = true;
    private Queue<string> charName;
    private Queue<string> sentences;
    void Start(){
        sentences = new Queue<string>();
        charName = new Queue<string>();
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody2D>();
        movement = player.GetComponent<Animator>();
    }

    public void StartDialogue(Dialogue dialogue){
        animator.SetBool("isOpen", true);
        player.GetComponent<PlayerMovement>().enabled = false;
        rb.velocity = new Vector2(0, 0);
        movement.SetBool("isWalking", false);
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

    IEnumerator fifthTrigger(){
        yield return new WaitForSeconds(4f);
        fifthDialogue.SetActive(true);
    }
    IEnumerator sceneFinish(){
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Bedroom");
    }

    void EndDialogue(){
        counter++;
        animator.SetBool("isOpen", false);
        if(counter < 4)
            player.GetComponent<PlayerMovement>().enabled = true;
        if(counter == 4 || counter == 1){
            transition.SetTrigger("startTransition");
            if(counter == 4)
            StartCoroutine("fifthTrigger");
        }
        if(counter == 5)
            StartCoroutine("sceneFinish");
    }
}