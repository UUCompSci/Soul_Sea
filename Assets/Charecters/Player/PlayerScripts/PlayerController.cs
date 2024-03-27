using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using static UnityEngine.UI.ScrollRect;
using System.Net.Security;
using Unity.VisualScripting;


public class PlayerController : MonoBehaviour
{
    public InputAction inputAction;
    public PlayerInputActions playerControls;
    private InputAction dash;
    [SerializeField] private Vector2 movementInput;
    [SerializeField] private float movementSpeed, dashSpeed, dashTime;
    [SerializeField, Range(0, 1)] private float diagonalSpeedFactor = .7f;
    [SerializeField] private Rigidbody2D rb;
    public bool externalMovement = false;
    public bool directionalyAnimating = false;
    public enum MovementDirection { L,R,U,D,UL,DL,UR,DR };
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

    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
        // Debug.Log("getting movement input" + movementInput);

    }

    void OnFire()
    {
        anim.SetTrigger("swordAttack");
    }

    private void Dash(InputAction.CallbackContext context)
    {
        Debug.Log("we are dashing");
    }

    void onDash()
    {
        Debug.Log("dash");
        externalMovement = true;
        rb.velocity = movementInput * dashSpeed * Time.deltaTime;
        Invoke("endExternalMovement", dashTime);
    }

    private void move()
    {

        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        if (externalMovement) return;

        if(currentDirection == MovementDirection.L)
        {
            playerSprite.flipX = true;
        }
        else
        {
            playerSprite.flipX = false;
        }

        float diagonalMoveSpeed = movementSpeed * diagonalSpeedFactor;
        if (rb.velocity.x != 0 && rb.velocity.y != 0)
        {
            rb.velocity = movementInput * diagonalMoveSpeed * Time.deltaTime;
            return;
        }

        // Debug.Log("movent input: " + movementInput);
        rb.velocity = movementInput * movementSpeed * Time.deltaTime;
        // Debug.Log("rb.velocity: " + rb.velocity);
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

        if (movementInput.x > 0)
        {
            if(movementInput.y > 0 )
            {
                currentDirection = MovementDirection.UR;
            }
            currentDirection = MovementDirection.R;
        }
        else if (movementInput.x < 0)
        {
            currentDirection = MovementDirection.L;
        }
        else if (movementInput.y > 0)
        {
            currentDirection = MovementDirection.U;
        }
        else if (movementInput.y < 0)
        {
            currentDirection = MovementDirection.D;
        }


    }

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }


/*    private void OnEnable()
    {
        Dash = playerControls.Player.Dash;
    }

    private void OnDisable()
    {
        Dash.Disable();
    }
*/


    public void endExternalMovenment()
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

