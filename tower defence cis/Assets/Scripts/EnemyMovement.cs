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
    public string targetTag;
    public int allySpawnTargetWeight;
    public bool targetingSpawns;

    //vectors for movement
    Vector2 targetLocation;
    Vector2 location;
    Vector2 targetVector;
    AIDestinationSetter pathfinder;

    //attack variables 
    public float attackCD;
    public float chargeCD;
    float maxCD;
    public int damage;
    bool attacking; 
    EnemyTakeDamage damageScript;

    // Start is called before the first frame update
    void Start()
    {
        pathfinder = GetComponent<AIDestinationSetter>();
        maxCD = attackCD;

        //determines if the enemy can attack ally spawns or not
        if (Random.Range(0, 100) >= 100 - allySpawnTargetWeight)
            targetingSpawns = true;
        else
            targetingSpawns = false;
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
        targetList = GameObject.FindGameObjectsWithTag(targetTag);
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
                if (enemy.GetComponent<EnemyMovement>() == null)
                {
                    closestDistance = distance;
                    target = enemy;
                }

                else if(targetingSpawns)
                {
                    
                    closestDistance = distance;
                    target = enemy;
                }
                
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
        if (collision.gameObject == target)
        {
            //on initial collision the enemy attacks the tower faster
            if (attackCD == maxCD)
                attackCD = chargeCD;
            attacking = true;
            damageScript = collision.gameObject.GetComponent<EnemyTakeDamage>();
        }

    }

    //when no longer touching the tower, stop attacking
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == target)
        {
            attacking = false;
            attackCD = maxCD;
            damageScript = null;
        }

    }

    //these do the same thing as collision but allow some enemies to move through ally spawns
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            //on initial collision the enemy attacks the tower faster
            if (attackCD == maxCD)
                attackCD = chargeCD;
            attacking = true;
            damageScript = collision.gameObject.GetComponent<EnemyTakeDamage>();
        }
    }

    //these do the same thing as collision but allow some enemies to move through ally spawns
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == target)
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

            //re asses targetingspawns after each attack, simulates soldiers distracting enemies .
            if (Random.Range(0, 100) >= 100 - allySpawnTargetWeight)
                targetingSpawns = true;
            else
                targetingSpawns = false;
        }
            
        else
            attackCD -= Time.deltaTime;
    }
    
}
