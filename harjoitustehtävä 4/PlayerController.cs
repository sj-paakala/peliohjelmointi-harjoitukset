using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerController : MonoBehaviour
{
    // Player rigid body reference
    private Rigidbody playerRb;
    // Reference to animator
    private Animator playerAnim;
    // Particle system
    public ParticleSystem explosionParticle;
    // Particle system
    public ParticleSystem dirtParticle;
    // Jumpforce
    public float jumpForce;
    // Gravity modifier
    public float gravityModifier;
    // is player on the ground
    public bool isOnGround = true;
    // GameOver on collision
    public bool gameOver;
    // Jump sound
    public AudioClip jumpSound;
    // Crash sound
    public AudioClip crashSound;
    // player Audiosource
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        // Store Rigidbody component in playerRb 
        playerRb = GetComponent<Rigidbody>();
        // Assign component to variable
        playerAnim = GetComponent<Animator>();
        // Get component for player audio
        playerAudio = GetComponent<AudioSource>();
        // playerRb.AddForce(Vector3.up * 1000);
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // If player is on the ground, and not gameOver, jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) {
            // Add force in Y axis to rigidbody
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            // Player animator
            playerAnim.SetTrigger("Jump_trig");
            // Stop dirt particle when jumping
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       

        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            // Play dirt particles when player is on the ground
            dirtParticle.Play();
            // If player collides with obstacle print Game Over! to debug log
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            // Stop dirt particle animation upon death
            dirtParticle.Stop();
            // Play crash sound at full volume
            playerAudio.PlayOneShot(crashSound, 0.5f);
        }

    }
}
