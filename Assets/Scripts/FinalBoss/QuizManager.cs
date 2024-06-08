using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TextMeshProUGUI QuestionTxt;

    public HealthBarScript playerHealthBar; // Referensi ke health bar player
    public HealthBarScript EnemyHealthBar;

    private void Start()
    {
        generateQuestion();
    }

    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();

    }

    public void Wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }
    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent <AnswerScript>().isCorrect = true;
            }
        }
    }

    public void ReducePlayerHealth(float amount)
    {
        playerHealthBar.UpdateHealth(amount);
    }

    public void ReduceEnemyHealth(float amount)
    {
        EnemyHealthBar.UpdateHealth(amount);
    }

    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();

        }
        else
        {
            Debug.Log("Out of Question");
        }
    }

    


}
