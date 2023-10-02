using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BoatTravelManager : MonoBehaviour
{
    public int lives = 3;
    public GameObject livesText;
    public GameObject boat;
    public GameObject winText;
    public GameObject _winText;

    public AudioSource winSound;
    public AudioSource loseSound;
    private bool soundPlayed = false;

    public bool hasWon = false;

    public int[] money = { 30, 60, 90 };
    private bool moneyAdded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        livesText.GetComponent<TextMeshProUGUI>().text = lives.ToString();
        if (lives <= 0)
        {
            boat.SetActive(false);
            winText.SetActive(true);
            _winText.GetComponent<Text>().text = "YOU LOSE!\n\n\nYou ran out of lives!\nYou earned 0 stars!\nYou earned $0!";
            if (!soundPlayed)
            {
                loseSound.Play();
                soundPlayed = true;
            }
        }

        if (hasWon)
        {
            if (!moneyAdded)
            {
                moneyAdded = CurrencyManager.UpdateCurrency(money[lives - 1]);
            }

            _winText.GetComponent<Text>().text = "YOU WIN!!\n\n\nYou finished with " + lives + " lives!\nYou earned " + lives + " star(s)!\nYou earned $" + money[lives - 1] +"!";
            if (!soundPlayed)
            {
                winSound.Play();
                soundPlayed = true;
            }
        }
    }
}
