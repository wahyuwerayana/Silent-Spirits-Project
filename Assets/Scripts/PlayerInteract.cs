// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerInteract : MonoBehaviour
// {
//     public NPCDrop npcDrop; 
//     private bool canInteract = false; 

//     private void Update()
//     {
//         if (canInteract && Input.GetKeyDown(KeyCode.T))
//         {
//             InteractWithNPC();
//         }
//     }

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("NPC"))
//         {
//             canInteract = true; 
//         }
//     }

//     private void OnTriggerExit2D(Collider2D other)
//     {
//         if (other.CompareTag("NPC"))
//         {
//             canInteract = false; 
//         }
//     }

//     private void InteractWithNPC()
//     {
//         Iinventory inventory = FindObjectOfType<PlayerInventory>();
//         if (inventory != null && inventory.Item > 0) 
//         {
//             inventory.Item -= 3; 
//             npcDrop.ReceiveItemFromPlayer(); 
//         }
//     }

// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private NPCDrop currentNpcDrop; 
    private bool canInteract = false; 

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.T))
        {
            InteractWithNPC();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            currentNpcDrop = other.GetComponent<NPCDrop>();
            Debug.Log("Player can interact with " + other.gameObject.name);
            canInteract = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            canInteract = false; 
            currentNpcDrop = null;
            Debug.Log("Player stopped interacting with " + other.gameObject.name);
        }
    }

    private void InteractWithNPC()
    {
        Iinventory inventory = FindObjectOfType<PlayerInventory>();
        if (inventory != null && inventory.Item > 0 && currentNpcDrop != null) 
        {
            Debug.Log("Player interacting with " + currentNpcDrop.gameObject.name);
            inventory.Item -= 3; 
            currentNpcDrop.ReceiveItemFromPlayer(); 
        }
    }
}
