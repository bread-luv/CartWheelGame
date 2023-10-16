using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedButton : MonoBehaviour
{
    private int totalStars;
    public int starRequirement = 0;
    
    public Text requirementText;
    public bool requiresLevel;
    public string levelRequirement;
    public string levelName;

    // Start is called before the first frame update
    void Start()
    {
        totalStars = SavingLoading.totalStars();
        if (requiresLevel)
        {
            int level_stars = PlayerPrefs.GetInt(levelRequirement);


            if (level_stars == 0)
            {
                gameObject.GetComponent<Button>().interactable = false;
                requirementText.text = "Must complete " + levelName + " game";
            }
        }
        else
        {
            if (totalStars < starRequirement)
            {
                gameObject.GetComponent<Button>().interactable = false;
                requirementText.text = starRequirement + " stars required";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(SavingLoading.totalStars());
    }
}
