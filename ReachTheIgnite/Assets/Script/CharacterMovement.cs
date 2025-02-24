using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    private float horizontal;
    private bool isFacingRight;
    public float playerSpeed;
    public float jumpingPower;
    public bool crouching = false;
    public bool jumping = false;
    private float playerSpeedInternalBool;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        jumpingPower = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (crouching || jumping) 
        {
            playerSpeedInternalBool = 0;
        }
        else
        {
            playerSpeedInternalBool = playerSpeed;
        }

        Flip();
        PlayerMovement();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * playerSpeedInternalBool, rb.velocity.y);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal <0f || !isFacingRight && horizontal >0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    void PlayerMovement()
    {
        if (!crouching && !jumping)
        {
            horizontal = Input.GetAxisRaw("Horizontal");

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            crouching = true;
        }
        if (Input.GetKeyUp(KeyCode.Space) && !jumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            crouching = false;



        }

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            jumping = false;
        }
    } 
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            jumping = true;
        }
    }


}
