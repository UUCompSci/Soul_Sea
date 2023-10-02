using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    Vector2 movementInput;
    //SpriteRenderer spriteRenderer;
    //Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    Rigidbody2D playerRB;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        // if no input - temp nothing
        
        
        // if movement
        if (movementInput != Vector2.zero){
            bool canMove = TryMove(movementInput);
            if (!canMove){
                canMove = TryMove(new Vector2(movementInput.x, 0)); 
            }

            if (!canMove){
                canMove = TryMove(new Vector2(0, movementInput.y));
            }
            

        }



    }

    void OnMove(InputValue movementValue){
        movementInput = movementValue.Get<Vector2>();

    }


    private bool TryMove(Vector2 direction) {
        if(direction != Vector2.zero) {
            // Check for potential collisions
            int count = playerRB.Cast(
                direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions
                movementFilter, // The settings that determine where a collision can occur on such as layers to collide with
                castCollisions, // List of collisions to store the found collisions into after the Cast is finished
                moveSpeed * Time.fixedDeltaTime + collisionOffset); // The amount to cast equal to the movement plus an offset

            if(count == 0){
                playerRB.MovePosition(playerRB.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            } else {
                return false;
            }
        } else {
            // Can't move if there's no direction to move in
            return false;
        }
        
    }
}
