using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpSpeed;
    public float climbSpeed;

    public float knockbackForce;
    public float knockbackLength;
    private float knockbackCounter;
    private float attackTimer = 0f;
    private float attackCooldown = 0.5f;
    public Collider2D PlayerAttack;

    private Rigidbody2D myRigidbody;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;
    public bool isAttacking;
    private Animator myAnimator;

    public Vector3 respawnPosition;

    public LevelManager theLevelManager;

    public bool canClimb;
    public bool onLadder;
    public bool onRope;

    public HingeJoint2D Connection;

    void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        respawnPosition = transform.position;
        theLevelManager = FindObjectOfType<LevelManager>();
        PlayerAttack.enabled = false;
	}
	
	void Update ()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (knockbackCounter <= 0)
        {
            if (Input.GetAxisRaw("Horizontal") > 0f)
            {
                myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
                transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0f)
            {
                myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
                transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
            }
            else myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
            }
        }

        if(knockbackCounter > 0)
        {
            knockbackCounter -= Time.deltaTime;

            if(transform.localScale.x > 0)
            {
                myRigidbody.velocity = new Vector3(-knockbackForce, knockbackForce, 0f);
            }
            else
            {
                myRigidbody.velocity = new Vector3(knockbackForce, knockbackForce, 0f);
            }
        }


        myAnimator.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));
        myAnimator.SetBool("isGrounded", isGrounded);
        myAnimator.SetBool("isAttacking", isAttacking);


        if (canClimb)
        {
            if (Input.GetKey(KeyCode.W))
            {
                   myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, climbSpeed, 0f);
            }
            if (Input.GetKey(KeyCode.S))
            {
                myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, -climbSpeed, 0f);
            }

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                myRigidbody.gravityScale = 0f;
                myRigidbody.velocity = new Vector3(0f, 0f, 0f);
            }
        }

        if (!canClimb)
        {
            myRigidbody.gravityScale = 2f;
        }

        if(knockbackCounter > 0)
        {
            theLevelManager.invicible = true;
        }
        else
        {
            theLevelManager.invicible = false;
        }

        if (Input.GetKeyDown(KeyCode.X) && !isAttacking)
        {
            isAttacking = true;
            attackTimer = attackCooldown;
            PlayerAttack.enabled = true;
        }

        if (isAttacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                isAttacking = false;
                PlayerAttack.enabled = false;
            }
        }

        if (theLevelManager.healthCount > 0)
        {
            knockbackLength = 0.3f;
            knockbackForce = 3f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "KillingFloor")
        {
            theLevelManager.Respawn();
        }

        if (other.tag == "Checkpoint")
        {
            respawnPosition = other.transform.position;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
 
    public void Knockback()
    {
        knockbackCounter = knockbackLength;
        theLevelManager.invicible = true;
    }

}
