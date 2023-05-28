using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestScoreScript : MonoBehaviour
{
    public TextMeshProUGUI score;
    public int scoreValue = 0;
    public int maxScoreValue;

    public GameObject Score;
    public GameObject RandomText;
    public GameObject Animals;
    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;
    }

    public void AddScore(int newScore)
    {
        scoreValue += newScore;
    }


    public void UpdateScore()
    {
        score.text = scoreValue + "/" + maxScoreValue;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateScore();

        if(scoreValue == maxScoreValue)
        {
            Score.SetActive(false);
            RandomText.SetActive(true);
            Animals.SetActive(false);
        }
    }
}
