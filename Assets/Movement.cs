using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    Rigidbody2D rigi;
    float speed = 5;
    float jump;
    float moveVelocity;

    public Transform groundCheckTransform;
    private bool isGrounded;
    private bool isRunning;
    private bool left, right;
    public LayerMask groundCheckLayerMask;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        right = true;
        rigi = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            }
        }

        moveVelocity = 0;

        isRunning = false;

        //Left Right Movement
        if (Input.GetKey(KeyCode.A))
        {
            TurnLeft();
            moveVelocity = -speed;
            isRunning = true;
            //playerAnimator.SetBool("isRunning", isRunning);
        }
        if (Input.GetKey(KeyCode.D))
        {
            TurnRight();
            moveVelocity = speed;
            isRunning = true;
            //playerAnimator.SetBool("isRunning", isRunning);
        }
        UpdateGroundedStatus();
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);



    }

    public void TurnLeft()
    {
        if (left)
            return;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        left = true;
        right = false;
    }

    public void TurnRight()
    {
        if (right)
            return;
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        right = true;
        left = false;
    }

    void UpdateGroundedStatus()
    {
        //1
        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, 0.1f, groundCheckLayerMask);
        //2
        //playerAnimator.SetBool("isGrounded", isGrounded);
    }

}
