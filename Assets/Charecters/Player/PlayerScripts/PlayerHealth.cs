using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 10;
    public int health;
    public bool isInvincible = false;
    public float iFrames = 1.0f;
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        
    }

    public void takeDamage(int damage)
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

        }
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health/10f; 
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
}
