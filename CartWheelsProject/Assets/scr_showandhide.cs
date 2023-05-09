using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_showandhide : MonoBehaviour
{
    public GameObject player;
    public GameObject ui;
    public int distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, ui.transform.position) < distance)
        {
            ui.SetActive(true);
        }
        else { ui.SetActive(false); }
    }
}
