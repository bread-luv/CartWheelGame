using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactiveTimer : MonoBehaviour
{
    public float seconds = 3;
    private float cur_seconds;

    private void Start()
    {
        cur_seconds = seconds;
    }

    // Update is called once per frame
    void Update()
    {
        cur_seconds -= Time.deltaTime;
        if (cur_seconds <= 0) {
            cur_seconds = seconds;
            gameObject.SetActive(false);
        }
    }
}
