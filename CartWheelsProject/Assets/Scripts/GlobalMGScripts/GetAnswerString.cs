using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetAnswerString : MonoBehaviour
{
    public GameObject button;
    


    [SerializeField]
    public TextMeshProUGUI textObj;

    void Start()
    {
        textObj = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (button.GetComponent<AnswerScript>().isCorrect)
        {
            textObj.text = QuizManager.currentCorrect;
        }
        else
        {
            textObj.text = QuizManager.currentIncorrect;
        }
    }
}
