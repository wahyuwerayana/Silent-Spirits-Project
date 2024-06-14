using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlOverlay : MonoBehaviour
{
    public GameObject Book;
    public PlayerMovement moveScript;
    public Animator animator;
    private bool bookOpened = false;
    void Update(){
        if(bookOpened){
            if(Input.GetMouseButtonDown(0)){
                disableOverlay();
            }
        }
    }

    public void disableOverlay(){
        animator.SetBool("isOpened", false);
        StartCoroutine("closeBook");  
        //moveScript.enabled = true;  
        bookOpened = false;
    }

    public void enableOverlay(){
        bookOpened = true;
        Time.timeScale = 0;
        //moveScript.enabled = false;
        Book.SetActive(true);
        animator.SetBool("isOpened", true);
    }

    IEnumerator closeBook(){
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.2f);
        Book.SetActive(false);
    }
}