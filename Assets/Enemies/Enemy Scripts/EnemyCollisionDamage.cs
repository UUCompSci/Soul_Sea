using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int damage;
    public float knockback;
    Vector2 knockbackDirection;
    public PlayerHealth playerHealth;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Transform enemyPosition;

    // Deals damage to player on contact

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            knockbackDirection = (transform.position - collision.gameObject.transform.position).normalized;
            
            playerHealth.takeDamage(damage, knockback, knockbackDirection);


        }
    }

}