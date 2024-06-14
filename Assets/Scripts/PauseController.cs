using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pausePanel;
    public bool isPaused = false;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            isPaused = !isPaused;

            if(isPaused){
                Time.timeScale = 0;
                pausePanel.SetActive(true);
            } else if(!isPaused){
                Time.timeScale = 1;
                pausePanel.SetActive(false);
            }
        }
    }

    public void Resume(){
        isPaused = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void Exit(){
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}