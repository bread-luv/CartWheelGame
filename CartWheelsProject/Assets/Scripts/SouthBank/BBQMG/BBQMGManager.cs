using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BBQMGManager : MonoBehaviour
{
    public float seconds = 30;
    public float minutes = 2;

    public int burgerScore = 0;
    public int prawnScore = 0;
    public int waterScore = 0;

    public int burgerReq = 10;
    public int prawnReq = 10;
    public int waterReq = 30;

    public int threeStarTime = 55;
    public int twoStarTime = 30;
    public int stars = 0;

    public GameObject timeText;
    public GameObject burgerText;
    public GameObject prawnText;
    public GameObject waterText;
    public GameObject boxes;

    public GameObject winText;

    private int[] oldScores = {0, 0, 0};

    // Update is called once per frame
    void Update()
    {
        timeText.GetComponent<TextMeshProUGUI>().text = minutes.ToString("F0") + ":" + ((seconds < 10) ? ("0") : ("")) + seconds.ToString("F0");

        burgerText.GetComponent<TextMeshProUGUI>().text = "Burgers: " + burgerScore + "/" + burgerReq;
        prawnText.GetComponent<TextMeshProUGUI>().text = "Prawns: " + prawnScore + "/" + prawnReq;
        waterText.GetComponent<TextMeshProUGUI>().text = "Water: " + waterScore + "/" + waterReq;

        if (!finished())
        {
            if (seconds < 0 && minutes <= 0)
            {
                burgerScore = oldScores[0];
                prawnScore = oldScores[1];
                waterScore = oldScores[2];
                boxes.SetActive(false);
                timeText.GetComponent<TextMeshProUGUI>().text = "0:00";
                winText.SetActive(true);
                winText.GetComponent<TextMeshProUGUI>().text = "OUT OF TIME!\nYou did not prepare enough items.";
            }
            else
            {
                timer();
                oldScores[0] = burgerScore;
                oldScores[1] = prawnScore;
                oldScores[2] = waterScore;
            }
        }
        else
        {
            burgerScore = oldScores[0];
            prawnScore = oldScores[1];
            waterScore = oldScores[2];

            if (seconds >= threeStarTime || minutes >= 1)
            {
                stars = 3;
            }
            else if (seconds >= twoStarTime || minutes >= 1)
            {
                stars = 2;
            }
            else if (seconds >= 0 || minutes >= 1)
            {
                stars = 1;
            }

            boxes.SetActive(false);
            winText.SetActive(true);
            winText.GetComponent<TextMeshProUGUI>().text = "YOU WIN!\nYou got " + stars + " star(s)!";
        }
    }

    private void timer()
    {
        seconds -= Time.deltaTime;

        if (minutes > 0 && seconds < 0)
        {
            seconds = 59;
            minutes -= 1;
        }
    }

    private bool finished()
    {
        if (burgerScore >= burgerReq && prawnScore >= prawnReq && waterScore >= waterReq)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
