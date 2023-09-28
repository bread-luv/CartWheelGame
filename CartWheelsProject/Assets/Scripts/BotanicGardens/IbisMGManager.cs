using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IbisMGManager : MonoBehaviour
{
    public static int lives = 3;
    public static int stars = 0;
    public GameObject[] toActiveLoss;
    public GameObject[] toActiveWin;
    public GameObject[] toInactiveLoss;
    public GameObject[] toInactiveWin;
    public GameObject[] rubbish;
    public static bool started = false;

    private void Start()
    {
        lives = 3;
        started = false;
    }

    private void Update()
    {
        if (lives <= 0)
        {
            for (int i = 0; i < toActiveLoss.Length; i++)
            {
                toActiveLoss[i].SetActive(true);
            }

            for (int i = 0; i < toInactiveLoss.Length; i++)
            {
                toInactiveLoss[i].SetActive(false);
            }
        }
        else if (started == true)
        {
            bool complete = true;
            for (int i = 0; i < rubbish.Length; i++)
            {
                if (rubbish[i].activeSelf)
                {
                    complete = false;
                    break;
                }
            }

            if (complete)
            {
                switch(lives)
                {
                    case 1:
                        stars = 1;
                        break;
                    case 2:
                        stars = 2;
                        break;
                    case 3:
                        stars = 3;
                        break;
                }

                for (int i = 0; i < toActiveWin.Length; i++)
                {
                    toActiveWin[i].SetActive(true);
                }
                for (int i = 0; i < toInactiveWin.Length; i++)
                {
                    toInactiveWin[i].SetActive(false);
                }
            }
        }
    }
}
