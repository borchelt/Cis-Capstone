using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{

    public int hp; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        die();
    }

    public void takeDamage(int damage)
    {
        hp -= damage;
    }

    void die()
    {
        if (hp < 1)
            Destroy(gameObject);
    }
}
