using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieMovement : MonoBehaviour
{
    public float speed;
    public int[] values = { 0, 0, 0 };

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;

        Debug.Log(values[0] + " " + values[1] + " " + values[2]);
    }
}
