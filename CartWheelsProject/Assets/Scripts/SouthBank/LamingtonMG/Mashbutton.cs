using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mashbutton : MonoBehaviour
{
    public GameObject manager;

    // Update is called once per frame
    public void mash()
    {
        manager.GetComponent<LamingtonManager>().mashCounter += 1;
    }
}
