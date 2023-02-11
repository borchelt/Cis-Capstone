using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    EnemyTakeDamage damageScript;
    public int damage;
    public float duration;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            damageScript = collision.gameObject.GetComponent<EnemyTakeDamage>();
            damageScript.takeDamage(damage);
            Destroy(gameObject);
        }
            
    }

    private void FixedUpdate()
    {
        duration -= Time.deltaTime;
        if (duration <= 0)
            Destroy(gameObject);
    }
}
