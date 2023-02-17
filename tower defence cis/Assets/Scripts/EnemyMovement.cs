using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMovement : MonoBehaviour
{
    //enemy movement speed
    public float speed;

    //rigidbody for movement
    public Rigidbody2D rb;

    //target to move at 
    public GameObject[] targetList;
    public GameObject target;

    //vectors for movement
    Vector2 targetLocation;
    Vector2 location;
    Vector2 targetVector;
    AIDestinationSetter pathfinder;

    //attack variables 
    public float attackCD;
    float maxCD;
    public int damage;
    bool attacking; 
    EnemyTakeDamage damageScript;

    // Start is called before the first frame update
    void Start()
    {
        pathfinder = GetComponent<AIDestinationSetter>();
        maxCD = attackCD;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        getClosestTarget();
        pathfinder.target = target.transform;
        //movement();
        if (attacking)
            attack();
    }

    //get the closest target
    private void getClosestTarget()
    {
        //list of all possible targets
        targetList = GameObject.FindGameObjectsWithTag("PlayerTower");
        target = null;

        //setting up a for each loop
        float closestDistance = Mathf.Infinity;
        location = transform.position;

        //for each possible target, check if it is closer than the last target and update the current target to be the closest one
        foreach(GameObject enemy in targetList)
        {
            float distance = Vector2.Distance(enemy.transform.position, location);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                target = enemy;
            }
        }
    }

    //move at the target (depricated)
    private void movement()
    {

        //get the location of the target
        targetLocation = target.transform.position;

        //get self location
        location = transform.position;

        //set the movement direction towards the target location
        targetVector = (targetLocation - location);

        //move towards the target
        rb.velocity = targetVector.normalized * speed * Time.fixedDeltaTime / 2;

    }
    

    //when colliding with something, check if its a tower, then begin to attack it
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerTower")
        {
            //on initial collision the enemy attacks the tower
            if (attackCD == maxCD)
                attackCD = 0;
            attacking = true;
            damageScript = collision.gameObject.GetComponent<EnemyTakeDamage>();
        }

    }

    //when no longer touching the tower, stop attacking
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerTower")
        {
            attacking = false;
            attackCD = maxCD;
            damageScript = null;
        }

    }

    //use a cooldown to damage the tower every so often 
    private void attack()
    {
        if (attackCD < 0)
            attackCD = 0;

        if (attackCD == 0)
        {
            damageScript.takeDamage(damage);
            attackCD = maxCD;
        }
            
        else
            attackCD -= Time.deltaTime;
    }
    
}
