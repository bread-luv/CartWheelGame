using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> Qna;
    public GameObject[] options;
    public int currentQuestion;
    


    [SerializeField]
    public TextMeshProUGUI QuestionTxt;
    
    private void Start()
    {
        generateQuestion();
    }
    public void correct()
    {
        Qna.RemoveAt(currentQuestion);
        //Score Increment 
      
        generateQuestion();
    }
    void setAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Qna[currentQuestion].Answers[i];
            options[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Qna[currentQuestion].sri[i]; 

            if (Qna[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }    
        }
    }

    void generateQuestion()
    {
        currentQuestion = Random.Range(0, Qna.Count);
        QuestionTxt.text = Qna[currentQuestion].Question;
        setAnswer();

        
    }

 
}
