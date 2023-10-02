using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public GameObject[] collideWith;
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    public AudioSource audioSource;

    // Update is called once per frame
    void OnTriggerEnter(Collider collide)
    {
        for (int i = 0; i < collideWith.Length; i++)
        {
            if (collide.gameObject == collideWith[i])
            {
                if (i == 0)
                {
                    audioSource.PlayOneShot(correctSound);
                }
                else
                {
                    audioSource.PlayOneShot(incorrectSound);
                }
                gameObject.SetActive(false);
            }
        }
    }
}
