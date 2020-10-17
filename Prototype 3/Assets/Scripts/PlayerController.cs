using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem particleExplosion;
    public ParticleSystem particleDirt;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 10;
    public float gravityModifier = 1;
    public bool isOnGround = true;
    public bool gameOver;
    private bool isOnAir = false;
    private float moveOnStart = -7;
    private float speed = 5f;
    public int score = 0;
    public int maxScore = 5;
    public bool boolSwitherOn = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        //playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        transform.position = new Vector3(moveOnStart, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (score == maxScore && boolSwitherOn)
        {
            Debug.Log("You win!!! Your score is " + score);
            playerAnim.SetFloat("Speed_f", 0);
            particleDirt.Stop();
            gameOver = true;
            boolSwitherOn = false;
        }
        else if (transform.position.x < 0)
        {
            playerAnim.SetFloat("Speed_f", 0.4f);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else
        {
            playerAnim.SetFloat("Speed_f", 1);
        }
        Jumps();
    }

    void Jumps()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            isOnGround = false;
            isOnAir = true;
            JumpPlayer();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !gameOver && isOnAir)
        {
            isOnAir = false;
            JumpPlayer();
        }
    }

    private void JumpPlayer()
    {
        playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        playerAnim.SetTrigger("Jump_trig");
        particleDirt.Stop();
        playerAudio.PlayOneShot(jumpSound, 0.4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            if (boolSwitherOn)
                particleDirt.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle") && boolSwitherOn)
        {
            gameOver = true;
            Debug.Log("Game Over! You reached the obstacle. Your score is: " + score);
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            particleExplosion.Play();
            particleDirt.Stop();
            playerAudio.PlayOneShot(crashSound, 1);
            boolSwitherOn = false;
        }
        
    }
}
