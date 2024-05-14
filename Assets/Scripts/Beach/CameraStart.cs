using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStart : MonoBehaviour
{
    public Animator animator;
    IEnumerator StartTransition(){
        yield return new WaitForSeconds(3);
        animator.SetTrigger("isStart");
    }
    void Start(){
        animator = GetComponent<Animator>();
        StartCoroutine("StartTransition");
    }
}