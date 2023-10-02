using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeSpawner : MonoBehaviour
{
    private float smokeTimer = 0;
    public GameObject smoke;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<AudioSource>().isPlaying)
        {
            smokeTimer += Time.deltaTime;
            if (smokeTimer > 0.8)
            {
                Instantiate(smoke, gameObject.transform);
                smokeTimer = 0;
            }
        }
    }
}
