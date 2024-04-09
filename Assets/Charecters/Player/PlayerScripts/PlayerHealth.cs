using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] public int maxHealth = 10;
    [SerializeField] public int health;
    [SerializeField] public bool isInvincible = false;
    [SerializeField] public float iFrames = 1.0f;
    [SerializeField] public float knockbackTime = .5f;
    [SerializeField] public Image healthBar;
    [SerializeField] private Rigidbody2D rb;
    public PlayerController player;
    

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        
    }

    public void takeDamage(int damage, float knockback, Vector2 knockbackDirection)
    {
        if (!isInvincible)
        {
            hitInvicibility();
            // Debug.Log("is invicible:" + isInvincible+ " Damage:" + damage + " Player Health:" + health);
            if (damage < health)
            {
                health -= damage;
            }
            else
            {
                health = 0;
                Debug.Log("Player Died, healing to full health");
                health = maxHealth;
            }
            player = GetComponent<PlayerController>();
            player.externalMovement = true;
            rb.velocity = knockback * knockbackDirection * Time.deltaTime;
            Invoke("endKnockback", knockbackTime);

        }
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health/maxHealth; 
    }

    public void hitInvicibility()
    {
        becomeInvincible();
        Invoke ("becomeVincible", iFrames);
    }

    public void becomeInvincible()
    {
        isInvincible = true;
    }
    public void becomeVincible()
    {
        isInvincible = false;
    }

    public void endKnockback()
    {
        player.externalMovement = false;
    }
}
