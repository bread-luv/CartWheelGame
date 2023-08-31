using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeatPieDispense : MonoBehaviour
{
    public GameObject pie;
    public float distance;

    public int assigned = 0;
    public int dispenseVal;

    public int time = 30;
    private int timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector3.Distance(pie.transform.position, transform.position) < distance) && (assigned != 0))
        {
            if (pie.GetComponent<PieMovement>().values[dispenseVal] == 0)
            {
                pie.GetComponent<PieMovement>().values[dispenseVal] = assigned;
            }
        }

        if (assigned != 0)
        {
            timer++;

            if (timer >= time)
            {
                timer = 0;
                assigned = 0;
            }
        }
    }
}
