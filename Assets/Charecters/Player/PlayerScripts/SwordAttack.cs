using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    Collider2D swordCollider;
    Vector2 attackOffset;

    void Start()
    {
        swordCollider = GetComponent<Collider2D>();
        attackOffset = transform.position;
    }

    public void attack(){
        
    }
     

    public void attackRight(){
        swordCollider.enabled = true;
        transform.position = rightAttackOffset;

    }

    public void attackLeft() {
        transform.position = new Vector2(attackOffset.x * -1, attackOffset.y);
    }




    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
