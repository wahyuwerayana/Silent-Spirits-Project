using UnityEngine;

public class QuizTrigger : MonoBehaviour
{
    public GameObject quizCanvas;
    private GameObject player;
    private PlayerMovement playerMovement;
    private Rigidbody2D rb;
    private Animator playerAnimator;

    private void Start()
    {
        player = GameObject.FindWithTag("Player"); 
        if (player != null)
        {
            playerMovement = player.GetComponent<PlayerMovement>();
            rb = player.GetComponent<Rigidbody2D>();
            playerAnimator = player.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("Player object not found!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            quizCanvas.SetActive(true);
            if (playerMovement != null)
            {
                playerMovement.enabled = false;
                rb.velocity = Vector2.zero;
                playerAnimator.SetBool("isWalking", false);
                Debug.Log("Quiz Canvas is now active and PlayerMovement script is disabled.");
            }
        }
    }
}


    /*private void OnTriggerExit2 D(Collider2D other)
    {
       
        if (other.CompareTag("Player"))
        {
            // Sembunyikan canvas quiz
            if (quizCanvas != null)
            {
                quizCanvas.SetActive(false);
                Debug.Log("Quiz Canvas is now inactive.");
            }
        }
    }*/

