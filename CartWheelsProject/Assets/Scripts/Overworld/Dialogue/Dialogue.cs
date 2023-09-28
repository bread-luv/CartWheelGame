using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public string _name;
    public string[] text;

    public GameObject nameObj;
    public GameObject textObj;

    public int dialoguePos = 0;

    void Start()
    {
        nameObj.GetComponent<TextMeshProUGUI>().text = _name;
        textObj.GetComponent<TextMeshProUGUI>().text = text[0];
    }

    private void Update()
    {
        nameObj.GetComponent<TextMeshProUGUI>().text = _name;
        if (dialoguePos == text.Length)
        {
            gameObject.SetActive(false);
        }
        else
        {
            textObj.GetComponent<TextMeshProUGUI>().text = text[dialoguePos];
        }
    }
}
