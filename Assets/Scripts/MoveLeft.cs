using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    //Variable for speed of object being spawned
    private float speed = 30.0f;
    //Creating a PlayerController object
    private PlayerController playerControllerScript;
    //Variable for a bound,after this obstacles get destroyed
    private float leftBound = -15;
    // Start is called before the first frame update
    void Start()
    {
        //Using the playercontroller object to access a variable in the PlayerController Script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //If statement,Keep spawning objects while gameOver is still false
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        //If a gameobject tagged with the tag "Obstacle" goes past left bound destroy it
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
