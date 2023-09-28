using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuizManager : MonoBehaviour
{
    public GameObject winText;
    public GameObject[] buttons;

    public static int noQuestions = 3;
    public static int score = 0;

    public string[] correctAnswers;
    public string[] incorrectAnswers;
    public static string[][] answers = new string[noQuestions][];

    public static int currentQuestion = 0;
    public static string currentCorrect;
    public static string currentIncorrect;
    private System.Random rand = new System.Random();
    public static int stars = 0;

    public static int[] money = { 10, 20, 30 };
    private bool moneyAdded = false;

    void Start()
    {
        score = 0;
        currentQuestion = 0;
        for (int i = 0; i < noQuestions; i++)
        {
            answers[i] = new string[2];
            answers[i][0] = correctAnswers[i];
            answers[i][1] = incorrectAnswers[i];
        }
    }

    private void Update()
    {
        if (currentQuestion < noQuestions)
        {
            currentCorrect = answers[currentQuestion][0];
            currentIncorrect = answers[currentQuestion][1];
        }
        else
        {
            stars = score;
            if (!moneyAdded)
            {
                moneyAdded = CurrencyManager.UpdateCurrency(money[stars - 1]);
            }
            winText.SetActive(true);
            for (int i = 0; i < buttons.Length; i++)
            {
                Destroy(buttons[i]);
            }
        }
    }
}
