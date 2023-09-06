using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{

    public float MoveSpeed = 1f;
    public float JumpSpeed = 5f;
    public bool IsJumping = false;
    public float JumpsUsed = 0;
    public float HowManyJumps = 6.0f;
    public Animator animator;

    private float CurrentJumps;
    private float Move;
    private Vector2 Movement;
    private Rigidbody2D PlayerRigidBody;
    private Vector3 SpawnPos;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
        
    void Start() {
        PlayerRigidBody = GetComponent<Rigidbody2D>();
        CurrentJumps = HowManyJumps;
        SpawnPos = transform.position;
        Debug.Log(SpawnPos);
    }

    public void Reset() {
        transform.position = SpawnPos;
    }

    void Update() {

        Move = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(Move)); //Transition animation from idle to walking when walking
        animator.SetFloat("Jumps Used", JumpsUsed); //Transition to floating
        //Check direction player is moving and change accordingly
        if (Move > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        if(Move < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        //End of direciton checker

        PlayerRigidBody.velocity = new Vector2(MoveSpeed * Move, PlayerRigidBody.velocity.y);

        if (Input.GetButtonDown("Jump") && (IsJumping == false || CurrentJumps != 0)) {
            if(CurrentJumps == HowManyJumps)
            {
                audioManager.PlaySFX(audioManager.jump);
            }
            else
            {
                audioManager.PlaySFX(audioManager.extraJump);
            }
            CurrentJumps--;
            JumpsUsed++;
            PlayerRigidBody.velocity = new Vector2(PlayerRigidBody.velocity.x, JumpSpeed);
        }
        if (Input.GetKeyDown(KeyCode.R)) //allows the player to reload the level by pressing "R"
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) //exits game if player presses esc
        {
            // Quit the application
            Application.Quit();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) { 
        if (other.gameObject.CompareTag("Ground")) {
            audioManager.PlaySFX(audioManager.landing);
            IsJumping = false;
            CurrentJumps = HowManyJumps;
            JumpsUsed = 0;
            animator.SetBool("Jump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            IsJumping = true;
            animator.SetBool("Jump", true);
        }
    }


}
