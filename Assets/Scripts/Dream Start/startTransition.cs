using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startTransition : MonoBehaviour
{
    public Animator transition;
    void Start(){
        StartCoroutine("sceneStart");
    }

    IEnumerator sceneStart(){
        yield return new WaitForSeconds(2f);
        transition.SetTrigger("startTransition");
    }
}