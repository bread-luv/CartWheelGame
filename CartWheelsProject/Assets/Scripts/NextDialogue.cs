using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDialogue : MonoBehaviour
{
    public GameObject dialogue;

    public void next()
    {
        dialogue.GetComponent<Dialogue>().dialoguePos += 1;
    }
}
