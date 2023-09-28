using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StarsScript : MonoBehaviour
{

    //public static int stars = IbisMGManager.stars;

    [SerializeField]
    TextMeshProUGUI _stars;

    // Start is called before the first frame update
    void Start()
    {
        _stars = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _stars.text = "You got " + IbisMGManager.stars + " star(s)!";
    }
}