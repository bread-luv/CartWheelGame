using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    //public int lives = 3;
    public GameObject manager;
    [SerializeField]
    TextMeshProUGUI LifeCounter;

    // Start is called before the first frame update
    void Start()
    {
        LifeCounter = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        LifeCounter.text = manager.GetComponent<StallManager>().lives.ToString();
    }
}