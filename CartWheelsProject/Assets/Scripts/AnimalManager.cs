using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public GameObject[] animalStorage;
    public GameObject[] Animals;
    private GameObject currentAnimals;

    [SerializeField]
    public int totalAnimals = 0;
    private int Randint;

    [SerializeField]
    public int totalCorrectAnimals = 0;

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

    public void CorrectPosition()
    {
        totalCorrectAnimals += 1;

        if (totalCorrectAnimals == totalAnimals)
        {
            ScoreScript.currentScore += 1;
            //SoundManagerScript.PlaySound("correct");

            //if (totalCorrectWires == totalWires)
            //{
                //SoundManagerScript.PlaySound("complete");
                //miniGameState.WinGame();
            //}
        }
    }
}
