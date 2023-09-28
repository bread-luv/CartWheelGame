using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFly : MonoBehaviour
{
    public GameObject manager;

    public int side; //1 = left, -1 = right
    public Rigidbody rb;
    public float speed;
    public float height;
    public GameObject trolley;
    public GameObject terrain;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(speed*side, height, 0);
    }



// Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collide)
    {
        Debug.Log("AHHH");
        if (collide.gameObject == trolley)
        {
            manager.GetComponent<ShoppingMGManager>().score += 1;
            Destroy(gameObject);
        }
        else if (collide.gameObject == terrain)
        {
            manager.GetComponent<ShoppingMGManager>().lives -= 1;
            Destroy(gameObject);
        }
    }
}