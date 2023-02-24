using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject prefabBullet,spawnPoint;
    public float spawnTime = 3.0f;
    void Start()
    {
        InvokeRepeating("SpawnBall", spawnTime, spawnTime);
        
        //Destroy(prefabBullet,3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBall()
    {
        Instantiate(prefabBullet, spawnPoint.transform);
    }
}
