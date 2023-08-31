using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MeatPieManager : MonoBehaviour
{
    public GameObject[] screenText;
    public GameObject pie;

    public static int score = 0;

    public static int stars = 0;
    public static int noPies = 30;

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
                Debug.Log(scoreText.GetComponent<TextMeshProUGUI>().text);
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
