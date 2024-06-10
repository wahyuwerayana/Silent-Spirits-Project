using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public PlayerMovement movementScript;
    public Animator transition;
    private void OnTriggerEnter2D(Collider2D other) {
        StartCoroutine("changeScene");
        movementScript.enabled = false;
        transition.SetTrigger("startTransition");
    }

    IEnumerator changeScene(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Chapter1");
    }
}