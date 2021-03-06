using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject GoPanel;

    public Text QuestionTxt;
    public Text ScoreTxt;

    //modification
    public Text TotalQ;


    int totalQuestions = 0;
    public int score;

    private void Start()
    {
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        // ScoreTxt.text = score + "/" + totalQuestions;
        ScoreTxt.text = score.ToString();
        TotalQ.text = totalQuestions.ToString();
    }

    public void correct()
    {
        //when you are right
        score += 1;
        //jai mis sa
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
        // StartCoroutine(waitForNext());
    }

    public void wrong()
    {
        //when you answer wrong
        QnA.RemoveAt(currentQuestion);
        generateQuestion();

        // StartCoroutine(waitForNext());
    }
   
    // IEnumerator waitForNext()
    // {
    //     yield return new WaitForSeconds(1);
    //     generateQuestion();
    // }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            // options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].GetComponentInChildren<Text>().text = QnA[currentQuestion].Answers[i];
            
            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }  
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
            Debug.Log("Out of Questions");
            GameOver();
        }


        //jai mis
        //  currentQuestion = Random.Range(0, QnA.Count);

        //     QuestionTxt.text = QnA[currentQuestion].Question;  
        //     SetAnswers();
    }
}
