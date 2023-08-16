using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public static int movementspeed = 1;
    public Vector3 userDirection = Vector3.right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(userDirection * movementspeed * Time.deltaTime);
    }
}
