using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPlatformerController : physicsObject {

    public float maxWalkSpeed = 3;
    public float jumpTakeOffSpeed = 15;
    public float wallSlideSpeed = 7;
    public float wallJumpTakeOffSpeed = 100;

    protected Vector2 wallJumpingVelocity;

    private SpriteRenderer spriteRenderer;

    Animator animator;

    // Use this for initialization
    void Awake () {
        spriteRenderer = GetComponent<SpriteRenderer> ();

        animator = GetComponent<Animator>();
    }


    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && (grounded || onWall))
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y *= .5f;
            }
        }
              
       /* if (onWall)
        {
            if (velocity.y < -wallSlideSpeed)
            {
                velocity.y = -wallSlideSpeed;
            }
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = jumpTakeOffSpeed;

                wallJumpingVelocity.x = (wallDirection*wallJumpTakeOffSpeed);

                targetVelocity = -wallJumpingVelocity;
            }*/
        //}
        else
        {
            wallJumpingVelocity = Vector2.zero;
            targetVelocity = move * maxWalkSpeed;

        }



        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.0f) : (move.x < 0.0f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("grounded", grounded);
        animator.SetBool("onWall", onWall);

        animator.SetFloat("velocityY", velocity.y);

        animator.SetFloat("wallDirection", wallDirection);

        animator.SetBool("isJumpInput", Input.GetButtonDown("Jump"));

        animator.SetFloat("isMotionInput", Mathf.Abs(Input.GetAxis("Horizontal")));
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxWalkSpeed);

    }
}
