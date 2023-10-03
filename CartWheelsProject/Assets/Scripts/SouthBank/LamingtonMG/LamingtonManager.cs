using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LamingtonManager : MonoBehaviour
{
    public static int mashCounter = 0;
    public GameObject[] Ingredients;
    public GameObject Debugtext;
    public GameObject MashButton;
    private int phase = 1;
    //private bool phasecomplete = false;
    // Start is called before the first frame update
    //public void MashCounter(string yes)
    //{
        //mashCounter++;
    //}
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (phase == 1)
        {
            phase = 2;
            for (int i = 0; i < Ingredients.Length; i++)
            {
             
                if (Ingredients[i].activeSelf)
                {
                    Debugtext.GetComponent<TextMeshProUGUI>().text = "no phase 2";
                    phase = 1;
                    break;
                }
                
            }
        }
        if (phase == 2)
        {   
            Debugtext.GetComponent<TextMeshProUGUI>().text = "no phase 3";
            MashButton.SetActive(true);
            phase = 3;
            if (mashCounter < 10)
            {
                phase = 2;
                Debugtext.GetComponent<TextMeshProUGUI>().text = "phase 3";
               
            }
            else
            {
                phase = 3;
            }
            
        }
        if (phase == 3)
        {
            Debugtext.GetComponent<TextMeshProUGUI>().text = "phase 3 confirmed";
            MashButton.SetActive(false);
        }
    }
}
