using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 10;
    public int health;
    public bool isInvincible = false;
    public float iFrames = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
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
                Debug.Log("Enemy Died");
                Destroy(gameObject);
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


