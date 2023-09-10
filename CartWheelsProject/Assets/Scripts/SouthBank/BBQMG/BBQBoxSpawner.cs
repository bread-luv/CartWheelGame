using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBQBoxSpawner : MonoBehaviour
{
    public string item;
    public Sprite[] itemSpr;
    public GameObject terrain;

    private Sprite setSpr;
    private Vector3 mousePos;

    private void Start()
    {
        if (item == "burger")
        {
            setSpr = itemSpr[0];
        }
        else if (item == "prawn")
        {
            setSpr = itemSpr[1];
        }
        else
        {
            setSpr = itemSpr[2];
        }
    }

    void OnMouseDown()
    {
        createItem();
    }

    private void createItem()
    {
        GameObject item = new GameObject("Item");

        item.AddComponent<SpriteRenderer>();
        item.AddComponent<Rigidbody>();
        item.AddComponent<BoxCollider>();
        item.AddComponent<BBQObject>();
        item.AddComponent<DragAndThrow>();

        item.GetComponent<SpriteRenderer>().sprite = setSpr;

        item.GetComponent<Rigidbody>().mass = 1;

        item.GetComponent<BoxCollider>().size = new Vector3(1, 1, 30);
        item.GetComponent<BoxCollider>().center = new Vector3(item.transform.position.x, item.transform.position.y, item.transform.position.z);

        item.GetComponent<BBQObject>().terrain = terrain;

        mousePos = Input.mousePosition;
        mousePos.z = gameObject.transform.position.z + 9.0f;
        item.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}