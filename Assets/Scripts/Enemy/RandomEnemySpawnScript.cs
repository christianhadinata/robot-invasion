﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemySpawnScript : MonoBehaviour
{
    public GameObject enemy;            // The enemy prefab to be spawned.
    public float spawnTime = 5f;            // How long between each spawn.
    public float decreaseSpawnTime = 30f;

    void Start ()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);

    }

    void Update()
    {
        if (Time.time > decreaseSpawnTime)
        {
            spawnTime -= 1f;
            InvokeRepeating("Spawn", spawnTime, spawnTime);
            decreaseSpawnTime += 30f;
        }

    }


    void Spawn ()
    {
        float randomNum = Random.value;
        Vector3 position;
        if (randomNum <= 0.3) 
        {
            position = new Vector3(0.0f, 0.0f, Random.Range(0.0f,80.0f));
        }
        else if (randomNum <= 0.6 && randomNum > 0.3)
        {
            position = new Vector3(40.0f, 0.0f, Random.Range(0.0f,80.0f));
        }
        else if (randomNum <= 0.8 && randomNum > 0.6)
        {
            position = new Vector3(Random.Range(0.0f,40.0f), 0.0f, 0.0f);
        }
        else {
            position = new Vector3((float)Random.Range(0.0f,40.0f), 0.0f, 80.0f);
        }

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate (enemy, position, Quaternion.identity);
    }

}