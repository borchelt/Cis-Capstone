using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    //setting up variables
    EnemyTakeDamage damageScript;
    public int damage;
    public float duration;

    //list of tags that will modify projectiles. 
    //current tags:
    //tracking - tracks enemies
    //ghost - can go through walls
    public List<string> tags = new List<string>();

    Rigidbody2D rb;

    //this stuff is for the tracking tag
    Vector2 targetLocation;
    Vector2 location;
    Vector2 targetVector;
    public GameObject[] targetList;
    public GameObject target;
    public int speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //when hitting something, check if its an enemy or a wall and respond accordingly 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            damageScript = collision.gameObject.GetComponent<EnemyTakeDamage>();
            damageScript.takeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "wall" && !tags.Contains("ghost"))
            Destroy(gameObject);
            
    }

    private void FixedUpdate()
    {
        //counting down until the projectile despawns
        duration -= Time.deltaTime;
        if (duration <= 0)
            Destroy(gameObject);

        //use the tracking specific functions if the projectile is tracking
        if(tags.Contains("tracking"))
        {
            getClosestTarget();
            movement();
        }
    }

    //move at the target
    private void movement()
    {

        //get the location of the target
        targetLocation = target.transform.position;

        //get self location
        location = transform.position;

        //set the movement direction towards the target location
        targetVector = (targetLocation - location);

        //move towards the target
        rb.AddForce(targetVector.normalized * speed * Time.fixedDeltaTime);

    }

    //get the closest target
    private void getClosestTarget()
    {
        //list of all possible targets
        targetList = GameObject.FindGameObjectsWithTag("enemy");
        target = null;

        //setting up a for each loop
        float closestDistance = Mathf.Infinity;
        location = transform.position;

        //for each possible target, check if it is closer than the last target and update the current target to be the closest one
        foreach (GameObject enemy in targetList)
        {
            float distance = Vector2.Distance(enemy.transform.position, location);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                target = enemy;
            }
        }
    }
}
