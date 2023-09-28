using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoatMovement : MonoBehaviour
{
    public GameObject exit;
    public GameObject finishLine;
    public GameObject manager;
    public GameObject[] obstacles;
    public static int movementspeed = 1;
    public Vector3 userDirection = Vector3.right;
    public GameObject[] activateOnWin; //lazy option for now
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(userDirection * movementspeed * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == finishLine)
        {
            foreach (GameObject _object in activateOnWin)
            {
                _object.SetActive(true);
            }
            activateOnWin[0].GetComponent<TextMeshProUGUI>().text = "YOU WIN!!\nYou got " + manager.GetComponent<BoatTravelManager>().lives + " star(s)!";
            //exit.GetComponent<SceneLoader>().LoadScene("EatStreet");

        }

        foreach (GameObject obstacle in obstacles)
        {
            if (collision.gameObject == obstacle)
            {
                manager.GetComponent<BoatTravelManager>().lives -= 1;

            }
        }
    }
}
