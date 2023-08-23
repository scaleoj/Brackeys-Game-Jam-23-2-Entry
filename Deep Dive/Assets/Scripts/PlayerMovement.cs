using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public MovementController2D controller;
    public Rigidbody2D body;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool dive = false;
    bool WLocker = false;
    bool SLocker = false;

    private Vector2 zero = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKeyDown(KeyCode.W)&& !SLocker)
        {
            dive = false;
            jump = true;
            WLocker = true;
            body.gravityScale = -0.5f;
        }


        if(Input.GetKeyUp(KeyCode.W))
        {
   
            body.gravityScale = 0.5f;
            WLocker = false;

        }

        if (Input.GetKeyDown(KeyCode.S) && !WLocker)
        {
            jump = false;
            dive = true;
            SLocker = true;
            body.gravityScale = 0.5f;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            
            body.gravityScale = -0.5f;
            SLocker = false;
        }



        if(body.velocity.y < 0.1f && jump == true && body.gravityScale > 0)
        {
            if(dive != true)
            {
                body.gravityScale = 0;
                body.velocity = zero;
                jump = false;
            }
            else
            {
                body.gravityScale = -0.5f;
            }


            
        }

        if (body.velocity.y > 0.1f && dive == true && body.gravityScale < 0)
        {
            if(jump!= true)
            {
                body.gravityScale = 0;
                body.velocity = zero;
                dive = false;
            }
            else
            {
                body.gravityScale = 0.5f;
            }

        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
        
    }
}