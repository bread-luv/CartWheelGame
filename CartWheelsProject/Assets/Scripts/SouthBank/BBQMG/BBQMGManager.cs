using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public GameObject _winText;

    private int[] oldScores = {0, 0, 0};

    public int[] money = { 35, 70, 105 };
    private bool moneyAdded = false;

    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioSource audioSource;
    private bool soundPlayed;

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
                _winText.GetComponent<Text>().text = "YOU LOSE!\n\n\nYou ran out of time!\nYou earned 0 star(s)!\nYou earned $0!";
                if (!soundPlayed)
                {
                    audioSource.GetComponent<AudioSource>().PlayOneShot(loseSound);
                    soundPlayed = true;
                }
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

            if (stars > 0 && !moneyAdded)
            {
                moneyAdded = CurrencyManager.UpdateCurrency(money[stars - 1]);
                audioSource.GetComponent<AudioSource>().PlayOneShot(winSound);
            }

            boxes.SetActive(false);
            winText.SetActive(true);
            _winText.GetComponent<Text>().text = "YOU WIN!\n\n\nYou finished with " + minutes.ToString("F0") + ":" + ((seconds < 10) ? ("0") : ("")) + seconds.ToString("F0") + " left!\nYou earned " + stars + " star(s)!\nYou earned $" + money[stars - 1] + "!";
            gameObject.SetActive(false);
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
