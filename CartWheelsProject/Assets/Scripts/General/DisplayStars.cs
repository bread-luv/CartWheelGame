using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStars : MonoBehaviour
{
    public Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = "x " + SavingLoading.totalStars();
    }
}
