using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{

    public Collider2D swordCollider;
    public int swordDamage = 10;


    // Start is called before the first frame update
    void Start()
    {
        if (swordCollider != null)
        {
            swordCollider.GetComponent<Collider2D>();

        }else
        {
            Debug.Log("Sworfd Collider Not Set");
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        collider.SendMessage("on hit", swordDamage);
    }
}
