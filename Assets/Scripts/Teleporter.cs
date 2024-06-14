using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    [SerializeField] private Transform destination;
    public GameObject quizCanvas;
    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            quizCanvas.SetActive(true);
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            quizCanvas.SetActive(false);
        }

    }
        public Transform GetDestination()
    {
        return destination;
    }
}
