using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    //Creating a variable to store start position 
    private Vector3 startPos;
    //Using a variable to store the width of the background,exactly hal way is when we want to reset the background
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        //Variable to hold start position of background
        startPos = transform.position;
        //Using box collider attached to background to get exact half way point of background
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //If position on x axis is less than the start position on x axis - exactly half the width of the background
        //move background back to starting position 
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        } 
    }
}
