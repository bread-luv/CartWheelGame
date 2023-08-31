using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonImage : MonoBehaviour
{
    public GameObject button;
    public Image img;
    public Sprite[] correctImages;
    public Sprite[] incorrectImages;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (button.GetComponent<AnswerScript>().isCorrect)
        {
            img.sprite = correctImages[QuizManager.currentQuestion];
        }
        else
        {
            img.sprite = incorrectImages[QuizManager.currentQuestion];
        }
    }
}
