using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    Vector3 offset;
    Vector3 newpos;
    public GameObject player;
    public bool gx;
    public bool gy;
    public bool gz;
    float _x;
    float _y;
    float _z;

    // Start is called before the first frame update
    void Start()
    {
        
        offset = player.transform.position - transform.position;
        _x = player.transform.position.x;
        _y = player.transform.position.y;
        _z = player.transform.position.z;
        
    }

    
    // Update is called once per frame
    void Update()
    {
        
        if (gx)
        {
            _x = player.transform.position.x;

        }
        if (gy)
        {
            _y = player.transform.position.y;
        }
        if (gz)
        {
            _z = player.transform.position.z;
        }
        newpos = new Vector3(_x, _y, _z);

        transform.position = newpos - offset;
    }
}
