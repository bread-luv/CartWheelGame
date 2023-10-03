using Assets.Scripts.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{

    public GameObject item;
    public List<GameObject> var_items;


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject == item)
        {
            Debug.Log("True");
            StallManager.count += 1;
            Destroy(collision.gameObject);
            foreach (var objects in var_items)
            { Destroy(objects); }
        }

        else if (var_items.Contains(collision.gameObject))
        {
            Debug.Log("False");
            StallManager.lives -= 1;
            Destroy(collision.gameObject);
        }
    }
}