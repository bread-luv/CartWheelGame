using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjects : MonoBehaviour
{

    public GameObject[] objects;
    public GameObject[] deactivateObjects;

    public bool _activate = true;
    public bool deactivate = true;
    public bool deactivateSelf = true;

    public void activate()
    {
        for (int i = 0; i < objects.Length || i < deactivateObjects.Length; i++)
        {
            if (_activate == true)
            {
                if (objects.Length > 0 && i < objects.Length)
                {
                    objects[i].SetActive(true);
                }
            }

            if (deactivate == true)
            {
                if (deactivateObjects.Length > 0 && i < deactivateObjects.Length)
                {
                    deactivateObjects[i].SetActive(false);
                }
            }
             
            IbisMGManager.started = true;
            
        }

        if (deactivateSelf == true)
        {
            gameObject.SetActive(false);
        }
    }
}
