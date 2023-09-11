using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBQObject : MonoBehaviour
{
    public GameObject terrain;
    public string objectType;
    public GameObject manager;
    public GameObject table;

    private bool iniDragged = true;
    private Vector3 mousePos;
    private float startZ;

    void Start()
    {
        startZ = gameObject.transform.position.z;
    }

    private void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject == terrain)
        {
            Destroy(gameObject);
        }

        if (collide.gameObject == table)
        {
            if (objectType == "water")
            {
                scorePoint();
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        Debug.Log(iniDragged);
        if (!Input.GetMouseButton(0) && iniDragged == true)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            iniDragged = false;
        }

        if (iniDragged)
        {
            moveToMouse();
        }

        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, startZ);
    }

    void OnMouseDrag()
    {
        moveToMouse();
    }

    private void moveToMouse()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 11.2f;
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void scorePoint()
    {
        if (objectType == "burger")
        {
            manager.GetComponent<BBQMGManager>().burgerScore += 1;
        }
        else if (objectType == "prawn")
        {
            manager.GetComponent<BBQMGManager>().prawnScore += 1;
        }
        else
        {
            manager.GetComponent<BBQMGManager>().waterScore += 1;
        }
    }
}