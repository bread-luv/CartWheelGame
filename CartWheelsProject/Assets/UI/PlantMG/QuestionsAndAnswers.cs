using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class QuestionsAndAnswers

{
    public string Question;
    public string[] Answers;
    public int CorrectAnswer;
    public SpriteRenderer sr;
    public Sprite[] sri;
}
