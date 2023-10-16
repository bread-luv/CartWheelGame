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
    public AudioClip correctSound;
    public AudioClip incorrectSound;

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
        if (collide.gameObject == trolley)
        {
            manager.GetComponent<ShoppingMGManager>().score += 1;
            manager.GetComponent<ShoppingMGManager>().sound_source.PlayOneShot(correctSound);
            Destroy(gameObject);
        }
        else if (collide.gameObject == terrain)
        {
            manager.GetComponent<ShoppingMGManager>().lives -= 1;
            manager.GetComponent<ShoppingMGManager>().sound_source.PlayOneShot(incorrectSound);
            Destroy(gameObject);
        }
    }
}