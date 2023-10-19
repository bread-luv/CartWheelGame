using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    public GameObject manager;
    public GameObject item;
    public List<GameObject> var_items;

    public AudioClip correctSound;
    public AudioClip incorrectSound;


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject == item)
        {
            manager.GetComponent<StallManager>().count += 1;
            gameObject.GetComponent<AudioSource>().PlayOneShot(correctSound);
            collision.gameObject.SetActive(false);
            foreach (var objects in var_items)
            { objects.SetActive(false); }
        }

        else if (var_items.Contains(collision.gameObject))
        {
            manager.GetComponent<StallManager>().lives -= 1;
            gameObject.GetComponent<AudioSource>().PlayOneShot(incorrectSound);
            collision.gameObject.SetActive(false);
        }
    }
}