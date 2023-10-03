using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{

    //public static int stars = IbisMGManager.stars;

    [SerializeField]
    TextMeshProUGUI VText;

    // Start is called before the first frame update
    void Start()
    {
        VText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StallManager.status == false)
        {
            VText.text = "You got " + StallManager.stars + " star(s)!";
        }

    }
}