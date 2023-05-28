using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinText : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI textObj;

    void Start()
    {
        textObj = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textObj.text = "YOU GOT " + QuizManager.score + "/" + QuizManager.noQuestions + " PLANTS CORRECT!";
    }
}
