using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fireball : MonoBehaviour
{
    [SerializeField] public Rigidbody2D fireball;
    public float spellSpeed;
    [SerializeField] public PlayerController playerCotroller;
    [SerializeField] public PlayerMana playerMana;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float spellDuration = 50f;
    [SerializeField] private int manaCost;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnFireball()
    {
        playerMana = GetComponent<PlayerMana>();
        
        if (playerMana.useMana(manaCost))
        {
            Debug.Log("player current mana: " + playerMana.mana + "mana use: " + manaCost);
            Vector2 playerPosition = playerTransform.position;
            Rigidbody2D newFireball = Instantiate(fireball, playerPosition, Quaternion.identity) as Rigidbody2D;
            //Rigidbody2D rb = newFireball.GetComponent<Rigidbody2D>();
            //rb.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
            Vector2 launchDirection = playerCotroller.getCurrentDirection();
            newFireball.AddForce(launchDirection * spellSpeed);
            //Debug.Log("frieball destruction started");
            //Destroy(newFireball.gameObject, spellDuration);
        }
        else
        {
            Debug.Log("not enough mana!");
        }

    }

}
