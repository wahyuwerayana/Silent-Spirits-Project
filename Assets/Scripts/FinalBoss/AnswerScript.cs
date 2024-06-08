using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{

    public bool isCorrect = false;
    public QuizManager quizManager;
    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.ReduceEnemyHealth(-25);
            quizManager.correct();

        }
        else
        {
            Debug.Log("Wrong Answer");
            quizManager.ReducePlayerHealth(-25); // Kurangi health player
            quizManager.Wrong();
            
        }

    }
}
