using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // cached referenses
    public Animator animatorController;
    public SpriteRenderer playerRenderer;
    private Rigidbody2D rBody;

    // editable parameters
    public float movementSpeed;
    public float jumpForce;
    public LayerMask groundMask;
    public float groundCheckDistance;

    // cached parameters
    private float movementInput;



    private void Awake()
    {
        // cache rigid body on awake
        rBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // process some inputs
        movementInput = Input.GetAxis("Horizontal");

        // apply jump force if user presses spacebar (or joystick button)
        if (Input.GetButtonDown("Jump"))
            Jump();
    }

    private void FixedUpdate()
    {
        // apply inputs on fixed update loop because of physics
        // physics better do on fixed update
        rBody.velocity = new Vector2(movementInput * movementSpeed, rBody.velocity.y);

        if (Mathf.Abs(rBody.velocity.x) > 0.1f)
        {
            animatorController.SetInteger("AnimState", 2);
            playerRenderer.flipX = movementInput > 0;
        }
        else 
            animatorController.SetInteger("AnimState", 0);

        CheckGround();
    }

    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundMask);
        animatorController.SetBool("Grounded", hit.collider != null);
    }

    private void Jump()
    {
        rBody.velocity = new Vector2(rBody.velocity.x, jumpForce);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Vector3.down * groundCheckDistance);
    }
}
