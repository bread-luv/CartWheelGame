using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class ShoppingMGManager : MonoBehaviour
{
    private float timer = 0;
    private double timeAccel = 0;
    private int side = 1;

    public int oneStar = 50;
    public int twoStar = 75;
    public int threeStar = 100;
    private int stars = 0;

    public Sprite[] items;
    public GameObject trolley;
    public GameObject terrain;

    public GameObject scoreText;
    public GameObject livesText;
    public GameObject winText;
    public GameObject _winText;

    public AudioClip correctSound;
    public AudioClip incorrectSound;
    public AudioClip winSound;
    public AudioClip loseSound;
    private bool soundPlayed;

    public int lives = 3;
    public int score = 0;

    public int[] money = { 25, 50, 75 };
    private bool moneyAdded = false;

    public AudioSource sound_source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
        livesText.GetComponent<TextMeshProUGUI>().text = lives.ToString();

        if (lives <= 0)
        {
            winText.SetActive(true);
            if (score >= oneStar)
            {

                if (score < twoStar)
                {
                    stars = 1;
                }
                else if (score >= twoStar && score < threeStar)
                {
                    stars = 2;
                }
                else if (score >= threeStar)
                {
                    stars = 3;
                }

                if (stars > 0 && !moneyAdded)
                {
                    moneyAdded = CurrencyManager.UpdateCurrency(money[stars - 1]);
                    gameObject.GetComponent<AudioSource>().PlayOneShot(winSound);
                }

                _winText.GetComponent<Text>().text = "YOU WIN!\n\n\nYou got " + score + " items!\nYou earned " + stars + " star(s)!\nYou earned $" + money[stars - 1] + "!";
                if (PlayerPrefs.GetInt("SB_11_Stars") < stars)
                {
                    SavingLoading.SB_11_Stars = stars;
                }
                SavingLoading.saveGame();
            }
            else
            {
                _winText.GetComponent<Text>().text = "YOU LOSE!\n\n\nYou only got " + score + " item(s)!\nYou earned 0 stars!\nYou earned $0!";
                if (!soundPlayed)
                {
                    gameObject.GetComponent<AudioSource>().PlayOneShot(loseSound);
                    soundPlayed = true;
                }
            }

            livesText.GetComponent<TextMeshProUGUI>().text = "0";
            trolley.SetActive(false);
        }
        else
        {
            timer += Time.deltaTime;
            if (timeAccel < 1.8)
            {
                timeAccel += Time.deltaTime / 60;
            }
            Debug.Log(timeAccel);

            if (timer > 2 - timeAccel)
            {
                createRandomItem();
                timer = 0;
            }
        }
    }

    private int randomBoolean()
    {
        if (Random.value >= 0.5)
        {
            return 1;
        }
        return -1;
    }

    private void createRandomItem()
    {
        side = randomBoolean();

        GameObject item = new GameObject("Item");
        item.AddComponent<ItemFly>();
        item.AddComponent<SpriteRenderer>();
        item.AddComponent<Rigidbody>();
        item.AddComponent<BoxCollider>();

        item.GetComponent<ItemFly>().side = side;
        item.GetComponent<ItemFly>().speed = Random.Range(2, 15);
        item.GetComponent<ItemFly>().height = Random.Range(2, 6);
        item.GetComponent<ItemFly>().trolley = trolley;
        item.GetComponent<ItemFly>().terrain = terrain;
        item.GetComponent<ItemFly>().manager = gameObject;
        item.GetComponent<ItemFly>().correctSound = correctSound;
        item.GetComponent<ItemFly>().incorrectSound = incorrectSound;

        item.GetComponent<SpriteRenderer>().sprite = items[Random.Range(0, items.Length)];

        item.GetComponent<Rigidbody>().mass = 1;

        item.GetComponent<BoxCollider>().size = new Vector3(1, 1, 30);
        item.GetComponent<BoxCollider>().center = new Vector3(item.transform.position.x, item.transform.position.y, item.transform.position.z);



        if (side == -1)
        {
            item.transform.position = new Vector3(10, 8.21f, 2.14f);

        }
        else
        {
            item.transform.position = new Vector3(-10, 8.21f, 2.14f);
        }
    }
}
