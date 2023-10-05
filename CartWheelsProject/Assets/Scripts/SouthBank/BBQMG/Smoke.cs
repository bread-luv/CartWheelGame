using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    public float speed = 2;
    private float time = 0;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 1.5)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f - time / 6);
        }
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, speed, 0);
        if (transform.position.y >= 20)
        {
            Destroy(gameObject);
        }
    }
}
