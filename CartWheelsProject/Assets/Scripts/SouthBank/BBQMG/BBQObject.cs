using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBQObject : MonoBehaviour
{

    public GameObject terrain;

    private void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject == terrain)
        {
            Destroy(gameObject);
        }
    }
}