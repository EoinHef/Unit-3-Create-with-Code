using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    //Variables for particle effects on player
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    //Creating a reference to a rigid body component attached to an object
    //player in this case
    private Rigidbody playerRb;
    //Creating a Animator object,reference for Animator class
    private Animator playerAnim;
    //The force were are going to apply to upward motion
    public float jumpForce = 10;
    //Public variable to allow tweaking of gravity force
    public float gravityModifier;
    //Boolean to check if the player is in contact with the ground object
    public bool isOnGround = true;
    //Boolean that is used to check if the game should be in a game over state
    public bool gameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        //Initialising rigid body variable to the rigid body component attached to player
        playerRb = GetComponent<Rigidbody>();
        //Initialising Animator variable to the Animator component attached to player
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        //If statement that only allows player to jump if they have pressed space and are on the ground. Also cannot
        //jump if the gameOver state is true
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            
            //Using rigidbody component attached to player to add force to it
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            //While in the air isOnGround is set to false to stop double jump
            isOnGround = false;
            //Using tirgger name to invoke,trigger found in animator panel
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound);
        }
    }
    //Method to detect collisions,first one checks for collision with ground object
    //so can use that to stop double jump
    //Second one checks for collision with objects tagged "Obstacles",if collision happens
    //game over state is changed to true
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; 
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            //Using player animator methods to set a death animation if gameOver is true
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound);
        }
    }
}


