using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseLife : MonoBehaviour
{
    public GameObject[] collideWith;

    // Update is called once per frame
    void OnTriggerEnter(Collider collide)
    {
        for (int i = 0; i < collideWith.Length; i++)
        {
            if (collide.gameObject == collideWith[i])
            {
                IbisMGManager.lives -= 1;
            }
        }
    }
}
