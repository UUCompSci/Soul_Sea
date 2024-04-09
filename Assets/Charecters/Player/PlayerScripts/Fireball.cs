using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fireball : MonoBehaviour
{
    [SerializeField] public Rigidbody2D fireball;
    public float spellSpeed = 20f;
    [SerializeField] public PlayerController playerCotroller;
    [SerializeField] private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnFireball()
    {
        Vector2 playerPosition = playerTransform.position;
        Rigidbody2D newFireball = Instantiate(fireball, playerPosition, Quaternion.identity) as Rigidbody2D;
        Rigidbody rb = newFireball.GetComponent<Rigidbody>();
        //Vector2 launchDirection = playerCotroller.GetComponent<PlayerController.currentDirection>();
        
    
    }

}
