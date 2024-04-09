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
            Debug.Log("frieball hit enemy");
            knockbackDirection = (collision.gameObject.transform.position - transform.position).normalized;

            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.takeDamage(damage, knockback, knockbackDirection);
            Destroy(gameObject);

        }
        else if (collision.gameObject.CompareTag("Barrier"))
        {
            Debug.Log("fireball collided with non-enemy, destroying");
            Destroy(gameObject);
        }
    }

}
    

