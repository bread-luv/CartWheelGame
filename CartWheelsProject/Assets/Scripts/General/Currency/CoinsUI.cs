using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsUI : MonoBehaviour
{
    private Text text;
    public GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        //text = gameObject.GetComponent<Text>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (text != null)
        {
            string[] temp = text.text.Split('$');
            text.text = temp[0] + "$" + CurrencyManager.currency;
        }
    }
}