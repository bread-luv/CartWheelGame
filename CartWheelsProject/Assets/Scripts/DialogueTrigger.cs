using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string name;
    public string[] dialogue;
    public GameObject dialogueBox;

    void OnMouseDown()
    {
        dialogueBox.SetActive(true);
        dialogueBox.GetComponent<Dialogue>().name = name;
        dialogueBox.GetComponent<Dialogue>().text = dialogue;
        dialogueBox.GetComponent<Dialogue>().dialoguePos = 0;
    }
}
