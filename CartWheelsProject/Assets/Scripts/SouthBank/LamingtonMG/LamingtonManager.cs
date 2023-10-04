using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LamingtonManager : MonoBehaviour
{
    public int mashCounter = 0;
    public GameObject[] Ingredients;
    public GameObject[] Ingredients2;
    public GameObject[] Ingredients3;
    public GameObject Debugtext;
    public GameObject MashButton;
    private int phase = 1;
    private int stars = 3;

    public GameObject winText;
    public Text _winText;

    public int[] money = { 25, 50, 75 };
    private bool moneyAdded = false;

    public AudioClip winSound;
    public AudioClip loseSound;
    private bool soundPlayed;

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
                    Debugtext.GetComponent<TextMeshProUGUI>().text = "Add the Ingredients to the Bowl!";
                    phase = 1;
                    break;
                }

            }
        }

        if (phase == 2)
        {
            Debugtext.GetComponent<TextMeshProUGUI>().text = "Hit the Button to mix the ingredients!";
            MashButton.SetActive(true);
            phase = 3;
            if (mashCounter < 10)
            {
                phase = 2;
            }
            else
            {
                phase = 10;
                mashCounter = 0;
            }

        }

        if (phase == 10)
        {
            for (int i = 0; i < Ingredients2.Length; i++)
            {
                Ingredients2[i].SetActive(true);
                
            }
            phase = 3;
        }

        if (phase == 3)
        {
            Debugtext.GetComponent<TextMeshProUGUI>().text = "Add Icing and the Lamingtons to the Bowl!";
            MashButton.SetActive(false);
            phase = 4;
            for (int i = 0; i < Ingredients2.Length; i++)
            {

                if (Ingredients2[i].activeSelf)
                {
                    
                    phase = 3;
                    break;
                }

            }

        }
        if (phase == 4)
        {
            Debugtext.GetComponent<TextMeshProUGUI>().text = "Hit the Button to add the Icing to the Lamingtons!";
            MashButton.SetActive(true);
            phase = 5;

            if (mashCounter < 10)
            {
                phase = 4;
                

            }
            else
            {
                phase = 11;
                mashCounter = 0;
            }

        }
        if (phase == 11)
        {
            for (int i = 0; i < Ingredients3.Length; i++)
            {
                Ingredients3[i].SetActive(true);
            }
            phase = 5;
            
        }

        if (phase == 5)
        {
            MashButton.SetActive(false);
            Debugtext.GetComponent<TextMeshProUGUI>().text = "Add the Lamingtons to the Bowl of Coconut!";
            phase = 6;
            for (int i = 0; i < Ingredients3.Length; i++)
            {

                if (Ingredients3[i].activeSelf)
                {
                    
                    phase = 5;
                    break;
                }

            }

        }
        if (phase == 6)
        {
            Debugtext.SetActive(false);
            if (stars > 0 && !moneyAdded)
            {
                moneyAdded = CurrencyManager.UpdateCurrency(money[stars - 1]);
                gameObject.GetComponent<AudioSource>().PlayOneShot(winSound);
                if (PlayerPrefs.GetInt("SB_13_Stars") < stars)
                {
                    SavingLoading.SB_13_Stars = stars;
                }
                SavingLoading.saveGame();
            }

            winText.SetActive(true);
            _winText.text = "YOU WIN!\n\n\nYou made the lamingtons!\nYou earned " + stars + " star(s)!\nYou earned $" + money[stars - 1] + "!";

            if (stars <= 0 && !soundPlayed)
            {
                _winText.text = "YOU LOSE!\n\n\nYou failed to make the lamingtons!\nYou earned 0 stars!\nYou earned $0!";
                gameObject.GetComponent<AudioSource>().PlayOneShot(loseSound);
                soundPlayed = true;
            }
        }
    }
}
