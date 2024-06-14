using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CodeChecker : MonoBehaviour
{
    private int code1ans = 5, code2ans = 27, code3ans = 3;
    public TMP_InputField codefield1, codefield2, codefield3;
    public GroundFall groundFall;
    public GameObject CodeCanvas;
    
    public void checkAns(){
        bool isParsed1 = int.TryParse(codefield1.text, out int code1);
        bool isParsed2 = int.TryParse(codefield2.text, out int code2);
        bool isParsed3 = int.TryParse(codefield3.text, out int code3);

        if(isParsed1 && isParsed2 && isParsed3){
            if(code1 == code1ans && code2 == code2ans && code3 == code3ans){
                groundFall.enabled = true;
                CodeCanvas.SetActive(false);
            } 
        } 
    }
    
}