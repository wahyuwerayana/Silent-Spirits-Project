using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int ItemValue = 1;
    private bool canPickup = false; 

    private void Update()
    {
     
        if (canPickup && Input.GetKeyDown(KeyCode.G))
        {
            PickItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canPickup = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canPickup = false; 
        }
    }

    private void PickItem()
    {
        Iinventory inventory = FindObjectOfType<PlayerInventory>(); 

        if (inventory != null)
        {
            inventory.Item += ItemValue;
            print("Player inventory has " + inventory.Item + " item(s) in it.");
            gameObject.SetActive(false);
        }
    }
}
