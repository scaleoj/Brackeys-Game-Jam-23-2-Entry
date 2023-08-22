using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public MovementController2D controller;
    public Rigidbody2D body;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool dive = false;

    private Vector2 zero = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dive = false;
            jump = true;
            body.gravityScale = -0.5f;
        }


        if(Input.GetKeyUp(KeyCode.Space))
        {
            
            body.gravityScale = 0.5f;

        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            jump = false;
            dive = true;
            body.gravityScale = 0.5f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            
            body.gravityScale = -0.5f;
        }



        if(body.velocity.y < 0.1f && jump == true && body.gravityScale > 0)
        {
            body.gravityScale = 0;
            body.velocity = zero;
            jump = false;
        }

        if (body.velocity.y > 0.1f && dive == true && body.gravityScale < 0)
        {
            body.gravityScale = 0;
            body.velocity = zero;
            dive = false;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
        
    }
}