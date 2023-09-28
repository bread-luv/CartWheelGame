using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBQObject : MonoBehaviour
{
    public GameObject terrain;
    public string objectType;
    public GameObject manager;
    public GameObject BBQ;
    public GameObject table;

    private SpriteRenderer sr;

    private bool iniDragged = true;
    private Vector3 mousePos;
    private float startZ;

    private float cook = 0;
    private int cookTime = 6;
    private int cookBurn = 12;

    void Start()
    {
        startZ = gameObject.transform.position.z;
        sr = GetComponent<SpriteRenderer>();
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
            }
            else if (cook >= cookTime && cook < cookBurn)
            {
                scorePoint();
            }
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay(Collision collide)
    {
        if (collide.gameObject == BBQ)
        {
            if (objectType != "water")
            {
                cook += Time.deltaTime;
            }
        }
    }
    

    private void Update()
    {
        Debug.Log(cook);
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

        if (cook >= cookTime)
        {
            if (cook <= cookBurn)
            {
                sr.color = new Color(0.5f, 0.5f, 0.5f, 1);
            }
            else
            {
                sr.color = new Color(0.2f, 0.2f, 0.2f, 1);
            }
        }
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