using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimalManager : MonoBehaviour
{
    private bool moneyAdded = false;
    private int stars = 0;
    public int[] money = { 15, 30, 45 };
    public static int j = 0;

    public GameObject[] animalStorage;
    public GameObject[] Animals;
    private GameObject currentAnimals;

    [SerializeField]
    public static int totalAnimals = 0;
    //public static int totalAnimals = 1;
    private int Randint;

    [SerializeField]
    public static int totalCorrectAnimals = 1;
    //public int totalCorrectAnimals = 0;

    public int maxScore = 1;
    public GameObject scoreLabel;

    public GameObject Score;
    public GameObject winText;
    public GameObject _winText;
    public GameObject _Animals;

    public AudioClip winSound;
    public AudioClip loseSound;
    private bool soundPlayed;


    // Start is called before the first frame update
    void Start()
    {
        Randint = Random.Range(0, animalStorage.Length);

        currentAnimals = animalStorage[Randint].gameObject;

        totalAnimals = currentAnimals.transform.childCount;

        Animals = new GameObject[totalAnimals];

        for (int i = 0; i < Animals.Length; i++)
        {
            Animals[i] = animalStorage[Randint].transform.GetChild(i).gameObject;
        }

        currentAnimals.gameObject.SetActive(true);
    }

    private void Update()
    {
        //for (j = 0; j < 3; j++)
        //{
            //if (scoreLabel.GetComponent<ScoreScript>().currentScore == maxScore && j < 3)
            //{
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //break;
            //}
            if (scoreLabel.GetComponent<ScoreScript>().currentScore == maxScore)
            {
                winText.SetActive(true);
                stars = 3;
                _winText.GetComponent<Text>().text = "YOU WIN!\n\n\nYou got " + scoreLabel.GetComponent<ScoreScript>().currentScore + " animals correct!\n You earned " + stars + " star(s)!\nYou earned $" + money[stars - 1] + "!";

                if (!moneyAdded && stars > 0)
                {
                    if (PlayerPrefs.GetInt("BG_11_Stars") < stars)
                    {
                        SavingLoading.BG_11_Stars = stars;
                    }
                    SavingLoading.saveGame();
                    moneyAdded = CurrencyManager.UpdateCurrency(money[stars - 1]);
                    gameObject.GetComponent<AudioSource>().PlayOneShot(winSound);
                }
                _Animals.SetActive(false);
            }
            else if (scoreLabel.GetComponent<ScoreScript>().currentScore < 0)
            {
                Incorrect();
            }
        //}
    }

    public void Incorrect()
    {
        winText.SetActive(true);
        _winText.GetComponent<Text>().text = "YOU LOSE!\n\n\nYou got 0 animals correct!\n You earned 0 stars!\nYou earned $0!";
        if (!soundPlayed)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(loseSound);
            soundPlayed = true;
        }
        _Animals.SetActive(false);
    }

    public static void CorrectPosition()
    {
        totalCorrectAnimals += 1;

    }
}
