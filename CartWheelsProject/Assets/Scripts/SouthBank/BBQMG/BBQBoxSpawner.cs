using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBQBoxSpawner : MonoBehaviour
{
    public string _item;
    public Sprite[] itemSpr;
    public GameObject terrain;
    public GameObject manager;
    public GameObject table;
    public GameObject BBQ;

    private Sprite setSpr;
    private Vector3 mousePos;

    private void Start()
    {
        if (_item == "burger")
        {
            setSpr = itemSpr[0];
        }
        else if (_item == "prawn")
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
        //item.AddComponent<DragAndThrow>();

        item.GetComponent<SpriteRenderer>().sprite = setSpr;

        item.GetComponent<Rigidbody>().mass = 1;
        item.GetComponent<Rigidbody>().freezeRotation = true;
        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;

        Vector2 S = item.GetComponent<SpriteRenderer>().sprite.bounds.size;
        item.GetComponent<BoxCollider>().size = new Vector3(S.x, S.y, 0.2f);
        item.GetComponent<BoxCollider>().center = new Vector3(S.x / 2, S.y / 2);

        item.GetComponent<BBQObject>().terrain = terrain;
        item.GetComponent<BBQObject>().objectType = _item;
        item.GetComponent<BBQObject>().manager = manager;
        item.GetComponent<BBQObject>().table = table;
        item.GetComponent<BBQObject>().BBQ = BBQ;

        mousePos = Input.mousePosition;
        mousePos.z = gameObject.transform.position.z + 9.0f;
        item.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}