using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinText : MonoBehaviour
{
    public string item;

    [SerializeField]
    public GameObject textObj;

    private void Update()
    {
        textObj.GetComponent<Text>().text = "YOU WIN!\n\n\n" + "You got " + QuizManager.score + "/" + QuizManager.noQuestions + " " + item + " correct!\n" +
            "You earned " + QuizManager.stars + " star(s)!\n" + "You earned $" + QuizManager.money[QuizManager.stars - 1] + "!";
    }
}
