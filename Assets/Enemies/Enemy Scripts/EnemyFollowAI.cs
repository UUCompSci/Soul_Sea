using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed, noticeRange, distanceToPlayer;
    [SerializeField] private Transform player;

    



    // Start is called before the first frame update
    void Start()
    {
        distanceToPlayer = Vector2.Distance(player.position, transform.position);
        Debug.Log("distanceToPlayer: " + distanceToPlayer);
        move();
    }

    // Update is called once per frame
    void Update()
    {

        distanceToPlayer = Vector2.Distance(player.position, transform.position);
        move();

    }

    private void move()
    {
        
        if (distanceToPlayer < noticeRange)
        {
            
            Vector2 moveDirection = (player.position - transform.position).normalized;
            rb.velocity = moveDirection * speed * Time.deltaTime;
        }
    }
}
