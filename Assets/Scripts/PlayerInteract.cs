using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public NPCDrop npcDrop; 
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
            canInteract = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            canInteract = false; 
        }
    }

    private void InteractWithNPC()
    {
        Iinventory inventory = FindObjectOfType<PlayerInventory>();
        if (inventory != null && inventory.Item > 0) 
        {
            inventory.Item -= 3; 
            npcDrop.ReceiveItemFromPlayer(); 
        }
    }

}
