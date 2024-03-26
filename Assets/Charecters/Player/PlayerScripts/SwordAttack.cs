using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    Collider2D swordCollider;
    Vector2 attackOffset;
    [SerializeField] PlayerController player;
    public int swordDamage;


    void Start()
    {
        swordCollider = GetComponent<Collider2D>();
        attackOffset = transform.position;
        swordCollider.isTrigger = true;
        // swordCollider.enabled = false;
        if (player.currentDirection == PlayerController.MovementDirection.L)
        {
            attackLeft();
        }
        else if (player.currentDirection == PlayerController.MovementDirection.R)
        {
            attackRight();
        };
    }

    public void attackRight()
    {
        //swordCollider.enabled = true;
        transform.position = new Vector2(attackOffset.x * -1, attackOffset.y);
        // add delay
        //swordCollider.enabled = false;

    }

    public void attackLeft()
    {
        //swordCollider.enabled = true;
        transform.position = new Vector2(attackOffset.x * -1, attackOffset.y);
        //swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Check if the other collider is an enemy
        if (otherCollider.CompareTag("Enemy"))
        {
            // Get the Enemy script attached to the collided GameObject
            GameObject enemy = otherCollider.gameObject.GetComponent<GameObject>();

            // Check if the Enemy script exists
            if (enemy != null)
            {
                // Handle the collision with the enemy
                Debug.Log("Sword hit an enemy!");
                //enemy.TakeDamage(swordDamage);

                // You can add logic here to damage the enemy or perform other actions
                // add knockback
            }
        }
    }


}
