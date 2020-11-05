using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10;
    
    // Left boundary 
    private float leftBound = -15;

    // Reference to PLayerController script
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move left while not in gameOver state
        if (playerControllerScript.gameOver == false)
        { 
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
            if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
