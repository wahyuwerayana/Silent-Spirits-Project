using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager_Mansion : MonoBehaviour
{
    public int counter;
    public float xVal, yVal;
    public GameObject nameBox, prepTime, code, gameManager, virtualCamera, player;
    public PlayerMovement movementScript;
    public PlayerTeleport teleportScript;
    public DialogueTrigger_MansionSpecial dtMansionScr;
    public EnemyAI ambrose;
    public Rigidbody2D rb;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Animator animator, movement;
    public GameObject Weapon;
    public Transform Posisi;
    private bool showWholeSentence = false;
    private bool canClick = true;
    private Queue<string> charName;
    private Queue<string> sentences;
    public PlayerMelee meleeScript;
    private Queue<bool> IsSpawnings = new Queue<bool>();
    [Header("Current Game Object Active")]
    public GameObject currGameObject;
    void Start(){
        sentences = new Queue<string>();
        charName = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue){
        counter = 0;
        movementScript.enabled = false;
        animator.SetBool("isOpen", true);
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

        if(dialogue.IsSpawnWeapon.Length > 0){
            foreach(bool betul in dialogue.IsSpawnWeapon){
                IsSpawnings.Enqueue(betul);
            }
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
            counter++;
        }
        if(sentences.Count == 0){
            canClick = true;
            EndDialogue();
            return;
        }

        string currName = charName.Dequeue();
        nameText.text = currName;
        string sentence = sentences.Dequeue();

        if(currGameObject != null){
            if(currGameObject.name == "After Combat"){
                ambrose.enabled = false;
                ambrose.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                ambrose.GetComponent<Animator>().SetBool("isWalking", false);
                if(counter == 7)
                    code.SetActive(true);
                else
                    code.SetActive(false);
            }
        }

        if(IsSpawnings != null){
            bool Spawn = IsSpawnings.Dequeue();
            if(Spawn){
                GameObject barang= Instantiate(Weapon,Posisi);
            }
        }

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

    void EndDialogue(){
        animator.SetBool("isOpen", false);
        movementScript.enabled = true;
        if(prepTime.activeSelf == false && currGameObject.name == "Preparation Time"){
            meleeScript.enabled = true;
            ambrose.enabled = true;
        } else if(currGameObject.name == "After Combat"){
            teleportScript.enabled = true;
        } else if(currGameObject.name == "Arriving at the attic"){
            movementScript.enabled = false;
            StartCoroutine("intheothercorner");
        } else if(currGameObject.name == "In the other corner"){
            virtualCamera.SetActive(true);
        }
    }

    public void setGameobject(GameObject goName){
        currGameObject = goName;
    }

    public void setCamLoc(float x, float y){
        xVal = x;
        yVal = y;
    }

    IEnumerator intheothercorner(){
        yield return new WaitForSeconds(2f);
        gameManager.GetComponent<CameraMove>().MoveCamera(xVal, yVal);
        GameObject intheothercorner = GameObject.Find("In the other corner");
        yield return new WaitForSeconds(3f);
        intheothercorner.GetComponent<DialogueTrigger>().TriggerDialogue();
        player.transform.position = new Vector2(player.transform.position.x - 6, player.transform.position.y);
    }
}