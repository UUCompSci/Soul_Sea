using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private int maxHealth = 10;
    [SerializeField] public int health;
    private bool isInvincible = false;
    [SerializeField] private float iFrames = 1.0f;
    private bool inHitstun = false;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage, float knockback, Vector2 knockbackDirection)
    {
        if (!isInvincible)
        {
            inHitstun = true;
            hitInvicibility();
            // Debug.Log("is invicible:" + isInvincible+ " Damage:" + damage + " Player Health:" + health);
            if (damage < health)
            {
                health -= damage;
                anim.Play("FireEnemyHit");
                rb.velocity = knockbackDirection * knockback;
            }
            else
            {
                health = 0;
                Debug.Log("Enemy Died");
                anim.Play("FireEnemyDie");
            }

        }
    }


    public void hitInvicibility()
    {
        becomeInvincible();
        Invoke("becomeVincible", iFrames);
    }
    public void becomeInvincible()
    {
        isInvincible = true;
    }
    public void becomeVincible()
    {
        isInvincible = false;
    }
}


