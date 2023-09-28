using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BoatTravelManager : MonoBehaviour
{
    public int lives = 3;
    public GameObject livesText;
    public GameObject boat;
    public GameObject failtext;
    
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
            failtext.SetActive(true);
        }
    }
}
