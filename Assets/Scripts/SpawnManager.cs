using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //creating a GameOject variable
    public GameObject obstaclePrefab;
    //Using a vector 3 position to set spawn position
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    //Variable to govern spawn delay on startup
    private float startDelay = 2;
    //Variable to govern spawn interval of obstacles
    private float repeatRate = 2;
    //Creating a PlayerController object of PlayerController class
    //will use to access gameOver boolean to check gameOver state
    private PlayerController playerControllerScript; 
    
    // Start is called before the first frame update
    void Start()
    {
        //Using are object variable to get access to our playerController script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //Invoke repeating to constantly spawn obstacles using SpawnObstacle() method
        InvokeRepeating("SpawnObstacle", startDelay,repeatRate); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Method to spawn obstacles as long as gameOver state is set to false
    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
