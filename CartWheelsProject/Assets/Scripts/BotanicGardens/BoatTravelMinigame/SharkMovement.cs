using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 6;
    public SpriteRenderer sr;

    // Update is called once per frame
    void Start()
    {
        rb.velocity = new Vector3(speed, 0, 0);
    }

    private void Update()
    {
        if (speed < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        speed = speed * -1;
        rb.velocity = new Vector3(speed, 0, 0);
    }
}
