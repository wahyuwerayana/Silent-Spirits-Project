using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public GameObject quizCanvas;
    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("nigger");
        if (other.CompareTag("Player"))
        {
            quizCanvas.SetActive(true);
            playerInRange = true;
            Debug.Log("Player entered");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("nigger");
        if (other.CompareTag("Player"))
        {
            
            playerInRange = false;
            quizCanvas.SetActive(false);
            Debug.Log("Player left");
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Transitioning to ending scene.");
            SceneManager.LoadScene("EndGame");
        }
    }
}
