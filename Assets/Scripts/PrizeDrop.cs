using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeDrop : MonoBehaviour
{

    private Rigidbody2D prizeRb;
    public float dropForce = 5;


    void Start()
    {
        prizeRb = GetComponent<Rigidbody2D>();
        prizeRb.AddForce(Vector2.up * dropForce, ForceMode2D.Impulse);
    }
}
