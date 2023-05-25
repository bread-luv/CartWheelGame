using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float groundDist;

    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;

    public bool useGrav = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if (hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
                transform.position = movePos;
            }
        }


        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(0,0,0);
        Vector3 mousePos = Input.mousePosition;
        float mouseRelPos = mousePos.x - 790;

        if (Input.GetMouseButton(0))
        {
            moveDir = new Vector3((mouseRelPos) / 1000, 0, 0);
        }
        Debug.Log(mousePos.x);
        rb.velocity = moveDir * speed;                                                                                                                                    

        rb.AddForce(Physics.gravity * (rb.mass * rb.mass));

        sr = GetComponent<SpriteRenderer>();

        if (rb.velocity.x < 0)
        {
            sr.flipX = true;
        }
        else if (rb.velocity.x > 0)
        {
            sr.flipX = false;
        }

    }
}