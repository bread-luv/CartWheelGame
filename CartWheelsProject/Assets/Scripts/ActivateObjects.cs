using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjects : MonoBehaviour
{

    public GameObject[] objects;


    public void activate()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(true);
            IbisMGManager.started = true;
            gameObject.SetActive(false);
        }
    }
}
