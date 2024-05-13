using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDrop : MonoBehaviour
{
    public GameObject[] PrizeDropPrefabs; 
    private bool hasReceivedItem = false; 

    
    public void ReceiveItemFromPlayer()
    {
        hasReceivedItem = true;
    }

    private void Update()
    {
        if (hasReceivedItem)
        {
            DropPrize(); 
            hasReceivedItem = false; 
        }
    }

    private void DropPrize()
    {
        foreach (GameObject prizePrefab in PrizeDropPrefabs)
        {
            Instantiate(prizePrefab, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
        }
    }
}
