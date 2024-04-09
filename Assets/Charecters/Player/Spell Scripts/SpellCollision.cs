using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCollision : MonoBehaviour
{

    public int damage;
    public float knockback;
    Vector2 knockbackDirection;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            knockbackDirection = (collision.gameObject.transform.position - transform.position).normalized;

            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.takeDamage(damage, knockback, knockbackDirection);


        }
        else
        {
            Destroy(gameObject);
        }
    }

}
    

