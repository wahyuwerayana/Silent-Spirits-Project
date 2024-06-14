using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIBIOverlay : MonoBehaviour
{
    public GameObject SIBI;
    public PlayerMovement moveScript;
    public Animator animator;

    void Start(){
        enableOverlay();
        Time.timeScale = 0;
    }
    void Update(){
        if((Input.GetKeyDown(KeyCode.H) || Input.GetMouseButtonDown(0)) && SIBI.activeSelf == true){
            disableOverlay();
        } else if(Input.GetKeyDown(KeyCode.H) && SIBI.activeSelf == false){
            enableOverlay();
        }
    }

    public void disableOverlay(){
        animator.SetBool("isOpened", false);
        StartCoroutine("closeBook");  
        moveScript.enabled = true;  
    }

    public void enableOverlay(){
        Time.timeScale = 0;
        moveScript.enabled = false;
        SIBI.SetActive(true);
        animator.SetBool("isOpened", true);
    }

    IEnumerator closeBook(){
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.2f);
        SIBI.SetActive(false);
    }
}