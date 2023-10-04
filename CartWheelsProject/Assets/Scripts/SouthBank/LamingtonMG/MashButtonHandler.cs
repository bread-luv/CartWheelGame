using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MashButtonHandler : MonoBehaviour
{
    public GameObject Debugtext2;
    public void MashCounter()
    {
        LamingtonManager.mashCounter++;
        Debugtext2.GetComponent<TextMeshProUGUI>().text = "" + LamingtonManager.mashCounter;
    }
}
