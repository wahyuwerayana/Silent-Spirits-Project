using UnityEngine;

public class QuizTrigger : MonoBehaviour
{
    public GameObject quizCanvas; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek apakah yang memasuki trigger adalah pemain
        if (other.CompareTag("Player"))
        {
           quizCanvas.SetActive(true);
           Debug.Log("Quiz Canvas is now active.");
           
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Cek apakah yang keluar dari trigger adalah pemain
        if (other.CompareTag("Player"))
        {
            // Sembunyikan canvas quiz
            if (quizCanvas != null)
            {
                quizCanvas.SetActive(false);
                Debug.Log("Quiz Canvas is now inactive.");
            }
        }
    }
}
