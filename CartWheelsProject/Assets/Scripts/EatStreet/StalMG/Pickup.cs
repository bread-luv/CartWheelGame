using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hoop;
    private Rigidbody _rigidbody;
    private Vector3 screenPoint;
    private Vector3 offset;
    public float speed = 5;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }


    void OnMouseDrag()
    {
        _rigidbody.velocity = Vector3.zero;
        var curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) - offset;
        transform.position = curPosition;
    }
<<<<<<<< Updated upstream:CartWheelsProject/Assets/Scripts/StallMG/Pickup.cs
}
========
}
>>>>>>>> Stashed changes:CartWheelsProject/Assets/Scripts/EatStreet/StalMG/Pickup.cs
