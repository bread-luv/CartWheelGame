using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public GameObject otherButton;
    public bool isCorrect;
    public string option;

    public AudioClip correctSound;
    public AudioClip incorrectSound;

    public void Answer()
    {
        if (isCorrect)
        {
            if (QuizManager.score < QuizManager.noQuestions)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(correctSound);
                QuizManager.score += 1;
            }            
        }
        else
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(incorrectSound);
        }

        if (Random.value < .5)
        {
            if (isCorrect)
            { isCorrect = false; otherButton.GetComponent<AnswerScript>().isCorrect = true; }
            else
            { isCorrect = true; otherButton.GetComponent<AnswerScript>().isCorrect = false; }

        }

        QuizManager.currentQuestion += 1;
    }
}