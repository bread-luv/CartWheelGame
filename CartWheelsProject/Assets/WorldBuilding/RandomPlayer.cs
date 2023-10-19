using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlayer : MonoBehaviour
{
    public float moveSpeed = 5;
    public Vector3 startPosition;
    public float waitTimer;
    
    public SpriteRenderer sr;


    // Start is called before the first frame update
    void Awake()
    {
        startPosition = transform.position;
    }
    void Start()
    {
        StartCoroutine(Rotate());

        float randomNumber = Random.Range(3, 7);
        waitTimer = randomNumber;


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        if (moveSpeed >= 1)
        {
            sr.flipX = false;
        }
        else if (moveSpeed <= 1)
        {
            sr.flipX = true;
        }

    }

    IEnumerator Rotate()
    {
        yield return new WaitForSeconds(waitTimer);
        moveSpeed = moveSpeed - moveSpeed * 2;
        
        StartCoroutine(Rotate());
    }
}
