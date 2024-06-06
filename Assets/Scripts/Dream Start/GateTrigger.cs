using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    public GameObject gate;
    private Animator gateAnimator;
    private BoxCollider2D gateCollider;

    void Start() {
        gateAnimator = gate.GetComponent<Animator>();
        gateCollider = gate.GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other){
            gateAnimator.SetTrigger("openGate");
            gateCollider.enabled = false;
            Destroy(gameObject);
    }
}