using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickObject : MonoBehaviour
{

    public bool isCorrect;
    public GameObject scoreLabel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        if (isCorrect)
        {
            scoreLabel.GetComponent<ScoreScript>().currentScore += 1;
        }
        else
        {
            scoreLabel.GetComponent<ScoreScript>().currentScore -= 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
