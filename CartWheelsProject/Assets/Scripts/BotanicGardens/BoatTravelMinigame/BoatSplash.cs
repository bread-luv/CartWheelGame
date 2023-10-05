using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSplash : MonoBehaviour
{
    public GameObject follow;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(follow.transform.position.x, follow.transform.position.y-0.3f, follow.transform.position.z-0.15f);
    }
}
