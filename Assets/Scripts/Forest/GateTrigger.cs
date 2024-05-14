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
    private void OnTriggerStay2D(Collider2D other){
        if(Input.GetKeyDown(KeyCode.F)){
            gateAnimator.SetTrigger("openGate");
            gateCollider.enabled = false;
            Destroy(gameObject);
        }
    }
}