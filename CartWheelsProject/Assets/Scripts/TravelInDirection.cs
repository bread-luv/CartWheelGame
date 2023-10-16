using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelInDirection : MonoBehaviour
{
    public float x_speed = 0;
    public float y_speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(x_speed, y_speed, 0);
    }
}
