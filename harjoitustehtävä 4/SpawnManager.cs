﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Reference to Obstacle prefab
    public GameObject obstaclePrefab;

    //Spawning position 
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    // Reference to PlayerController script
    private PlayerController playerControllerScript;

    //Spawning start delay
    float startDelay = 2;
    // Spawning repeat rate
    private float repeatRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
            if (playerControllerScript.gameOver == false)
            {
                Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            }
    }
}
