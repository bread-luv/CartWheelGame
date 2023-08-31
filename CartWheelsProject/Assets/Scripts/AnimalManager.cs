using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public GameObject[] animalStorage;
    public GameObject[] Animals;
    public static int maxScore = 1;
    public GameObject scoreLabel;

    public GameObject Score;
    public GameObject RandomText;
    public GameObject RandomText2;
    public GameObject _Animals;

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
            Score.SetActive(false);
            RandomText.SetActive(true);
            _Animals.SetActive(false);
        }
        else if (scoreLabel.GetComponent<ScoreScript>().currentScore < 0)
        {
            Incorrect();
        }
    }

    public void Incorrect()
    {
        Score.SetActive(false);
        RandomText2.SetActive(true);
        _Animals.SetActive(false);
    }

    public static void CorrectPosition()
    {
        totalCorrectAnimals += 1;

    }
}
