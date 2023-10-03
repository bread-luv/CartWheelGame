using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    //public int lives = 3;

    [SerializeField]
    TextMeshProUGUI LifeCounter;

    // Start is called before the first frame update
    void Start()
    {
        LifeCounter = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        LifeCounter.text = StallManager.lives.ToString();
    }
}