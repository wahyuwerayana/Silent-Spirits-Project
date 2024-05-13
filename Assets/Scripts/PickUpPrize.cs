using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPrize : MonoBehaviour
{
    public int PrizeValue = 1;
    private bool canPickup = false;

    private void Update()
    {

        if (canPickup && Input.GetKeyDown(KeyCode.G))
        {
            PickPrize();
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

    private void PickPrize()
    {
        Iinventory inventory = FindObjectOfType<PlayerInventory>();

        if (inventory != null)
        {
            inventory.Prizee += PrizeValue;
            print("Player inventory has " + inventory.Prizee + " item(s) in it.");
            gameObject.SetActive(false);
        }
    }
}
