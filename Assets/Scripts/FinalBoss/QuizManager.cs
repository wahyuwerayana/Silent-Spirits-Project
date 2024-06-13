using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public Image QuestionImage;

    public HealthBarScript playerHealthBar;
    public HealthBarScript EnemyHealthBar;
    public GameObject quizCanvas;
    [SerializeField] GameObject _CanvasTrigger;
    [SerializeField] Animator Boss;
    [SerializeField] GameObject bossGameObject;
    [SerializeField] float bossDieAnimationDuration = 2f;

    private void Start()
    {
        playerHealthBar.OnHealthZero += OnPlayerHealthZero;
        EnemyHealthBar.OnHealthZero += OnEnemyHealthZero;

        generateQuestion();
    }

    private void OnDestroy()
    {
        playerHealthBar.OnHealthZero -= OnPlayerHealthZero;
        EnemyHealthBar.OnHealthZero -= OnEnemyHealthZero;
    }

    private void OnPlayerHealthZero()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnEnemyHealthZero()
    {
        quizCanvas.SetActive(false);
        _CanvasTrigger.SetActive(false);

        var playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }

        if (Boss != null)
        {
            Boss.SetTrigger("Die");
            StartCoroutine(DestroyBossAfterAnimation());
        }
        
    }

    private IEnumerator DestroyBossAfterAnimation()
    {
        yield return new WaitForSeconds(bossDieAnimationDuration);
        Destroy(bossGameObject);
    }

    public void correct()
    {
        if (Boss != null)
        {
            Boss.SetTrigger("Hurt"); 
        }
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void Wrong()
    {
        if (Boss != null)
        {
            Boss.SetTrigger("Attack");
        }
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
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
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionImage.sprite = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Question");
        }
    }
}
