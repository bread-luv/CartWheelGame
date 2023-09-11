using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BBQMGManager : MonoBehaviour
{
    public float seconds = 30;
    public float minutes = 0;

    public int burgerScore = 0;
    public int prawnScore = 0;
    public int waterScore = 0;

    public int burgerReq = 10;
    public int prawnReq = 10;
    public int waterReq = 10;

    public GameObject timeText;
    public GameObject burgerText;
    public GameObject prawnText;
    public GameObject waterText;

    // Update is called once per frame
    void Update()
    {
        timeText.GetComponent<TextMeshProUGUI>().text = minutes.ToString("F0") + ":" + ((seconds < 10) ? ("0") : ("")) + seconds.ToString("F0");

        burgerText.GetComponent<TextMeshProUGUI>().text = "Burgers: " + burgerScore + "/" + burgerReq;
        prawnText.GetComponent<TextMeshProUGUI>().text = "Prawns: " + prawnScore + "/" + prawnReq;
        waterText.GetComponent<TextMeshProUGUI>().text = "Water: " + waterScore + "/" + waterReq;

        timer();
    }

    private void timer()
    {
        seconds -= Time.deltaTime;

        if (minutes > 0 && seconds < 0)
        {
            minutes -= 1;
        }

        if (minutes == 0 && seconds < 0)
        {
            Debug.Log("OUT OF TIME");
        }
    }
}
