﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController2D : MonoBehaviour
{
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public LayerMask wallLayer;
    private Rigidbody2D playerRB;
    private CapsuleCollider2D playerCollider;
    bool stopChecking = false;
    bool running = false;
    bool jumping = false;
    bool canWallRun = false;
    // bool facingRight = true;
    // Start is called before the first frame update

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CapsuleCollider2D>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0.0f)
        {
            running = true;
        }
        else
        {
            running = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jumping");
            jumping = true;
        }
        else
        {
            jumping = false;
        }

        if (Input.GetAxisRaw("modifier") == -1)
        {
            Debug.Log("Holding left trigger");
            Debug.Log(nextToWall());

            GetComponent<wallrun_action>().invoke(playerRB, nextToWall(), jumping, grounded(), canWallRun);
            if (jumping)
            {
                canWallRun = false;
            }
        }
        else
        {
            GetComponent<jump_action>().invoke(ref playerRB, grounded(), jumping);
        }

        if (running)
        {
            GetComponent<movement_action>().invoke(Input.GetAxisRaw("Horizontal"), ref playerRB, grounded());
        }

        if (grounded())
        {
            canWallRun = true;
        }
        // if(jumping) {

        // }
    }

    private bool nextToWall()
    {
        Collider2D collider = Physics2D.OverlapCapsule(playerRB.position, playerCollider.size, playerCollider.direction, 0.0f, wallLayer);
        return collider != null;
    }
    private bool grounded()
    {
        RaycastHit2D groundCheck = Physics2D.Raycast(
            playerRB.position,
            Vector2.down,
            (playerCollider.size.y / 4.0f) + 0.2f,
            groundLayer);

        Debug.DrawLine(transform.position, transform.position + Vector3.down * (0.2f + playerCollider.size.y / 4.0f), Color.green);
        return groundCheck.collider != null;
    }


}
