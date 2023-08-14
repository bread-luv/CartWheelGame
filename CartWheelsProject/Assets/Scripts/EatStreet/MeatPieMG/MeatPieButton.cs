using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatPieButton : MonoBehaviour
{
    public GameObject dispenser;
    public int assign;

    public void clicked()
    {
        dispenser.GetComponent<MeatPieDispense>().assigned = assign;
    }
}
