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
    private int Randint;

    [SerializeField]
    public static int totalCorrectAnimals = 3;

    public int maxScore = 3;
    public GameObject scoreLabel;

    public GameObject Score;
    public GameObject winText;
    public GameObject _winText;
    public GameObject _Animals;

    public AudioClip winSound;
    public AudioClip loseSound;
    private bool soundPlayed;

    private int old_score;
    private int currentAnimalVal = 0;

    public AudioSource sound_source;
    public AudioClip correct_sound;
    public AudioClip incorrect_sound;

    // Start is called before the first frame update
    void Start()
    {
        animalStorage = ShuffleArray(animalStorage);
        randomAnimal(0);
    }
    void randomAnimal(int _i)
    {
        //Randint = Random.Range(0, animalStorage.Length);
        currentAnimals = animalStorage[_i].gameObject;
        totalAnimals = currentAnimals.transform.childCount;
        Animals = new GameObject[totalAnimals];

        for (int i = 0; i < Animals.Length; i++)
        {
            Animals[i] = animalStorage[_i].transform.GetChild(i).gameObject;
        }

        currentAnimals.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (currentAnimalVal == maxScore)
        {
            if (scoreLabel.GetComponent<ScoreScript>().currentScore == 0)
            {
                Lose();
            }
            else
            {
                winText.SetActive(true);
                stars = scoreLabel.GetComponent<ScoreScript>().currentScore;
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
        }

        if (scoreLabel.GetComponent<ScoreScript>().currentScore < old_score)
        {
            sound_source.PlayOneShot(incorrect_sound);
            scoreLabel.GetComponent<ScoreScript>().currentScore += 1;
            currentAnimalVal += 1;
            Incorrect();
            old_score = scoreLabel.GetComponent<ScoreScript>().currentScore;
        }
        else if (scoreLabel.GetComponent<ScoreScript>().currentScore > old_score)
        {
            sound_source.PlayOneShot(correct_sound);
            currentAnimalVal += 1;
            Incorrect();
            old_score = scoreLabel.GetComponent<ScoreScript>().currentScore;
        }
    }

    public void Lose()
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

    void Incorrect()
    {
        currentAnimals.gameObject.SetActive(false);
        randomAnimal(currentAnimalVal);
    }

    public static void CorrectPosition()
    {
        totalCorrectAnimals += 1;
    }

    GameObject[] ShuffleArray(GameObject[] array)
    {
        for (int i = array.Length; i > 0; i--)
        {
            int j = Random.Range(0, i);
            GameObject k = array[j];
            array[j] = array[i - 1];
            array[i - 1] = k;
        }
        return array;
    }
}