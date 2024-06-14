using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivator : MonoBehaviour
{
    public GameObject requirement, targetActivator;
    void Update(){
        if(requirement.activeSelf == false){
            targetActivator.SetActive(true);
            this.enabled = false;
        }
    }
}