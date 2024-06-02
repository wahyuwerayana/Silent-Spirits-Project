using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InteractUnlockable : MonoBehaviour {
    private bool inside = false;
    public GameObject gameObj;
    public Type scriptType;
    public string scriptName;
    public Component script;

    void Start(){
        gameObj = GameObject.Find("Game Manager");
        scriptType = Type.GetType(scriptName);
        script = gameObj.GetComponent(scriptType);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.F) && inside){
            ((MonoBehaviour)script).enabled = true;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        inside = true;
    }

    private void OnTriggerExit2D(Collider2D other){
        inside = false;
    }
}