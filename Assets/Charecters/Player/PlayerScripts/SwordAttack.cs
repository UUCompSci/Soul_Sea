using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwordAttack : MonoBehaviour
{

    Collider2D swordCollider;
    [SerializeField] private float hitboxOffset = 0.5f;
    [SerializeField] PlayerController player;
    public int swordDamage;


    void Start()
    {
        swordCollider = GetComponent<Collider2D>();
        swordCollider.isTrigger = true;
        swordCollider.enabled = false;

    }

    public void acttackInDirection(Vector2 direction, PlayerController.MovementDirection facing)
    {
        swordCollider.enabled = true;
        Vector2 hitBoxPosition = Vector2.zero;
        if (facing == PlayerController.MovementDirection.L) hitBoxPosition.x = -.7f;
        else if (facing == PlayerController.MovementDirection.R) hitBoxPosition.x = .3f;
        swordCollider.offset = hitBoxPosition;
        


    }


    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Debug.Log("Sword hit something");
        // Check if the other collider is an enemy
        if (otherCollider.CompareTag("Enemy") && player.isAttacking)
        {

            // Get the Enemy script attached to the collided GameObject
            GameObject enemy = otherCollider.gameObject.GetComponent<GameObject>();
            Debug.Log("Sword hit an real enemy!");

            EnemyHealth healthScript = enemy.GetComponent<EnemyHealth>();
            healthScript.takeDamage();
            // Check if the Enemy script exists
            if (enemy != null)
            {
                // Handle the collision with the enemy
                
                //enemy.TakeDamage(swordDamage);

                // You can add logic here to damage the enemy or perform other actions
                // add knockback
            }
        }
    }


}
