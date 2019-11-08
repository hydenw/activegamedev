using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovementTesting : MonoBehaviour
{
    [SerializeField] private float moveSpeedModifier = 1f;
    [SerializeField] private float moveSpeed = 1f;

    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private Rigidbody2D playerRigidbody2D;
    private Vector3 oldTransform;
    [SerializeField] SpriteRenderer playerTorsoRenderer;

    [SerializeField] private SpriteRenderer playerLegRenderer;
    [SerializeField] private GameObject playerLegs;
    [SerializeField] Animator playerLegAnimator;
    [SerializeField] Animator playerUpperAnimator;
    
    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        oldTransform = playerLegs.transform.position;
    }

    void Update()
    {
        ProcessInputs();
        HandleAnimation();
    }

    private void FixedUpdate()
    {
        
    }

    void ProcessInputs()
    {
        moveDirection = Vector2.zero;
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        moveDirection.Normalize();
    }

    void MovePlayer()
    {
        Vector2 playerVelocity =
            transform.position + (moveDirection * moveSpeed * moveSpeedModifier) * Time.deltaTime;
        playerRigidbody2D.MovePosition(playerVelocity);
    }

    void HandleAnimation()
    {
        if (moveDirection != Vector3.zero)
        {
            MovePlayer();
            OffsetSprite();
            playerLegAnimator.SetBool("isMoving", true);
            playerUpperAnimator.SetBool("isMoving", true);
            playerLegAnimator.SetFloat("moveHorizontal", moveDirection.x);
            playerUpperAnimator.SetFloat("moveHorizontal", moveDirection.x);
            playerUpperAnimator.SetFloat("moveVertical", moveDirection.y);
            playerLegAnimator.SetFloat("moveVertical", moveDirection.y);
        }
        else
        {
            playerUpperAnimator.SetBool("isMoving", false);
            playerLegAnimator.SetBool("isMoving", false);
        }
    }

    void OffsetSprite()
    {
        if (moveDirection.x > 0f)
        {
            playerTorsoRenderer.flipX = true;
            playerLegRenderer.flipX = true;
        }
        else
        {
            playerTorsoRenderer.flipX = false;
            playerLegRenderer.flipX = false;
        }
    }
    
}
