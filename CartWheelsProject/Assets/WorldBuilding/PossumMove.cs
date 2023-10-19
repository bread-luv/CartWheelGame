using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossumMove : MonoBehaviour
{
    public float moveSpeed = 10;
    public float waitTimer;
    // Start is called before the first frame update

    public Vector3 startPosition;

    void Awake()
    {
        startPosition = transform.position; 
    }
    void Start()
    {
        StartCoroutine(SelfDestruct());

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

        
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(waitTimer);
        transform.position = startPosition;

        StartCoroutine(SelfDestruct());
    }
}
