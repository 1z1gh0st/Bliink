using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPlatformerController : physicsObject {

    public float maxWalkSpeed = 3;
    public float jumpTakeOffSpeed = 15;

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


        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.0f) : (move.x < 0.0f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        targetVelocity = move * maxWalkSpeed;

        animator.SetBool("grounded", grounded);
        animator.SetBool("onWall", onWall);

        animator.SetFloat("velocityY", velocity.y);

        animator.SetBool("isJumpInput", Input.GetButtonDown("Jump"));

        animator.SetFloat("isMotionInput", Mathf.Abs(Input.GetAxis("Horizontal")));
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxWalkSpeed);

        targetVelocity = move * maxWalkSpeed;
    }
}
