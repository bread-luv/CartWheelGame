using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StallManager : MonoBehaviour
{
    public static int lives = 3;
    public static int stars = 0;
    public static int count = 0;
    public static bool status = true;
    // Start is called before the first frame update
    private void Start()
    {
        lives = 3;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= 3)
        {
            switch (lives)
            {
                case 1:
                    stars = 1;
                    status = false;
                    break;
                case 2:
                    stars = 2;
                    status = false;
                    break;
                case 3:
                    stars = 3;
                    status = false;
                    break;
            }
        }
        else if (lives <= 0)
        {
            stars = 0;
            status = false;
        }
    }

}
