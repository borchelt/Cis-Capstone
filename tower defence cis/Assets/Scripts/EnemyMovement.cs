using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Audio;

public class EnemyMovement : MonoBehaviour
{

    //for audio 
    public AudioSource walkAudio;
    bool playsAudioOnWalk;
    //for allied units to stay close 
    GameObject parentTower;
    public bool stayClose;
    public GameObject patrolPointEmpty;
    GameObject destination;

    public bool worm;
    public bool small;
    bool worming;
    float wormCD;

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
    float trapCd = .1f; 

    //attack variables 
    public float attackCD;
    public float chargeCD;
    float maxCD;
    public int damage;
    public bool attacking; 
    public EnemyTakeDamage damageScript;

    //for calculating wave spawns
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        if (walkAudio == null)
            playsAudioOnWalk = false;
        else
            playsAudioOnWalk = true;
            
        //moves the reference two objects up 
        if(stayClose)
            parentTower = gameObject.transform.parent.gameObject.transform.parent.gameObject;

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
        if(playsAudioOnWalk)
            manageSound();
        trapCd -= Time.deltaTime;
        getClosestTarget();
        setDestination();
            
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
            if (playsAudioOnWalk)
                walkAudio.Stop();
            //on initial collision the enemy attacks the tower faster
            if (attackCD == maxCD)
                attackCD = chargeCD;
            attacking = true;
            damageScript = collision.gameObject.GetComponent<EnemyTakeDamage>();
        }

        if(collision.gameObject.layer == 15 && targetTag == "PlayerTower")
        {
            
            ProjectileScript trap = collision.gameObject.GetComponent<ProjectileScript>();
            if (!trap.active)
                return;
            if (!small && trap.small)
                return;

            trap.trapAnim();
            damageScript = gameObject.GetComponent<EnemyTakeDamage>();
            damageScript.takeDamage(trap.damage);
            trap.checkDestroy();

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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            //on initial collision the enemy attacks the tower faster
            attacking = true;
           damageScript = collision.gameObject.GetComponent<EnemyTakeDamage>();
         }

    }

    private void manageSound()
    {
        if(attacking)
        {
            walkAudio.Stop();
        }
        else if(!walkAudio.isPlaying)
        {
            walkAudio.Play();
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

            if (worm && Random.Range(0,6) >= 3)
            {
                float range = 30;
                Vector3 patrolPoint = new Vector3(Random.Range(-range, range), Random.Range(-range, range)) + transform.position;
                destination = Instantiate(patrolPointEmpty, patrolPoint, Quaternion.identity);
                pathfinder.target = destination.transform;
                worming = true;
                wormCD = 5;
            }
        }
            
        else
            attackCD -= Time.deltaTime;
    }

    //checks if the target is within the tower's range if an ally unit, if not within range, it creates a random point to move to to simulate patroling 
    private void setDestination()
    {
        if (worming)
        {
            wormCD -= Time.deltaTime;
            if (wormCD <= 0)
                worming = false;
            return;
        }
        //if it needs to stay close to a parent, check if the target is within the parent range
        if (stayClose && target && Vector2.Distance(target.transform.position, parentTower.transform.position) < parentTower.GetComponent<BasicTowerScript>().range)
            pathfinder.target = target.transform;

        //if it doesnt need to stay close, just go there
        else if (!stayClose && target)
            pathfinder.target = target.transform;

        //if it does need to stay close but the target is too far away, create a random point and move there
        else if (stayClose)
        {
            if (destination == null)
            {
                float range = parentTower.GetComponent<BasicTowerScript>().range;
                Vector3 patrolPoint = new Vector3(Random.Range(-range, range), Random.Range(-range, range)) + parentTower.transform.position;
                destination = Instantiate(patrolPointEmpty, patrolPoint, Quaternion.identity);
                pathfinder.target = destination.transform;
            }
            else
                pathfinder.target = destination.transform;
        }

        if (worm)
        {
            Vector3 vector = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
            Vector3 patrolPoint = vector + pathfinder.target.transform.position;
            destination = Instantiate(patrolPointEmpty, patrolPoint, Quaternion.identity);
            pathfinder.target = destination.transform;
        }
           
    }
    
}
