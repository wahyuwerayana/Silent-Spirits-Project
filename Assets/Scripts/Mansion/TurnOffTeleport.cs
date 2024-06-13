using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffTeleport : MonoBehaviour
{
    public PlayerTeleport teleportScript;

    private void OnTriggerEnter2D(Collider2D other) {
        teleportScript.enabled = false;
    }
}