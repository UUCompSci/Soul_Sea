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
    [SerializeField] private float movementSpeed, dashSpeed, dashTime, dashRefresh, timer;
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
        

        if(Input.GetMouseButtonDown(0))
        {
            attack();
        }

        setMovementState(movementInput);
    }

    private void FixedUpdate()
    {
        
        move();
        if (movementInput == Vector2.zero && !isAttacking) 
        { anim.Play("Idle"); }
        else if (movementInput != Vector2.zero && !isAttacking)
        { anim.Play("walk"); };

    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
        // Debug.Log("getting movement input" + movementInput);

    }

    void OnFire()
    {
        isAttacking = true;
        swordAttack.acttackInDirection(movementInput.normalized, currentDirection);
        anim.Play("SwordAttack");

        
    }

    private float lastDashed = 0f; //add this variable for recording the time when a dash is performed

    void OnDash()
    {
        if(!canDash) { return; }
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
        /*    void OnDash()
            {
                if (!canDash) return;
                Debug.Log("start dash");
                externalMovement = true;
                canDash = false;
                rb.velocity = movementInput * dashSpeed * Time.deltaTime;
                allowDash();
            }

            private void allowDash()
            {
                Debug.Log("start allow dash");
                float startTime = Time.time;
                while (timer < dashRefresh)
                {
                    //Debug.Log("delta time: " + Time.deltaTime);
                    //Debug.Log("time: " + Time.time);
                    timer += Time.time - startTime;

                    Cooldown.fillAmount = timer;

                }
                timer = 0;
                endExternalMovement();
                canDash = true;
                Debug.Log("end allow dash");
                return;
            }
        */
        private void move()
    {

        if (externalMovement) return;

        if(currentDirection == MovementDirection.L)
        {
            playerSprite.flipX = true;
        }
        else if (currentDirection == MovementDirection.R)
        {
            playerSprite.flipX = false;
        }

        float diagonalMoveSpeed = movementSpeed * diagonalSpeedFactor;
        if (rb.velocity.x != 0 && rb.velocity.y != 0)
        {
            rb.velocity = movementInput * diagonalMoveSpeed * Time.deltaTime;
            return;
        }

        rb.velocity = movementInput * movementSpeed * Time.deltaTime;
        return;
    }

    private void attack()
    {
        Debug.Log("swinging the sword");
        return;
    }

/*    private void dash()
    {
        dash = playerControls.Player.Dash;
    }*/

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

