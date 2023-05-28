using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public static int currentScore = 0;
    public static int totalScore;

    [SerializeField]
    AnimalManager animalManager;

    //[SerializeField]
    TextMeshProUGUI score;


    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = currentScore + "/" + totalScore;
    }
}