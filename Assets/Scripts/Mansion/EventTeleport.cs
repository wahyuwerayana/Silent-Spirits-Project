using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventTeleport : MonoBehaviour
{
    private Transform playerLocation;
    public Vector2 nextLocation;
    void Start(){
        playerLocation = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        playerLocation.transform.position = nextLocation;
        Destroy(gameObject);
    }
}