using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantScore : MonoBehaviour
{

    public static int currentScore = 0;
    public static int totalScore;

    [SerializeField]
    TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
        totalScore = QuizManager.noQuestions;
    }

    // Update is called once per frame
    void Update()
    {
        currentScore = QuizManager.score;
        score.text = currentScore + "/" + totalScore;
    }
}