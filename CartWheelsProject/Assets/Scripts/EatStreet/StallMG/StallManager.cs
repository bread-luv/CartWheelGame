using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StallManager : MonoBehaviour
{
    public int lives = 3;
    private int stars = 0;
    public int count = 0;
    private bool complete = false;

    public GameObject winText;
    public GameObject _text;

    public GameObject[] items;

    public int[] money = { 35, 70, 105 };
    private bool moneyAdded = false;

    public AudioClip winSound;
    public AudioClip loseSound;
    private bool soundPlayed;

    // Update is called once per frame
    void Update()
    {
        complete = true;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].activeSelf)
            {
                complete = false;
                break;
            }
        }

        if (complete == true)
        {
            stars = lives;

            if (stars > 0 && !moneyAdded)
            {
                moneyAdded = CurrencyManager.UpdateCurrency(money[stars - 1]);
                gameObject.GetComponent<AudioSource>().PlayOneShot(winSound);
                _text.GetComponent<Text>().text = "";

                winText.SetActive(true);
                _text.GetComponent<Text>().text = "YOU WIN!\n\n\nYou finished with " + lives + " life/lives!\nYou earned " + stars + " star(s)!\nYou earned $" + money[stars - 1] + "!";
                if (PlayerPrefs.GetInt("ES_13_Stars") < stars)
                {
                    SavingLoading.ES_13_Stars = stars;
                }
                SavingLoading.saveGame();
            }
            else if (stars <= 0)
            {
                winText.SetActive(true);
                _text.GetComponent<Text>().text = "YOU LOSE!\n\n\nYou lost all you lives!\nYou earned 0 stars!\nYou earned $0!";

                if (!soundPlayed)
                {
                    gameObject.GetComponent<AudioSource>().PlayOneShot(loseSound);
                    soundPlayed = true;
                }
            }
        }
    }
}