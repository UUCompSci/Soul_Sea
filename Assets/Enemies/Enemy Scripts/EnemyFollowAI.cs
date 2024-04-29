using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;

public class EnemyFollowAI : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed, noticeRange, distanceToPlayer;
    [SerializeField] private Transform player;
    [SerializeField] public bool shouldRotate;

    



    // Start is called before the first frame update
    void Start()
    {
        distanceToPlayer = Vector2.Distance(player.position, transform.position);
        Debug.Log("distanceToPlayer: " + distanceToPlayer);
        move();
        //shouldRotate = true;
    }

    // Update is called once per frame
    void Update()
    {

        distanceToPlayer = Vector2.Distance(player.position, transform.position);
        move();
        if(shouldRotate)rotateToPlayer();

    }
    
    // Moves directly towards player when player is close enough

    private void move()
    {
        
        if (distanceToPlayer < noticeRange)
        {
            Vector2 moveDirection = (player.position - transform.position).normalized;
            rb.AddForce(moveDirection * speed);
        }
    }

    private void rotateToPlayer() 
    {
        Vector2 directionToPlayer = player.position - transform.position;
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x); //* Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }
}
