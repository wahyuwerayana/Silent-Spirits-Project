using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public Transform Posisi, SoldierSpawnPos, BasementPos;
    private bool showWholeSentence = false;
    private bool canClick = true;
    private Queue<string> charName;
    private Queue<string> sentences;
    public PlayerMelee meleeScript;
    public GameObject commander, soldier1, soldier2, lysander;
    public GameObject entrance2, codeEnterColl;
    private Queue<bool> IsSpawnings = new Queue<bool>();
    public AudioSource chapter1, prechapter2, chapter2, prechapter3, chapter3;
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
        if(currGameObject.name == "Intro"){
            chapter1.volume = 0.2f;
            chapter1.loop = true;
            chapter1.Play();
        } else if(prepTime.activeSelf == false && currGameObject.name == "Preparation Time"){
            meleeScript.enabled = true;
            ambrose.enabled = true;
            ambrose.GetComponent<AmbroseDie>().enabled = true;
        } else if(currGameObject.name == "After Combat"){
            teleportScript.enabled = true;
        } else if(currGameObject.name == "Prologue Chapter 2"){
            prechapter2.volume = 0.2f;
            prechapter2.loop = false;
            chapter1.Stop();
            prechapter2.Play();
        } else if(currGameObject.name == "Arriving at the attic"){
            chapter2.volume = 0.2f;
            chapter2.loop = true;
            prechapter2.Stop();
            chapter2.Play();
            teleportScript.enabled = false;
            movementScript.enabled = false;
            StartCoroutine("intheothercorner");
        } else if(currGameObject.name == "In the other corner"){
            StartCoroutine("entrance1");
        } else if(currGameObject.name == "Meanwhile on the entrance 1"){
            entrance2.SetActive(true);
        } else if(currGameObject.name == "Meanwhile on the entrance 2"){
            player.GetComponent<PlayerHealth_Mansion>().currentHealth = 100;
            EnemySoldierAI commEAI = commander.GetComponent<EnemySoldierAI>();
            EnemySoldierAI sol1EAI = soldier1.GetComponent<EnemySoldierAI>();
            EnemySoldierAI sol2EAI = soldier2.GetComponent<EnemySoldierAI>();
            commEAI.enabled = true;
            sol1EAI.enabled = true;
            sol2EAI.enabled = true;
            meleeScript.enabled = true;
            GameObject.Find("Game Manager").GetComponent<CheckSoldierDie>().enabled = true;
        } else if(currGameObject.name == "After Combat - Chapter 2"){
            teleportScript.enabled = true;
        } else if(currGameObject.name == "Intro to Chapter 3"){
            prechapter3.volume = 0.2f;
            prechapter3.loop = false;
            chapter2.Stop();
            prechapter3.Play();
            commander.transform.position = new Vector2(BasementPos.position.x, BasementPos.position.y);
            soldier1.transform.position = new Vector2(BasementPos.position.x - 2f, BasementPos.position.y);
            soldier2.transform.position = new Vector2(BasementPos.position.x - 3f, BasementPos.position.y);
            ambrose.transform.position = new Vector2(BasementPos.position.x + 6.5f, BasementPos.position.y);
            ambrose.transform.localScale = new Vector2(ambrose.transform.localScale.x * -1f, ambrose.transform.localScale.y);
        } else if(currGameObject.name == "In the kitchen" || currGameObject.name == "Spirit 1" || currGameObject.name == "Spirit 2"){
            if(currGameObject.name == "In the kitchen"){
                chapter3.volume = 0.2f;
                chapter3.loop = false;
                prechapter3.Stop();
                chapter3.Play();
            }
            teleportScript.enabled = false;
            currGameObject.GetComponent<DialogueTrigger>().enabled = false;
        } else if(currGameObject.name == "Spirit 3"){
            StartCoroutine("afterInterview");
            lysander.GetComponent<BoxCollider2D>().enabled = true;
            lysander.GetComponent<InteractDialogue>().enabled = true;
            lysander.GetComponent<InteractDialogue>().onrange = false;
            lysander.GetComponent<InteractDialogue>().dialogueTrigger = GameObject.Find("Confronting the Killer");
        } else if(currGameObject.name == "Confronting the Killer"){
            player.GetComponent<PlayerHealth_Mansion>().currentHealth = 100;
            lysander.GetComponent<EnemyLysanderAI>().enabled = true;
            lysander.GetComponent<LysanderDie>().enabled = true;
            meleeScript.enabled = true;
        } else if(currGameObject.name == "Killer Defeated"){
            teleportScript.enabled = true;
        } else if(currGameObject.name == "On the way to the basement"){
            codeEnterColl.SetActive(true);
        } else if(currGameObject.name == "At underground 2"){
            StartCoroutine("changeScene");
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
        player.transform.position = new Vector2(player.transform.position.x - 12, player.transform.position.y);
        if(player.transform.localScale.x > 0){
            player.transform.localScale = new Vector2(-player.transform.localScale.x, player.transform.localScale.y);
            player.GetComponent<PlayerMovement>().isFacingRight = false;
        }
    }

    IEnumerator entrance1(){
        yield return new WaitForSeconds(2f);
        virtualCamera.SetActive(true);
        GameObject entrance1 = GameObject.Find("Meanwhile on the entrance 1");
        yield return new WaitForSeconds(1f);
        entrance1.GetComponent<DialogueTrigger>().TriggerDialogue();
        commander.transform.position = new Vector2(SoldierSpawnPos.position.x, SoldierSpawnPos.position.y);
        soldier1.transform.position = new Vector2(SoldierSpawnPos.position.x + 2, SoldierSpawnPos.position.y);
        soldier1.transform.localScale = new Vector2(-soldier1.transform.localScale.x, soldier1.transform.localScale.y);
        soldier2.transform.localScale = new Vector2(-soldier2.transform.localScale.x, soldier2.transform.localScale.y);
        soldier2.transform.position = new Vector2(SoldierSpawnPos.position.x + 4, SoldierSpawnPos.position.y);
    }

    IEnumerator afterInterview(){
        yield return new WaitForSeconds(2f);
        GameObject.Find("End Interview").GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    IEnumerator changeScene(){
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Underground");
    }
}