using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalManager : MonoBehaviour
{
    public GameObject[] animalStorage;
    public GameObject[] Animals;
    public int maxScore = 1;
    public GameObject scoreLabel;

    public GameObject Score;
    public GameObject winText;
    public GameObject _winText;
    public GameObject _Animals;

    public AudioClip winSound;
    public AudioClip loseSound;
    private bool soundPlayed;

    private GameObject currentAnimals;

    [SerializeField]
    public static int totalAnimals = 1;
    private int Randint;

    [SerializeField]
    public static int totalCorrectAnimals = 0;

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

        ScoreScript.totalScore = 1;

        currentAnimals.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (scoreLabel.GetComponent<ScoreScript>().currentScore == maxScore)
        {
            winText.SetActive(true);
            _winText.GetComponent<Text>().text = "YOU WIN!\n\n\nYou got " + scoreLabel.GetComponent<ScoreScript>().currentScore + " animals correct!\n You earned STARS star(s)!\nYou earned $X!";
            if (!soundPlayed)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(winSound);
                soundPlayed = true;
            }
            _Animals.SetActive(false);
        }
        else if (scoreLabel.GetComponent<ScoreScript>().currentScore < 0)
        {
            Incorrect();
        }
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
