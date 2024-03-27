using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class enemyCircleAI : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float speed, noticeRange, circleRange, distanceToPlayer;

    [SerializeField]
    private Transform player;





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

        if (distanceToPlayer < noticeRange && distanceToPlayer > circleRange)
        {

            Vector2 moveDirection = (player.position - transform.position).normalized;
            rb.AddForce(moveDirection * speed);
        }else if (distanceToPlayer <= circleRange)
        {
            Vector2 moveDirection = rotate((player.position - transform.position).normalized, 90);
            rb.AddForce(moveDirection * speed);
        }
    }

   
    public static Vector2 rotate(Vector2 v, float delta)
    {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }
}
