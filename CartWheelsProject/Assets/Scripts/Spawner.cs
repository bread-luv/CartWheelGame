using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] animalTypes;
    public GameObject animalSpawn;
    float[] xVariables = { -8.5f, -7.5f, -6.5f, -5.5f, -4.5f, -3.5f, -2.5f, -1.5f, 0.5f, 1.5f, 2.5f, 3.5f, 4.5f, 5.5f, 6.5f, 7.5f };
    float[] yVariables = { -3.5f, -2.5f, -1.5f, -0.5f, 1.5f, 2.5f, 3.5f };
    public float randomX;
    public float randomY;
    public Collider2D[] colliders;
    private float radius = 10;
    public Vector2 dimensions;
    public LayerMask mask;



    // Start is called before the first frame update
    void Start()
    {
        AnimalSpawner();
    }

    public void AnimalSpawner()
    {
        for (float i = 0; i < /*50*/animalTypes.Length; i++)
        {
            bool canSpawnHere = false;
            Vector3 spawnPos = new Vector3(0, 0, 0);
            int safetyNet = 0;



            while (!canSpawnHere)
            {
                randomX = xVariables[Random.Range(0, xVariables.Length)];
                randomY = yVariables[Random.Range(0, yVariables.Length)];

                spawnPos = new Vector3(randomX, randomY, 0);

                canSpawnHere = PreventSpawnOverlap(spawnPos);

                if (canSpawnHere)
                {
                    break;
                }

                safetyNet++;

                if (safetyNet > 50)
                {
                    break;
                }
            }
            GameObject newAnimal = Instantiate(animalTypes[Random.Range(0, animalTypes.Length)], new Vector3(randomX, randomY, 0), Quaternion.identity) as GameObject;
        }
    }


    bool PreventSpawnOverlap(Vector3 spawnPos)
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, radius, mask);

        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 centerPoint = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.x;
            float height = colliders[i].bounds.extents.y;
            float leftExtent = centerPoint.x - width;
            float rightExtent = centerPoint.x + width;
            float lowerExtent = centerPoint.y - height;
            float upperExtent = centerPoint.y + height;

            if (spawnPos.x >= leftExtent && spawnPos.x <= rightExtent)
            {
                if (spawnPos.y >= lowerExtent && spawnPos.y <= upperExtent)
                {
                    return false;
                }
            }

        }

        return true;
    }

}