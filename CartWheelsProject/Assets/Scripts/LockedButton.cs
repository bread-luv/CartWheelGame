using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedButton : MonoBehaviour
{
    private int totalStars;
    public int starRequirement = 0;
    public Text requirementText;

    // Start is called before the first frame update
    void Start()
    {
        totalStars = SavingLoading.totalStars();
        if (totalStars < starRequirement)
        {
            gameObject.GetComponent<Button>().interactable = false;
            requirementText.text = starRequirement + " stars required";
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(SavingLoading.totalStars());
    }
}
