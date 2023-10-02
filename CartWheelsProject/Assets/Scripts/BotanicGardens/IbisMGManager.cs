using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IbisMGManager : MonoBehaviour
{
    public static int lives = 3;
    private int initialLives = lives;
    public static int stars = 0;
    public GameObject[] toInactiveLoss;
    public GameObject[] toInactiveWin;
    public GameObject[] rubbish;
    public GameObject winText;
    public GameObject endText;
    public static bool started = false;
    private bool complete = false;

    public AudioClip winSound;
    public AudioClip loseSound;
    private bool soundPlayed = false;

    public int[] money = { 15, 30, 45 };
    private bool moneyAdded = false;

    private void Start()
    {
        lives = 3;
        started = false;
        stars = 0;
    }

    private void Update()
    {
        if (lives <= 0)
        {
            for (int i = 0; i < toInactiveLoss.Length; i++)
            {
                complete = true;
                toInactiveLoss[i].SetActive(false);
            }
            winText.SetActive(true);
            endText.GetComponent<Text>().text = "YOU LOST!\n\n\nYou lost all your lives!\nYour earned 0 stars!\nYou earned $0!";
            if (!soundPlayed)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(loseSound);
                soundPlayed = true;
            }
        }
        else if (started == true)
        {
            complete = true;
            for (int i = 0; i < rubbish.Length; i++)
            {
                if (rubbish[i].activeSelf)
                {
                    complete = false;
                    break;
                }
            }

            if (complete)
            {
                stars = lives;
                if (stars > 0 && !moneyAdded)
                {
                    moneyAdded = CurrencyManager.UpdateCurrency(money[stars - 1]);
                    endText.GetComponent<Text>().text = "YOU WIN!\n\n\nYou lost " + (initialLives - lives) + " life/lives!\nYou earned " + stars + " star(s)!\nYou earned $" + money[stars - 1] + "!";
                    gameObject.GetComponent<AudioSource>().PlayOneShot(winSound);
                }

                winText.SetActive(true);
                for (int i = 0; i < toInactiveWin.Length; i++)
                {
                    toInactiveWin[i].SetActive(false);
                }
            }
        }
    }
}
