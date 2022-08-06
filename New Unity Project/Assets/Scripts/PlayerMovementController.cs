using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private float currentSpeed;

    [SerializeField]
    private float maxGravity;

    [SerializeField]
    private float gravityConstant;

    [SerializeField]
    private float currentGravity;

    [SerializeField]
    private float groundGravity;

    [SerializeField]
    private CharacterController characterController;

    private Vector3 movementVector;
    private Vector3 gravityVector;

    [SerializeField]
    private SoundPlayer soundPlayer;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private int xMovementDirection;
    private int zMovementDirection;


    void Start()
    {
        xMovementDirection = 0;
        zMovementDirection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateGravity();
        MoveCharacter();
        DoSound();
        SetAnimation();
    }

    public void Move(float xDirection, float zDirection)
    {
        currentSpeed = xDirection != 0 || zDirection != 0 ? speed : 0;
        xMovementDirection = (int)xDirection;
        zMovementDirection = (int)zDirection;

        movementVector = (transform.right * -1 * xDirection +  transform.forward * zDirection * -1) * speed * Time.deltaTime;
  //Need to take into consideration  the camera but this works for now
        
    }

    private void CalculateGravity()
    {
        float currentGravity = groundGravity * Time.deltaTime;
        gravityVector = new Vector3(0f, currentGravity, 0f);
    }

    private bool IsGrounded()
    {
        return characterController.isGrounded;
    }

    private void MoveCharacter()
    {
        characterController.Move(movementVector + gravityVector);
    }  
    
    private void DoSound()
    {
        soundPlayer.PlayFootStepSound(currentSpeed > 0);

    }

    private void SetAnimation()
    {
        spriteRenderer.flipX = xMovementDirection < 0 && currentSpeed > 0;   

        animator.SetFloat("Speed", currentSpeed);
        animator.SetInteger("xDirection", xMovementDirection);
        animator.SetInteger("zDirection", zMovementDirection);
    }

     
}
