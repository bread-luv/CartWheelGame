using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    Vector3 offset;
    Vector3 newpos;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        offset = player.transform.position - transform.position;
    }

    
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position - offset;
    }
}
