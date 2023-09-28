using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MeatPieManager : MonoBehaviour
{
    public GameObject[] screenText;
    public GameObject pie;

    public int score = 0;

    public int stars = 0;
    public int noPies = 30;

    public int noDispense1 = 3;
    public int noDispense2 = 2;
    public int noDispense3 = 2;

    private int value1 = 0;
    private int value2 = 0;
    private int value3 = 0;

    public string[] value1Str;
    public string[] value2Str;
    public string[] value3Str;

    public GameObject scoreText;

    public GameObject[] setActive;
    public GameObject[] setInactive;

    private int currentPie = 1;

    public GameObject winText;

    public int[] money = { 40, 80, 120 };
    private bool moneyAdded = false;

    // Start is called before the first frame update
    void Start()
    {
        value1 = Random.Range(1, noDispense1+1);
        value2 = Random.Range(1, noDispense2+1);
        value3 = Random.Range(1, noDispense3+1);

        scoreText.GetComponent<TextMeshProUGUI>().text = score + "/" + noPies;
    }

    // Update is called once per frame
    void Update()
    {
        screenText[0].GetComponent<Text>().text = value1Str[value1-1];
        screenText[1].GetComponent<Text>().text = value2Str[value2-1];
        screenText[2].GetComponent<Text>().text = value3Str[value3-1];

        

        if (pie.transform.position.x >= 6)
        {
            if (pie.GetComponent<PieMovement>().values[0] == value1 &&
                pie.GetComponent<PieMovement>().values[1] == value2 &&
                pie.GetComponent<PieMovement>().values[2] == value3)
            {
                score++;
                scoreText.GetComponent<TextMeshProUGUI>().text = score + "/" + noPies;
            }
            pie.GetComponent<PieMovement>().values[0] = 0;
            pie.GetComponent<PieMovement>().values[1] = 0;
            pie.GetComponent<PieMovement>().values[2] = 0;

            currentPie++;

            value1 = Random.Range(1, noDispense1 + 1);
            value2 = Random.Range(1, noDispense2 + 1);
            value3 = Random.Range(1, noDispense3 + 1);

            pie.transform.position = new Vector3(-7, pie.transform.position.y, pie.transform.position.z);
        }

        if (currentPie > noPies)
        {
            stars = score;// / 10;

            if (stars > 0 && !moneyAdded)
            {
                moneyAdded = CurrencyManager.UpdateCurrency(money[stars - 1]);
            }

            if (stars > 0)
            {
                winText.GetComponent<Text>().text = "YOU WIN!\n\n\nYou got " + score + " pies correct!\nYou earned " + stars + " star(s)!\nYou earned $" + money[stars - 1] + "!";
            }
            else
            {
                winText.GetComponent<Text>().text = "YOU LOSE!\n\n\nYou got 0 pies correct!\nYou earned 0 star(s)!\nYou earned $0!";
            }

            foreach (GameObject i in setActive)
            {
                i.SetActive(true);
            }
            foreach (GameObject j in setInactive)
            {
                j.SetActive(false);
            }
        }

    }
}
