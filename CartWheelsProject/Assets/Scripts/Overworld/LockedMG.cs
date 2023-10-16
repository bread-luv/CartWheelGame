using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedMG : MonoBehaviour
{
    public bool has_star_req;
    public bool has_level_req;

    public int star_req = 0;
    public string level_req;
    public string level_string;

    public GameObject tapToStart;
    public Text text_obj;

    // Start is called before the first frame update
    void Start()
    {
        int current_stars = SavingLoading.totalStars();
        if (has_level_req && has_level_req)
        {
            if (current_stars < star_req && PlayerPrefs.GetInt(level_req) == 0)
            {
                locked("You need " + star_req + " stars and you must complete the " + level_string + " game.");
            }
            else if (current_stars < star_req)
            {
                locked("You need " + star_req + " stars.");
            }
            else if (PlayerPrefs.GetInt(level_req) == 0)
            {
                locked("You must complete the " + level_string + " game.");
            }
        }
        else if (has_level_req && PlayerPrefs.GetInt(level_req) == 0)
        {
            locked("You must complete the " + level_string + " game.");
        }
        else if (has_star_req && current_stars < star_req)
        {
            locked("You need " + star_req + " stars.");
        }
    }

    void locked(string txt)
    {
        text_obj.text = txt;
        tapToStart.transform.position = new Vector3(10000, 10000, 10000);
    }
}