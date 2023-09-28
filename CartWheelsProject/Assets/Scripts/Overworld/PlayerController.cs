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

    public GameObject noMove;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (noMove.activeSelf == false)
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
            Vector3 moveDir = new Vector3(0, 0, 0);
            Vector3 mousePos = Input.mousePosition;
            float mouseRelPos = mousePos.x - 790;

            sr = GetComponent<SpriteRenderer>();

            if (Input.GetMouseButton(0))
            {
                if (mousePos.x < Screen.width / 2)
                {
                    sr.flipX = true;
                    if (mousePos.x < Screen.width / 4)
                    {
                        rb.velocity = new Vector3(-speed, 0, 0);
                    }
                    else
                    {
                        rb.velocity = new Vector3(-speed/2, 0, 0);
                    }
                }
                else
                {
                    sr.flipX = false;
                    if (mousePos.x > Screen.width / 2 + Screen.width / 4)
                    {
                        rb.velocity = new Vector3(speed, 0, 0);
                    }
                    else
                    {
                        rb.velocity = new Vector3(speed / 2, 0, 0);
                    }
                }
            }
            else
            {
                rb.velocity = new Vector3(0, 0, 0);
            }

            rb.AddForce(Physics.gravity * (rb.mass * rb.mass));
        }

    }
}