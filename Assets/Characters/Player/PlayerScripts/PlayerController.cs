using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using static UnityEngine.UI.ScrollRect;
using UnityEngine.UI;
using System.Net.Security;
using Unity.VisualScripting;


public class PlayerController : MonoBehaviour
{
    public InputAction inputAction;
    public PlayerInputActions playerControls;
    private InputAction dash;
    [SerializeField] private Vector2 movementInput;
    [SerializeField] private float movementSpeed, dashSpeed, dashTime, dashRefresh, lastDashed;
    [SerializeField, Range(0, 1)] private float diagonalSpeedFactor = .7f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Image Cooldown;
    [SerializeField] public bool externalMovement, directionalyAnimating, isAttacking, canDash;

    [SerializeField] private SwordAttack swordAttack;
    public enum MovementDirection { L,R };
    public MovementDirection currentDirection;



    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer playerSprite;


    private void Update()
    {

        setMovementState(movementInput);
        //UpdatedCooldownUI();
    }

    private void FixedUpdate()
    {
        
        move();
        if (movementInput == Vector2.zero && !isAttacking) 
        { anim.Play("Idle"); }
        else if (movementInput != Vector2.zero && !isAttacking)
        { anim.Play("walk"); };

    }

    // Takes movement input
    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
        // Debug.Log("getting movement input" + movementInput);

    }

    // Checks for LEFT MOUSE CLICK or RT
    void OnFire()
    {
        isAttacking = true;
        swordAttack.acttackInDirection(movementInput.normalized, currentDirection);
        anim.Play("SwordAttack");

        
    }

    // Checkts for SHIFT or PUSH RIGHT STICK
    void OnDash()
    {
        if (!canDash) { return; }
        externalMovement = true;
        canDash = false;
        rb.velocity = movementInput * dashSpeed;
        Invoke("endExternalMovement", dashTime);
        Invoke("allowDash", dashRefresh);
    }
    void allowDash()
    {
        canDash = true;
    }

    // Deals with movement input
    private void move()
    {
        // checks for other function needing to control movement
        if (externalMovement) return;

        // fixes sprite
        if(currentDirection == MovementDirection.L)
        {
            playerSprite.flipX = true;
        }
        else if (currentDirection == MovementDirection.R)
        {
            playerSprite.flipX = false;
        }

        //deals with diagonal moving faster
        float diagonalMoveSpeed = movementSpeed * diagonalSpeedFactor;
        if (rb.velocity.x != 0 && rb.velocity.y != 0)
        {
           rb.velocity = movementInput * diagonalMoveSpeed * Time.deltaTime;
           //rb.AddForce(movementInput * diagonalMoveSpeed * Time.deltaTime);
            return;
        }

        rb.velocity = movementInput * movementSpeed * Time.deltaTime;
        //rb.AddForce(movementInput * Time.deltaTime);
        return;
    }

    //Used in other scripts
    public Vector2 getCurrentDirection()
    {
        return movementInput.normalized;
    }

    // Saves last direction sprite is facing
    private void setMovementState(Vector2 movementInput)
    {
        if (directionalyAnimating) return;

        if (movementInput.x > 0) currentDirection = MovementDirection.R;
        if (movementInput.x < 0) currentDirection = MovementDirection.L;

    }

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    public void notAttacking()
    {
        isAttacking = false;
    }

    public void endExternalMovement()
    {
        externalMovement = false;
    }

    public void lockMovement()
    {

    }

    public void unLockMovement()
    {

    }
        
        
        
   }
