using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToObject : MonoBehaviour
{

    public GameObject[] moveTo;
    public float speed;

    public bool xMovement = true;
    public bool yMovement = true;
    public bool zMovement = true;

    private float _x;
    private float _y;
    private float _z;

    private void Start()
    {
        _x = transform.position.x;
        _y = transform.position.y;
        _z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (xMovement == true) { _x = GetClosestObject(moveTo).position.x; }
        if (yMovement == true) { _y = GetClosestObject(moveTo).position.y; }
        if (zMovement == true) { _z = GetClosestObject(moveTo).position.z; }

        Vector3 goTo = new Vector3(_x, _y, _z);

        transform.position = Vector3.MoveTowards(transform.position, goTo, speed);
    }

    Transform GetClosestObject(GameObject[] objects)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;

        for (int i = 0; i < objects.Length; i++)
        {
            float dist = Vector3.Distance(objects[i].transform.position, currentPos);
            if (dist < minDist && objects[i].activeSelf == true)
            {
                tMin = objects[i].transform;
                minDist = dist;
            }
        }

        if (tMin == null) { tMin = transform; }
        return tMin;
    }
}
