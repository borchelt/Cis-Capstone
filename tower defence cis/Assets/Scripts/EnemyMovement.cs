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

    //for the third boss
    public bool worm;
    bool worming;
    float wormCD;

    //for trap sorting
    public bool small;

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
    public AIDestinationSetter pathfinder;
    float trapCd = .1f; 

    //attack variables 
    public float attackCD;
    public float chargeCD;
    float maxCD;
    public int damage;
    public bool attacking; 
    public EnemyTakeDamage damageScript;

    //for the gravity spell
    public bool tunnelVision;

    // Start is called before the first frame update
    void Start()
    {
        //check if there is audio for when the enemy is moving
        if (walkAudio == null)
            playsAudioOnWalk = false;
        else
            playsAudioOnWalk = true;
            
        //moves the parent tower reference two objects up for summoned allies  
        if(stayClose)
            parentTower = gameObject.transform.parent.gameObject.transform.parent.gameObject;

        //setting up initial variables
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
        //handle sound 
        if(playsAudioOnWalk)
            manageSound();
        //this stops enemies from taking trap damage every frame
        trapCd -= Time.deltaTime;
        
        //find the closest target ifthe enemy doesnt have tunnel vision
        if(!tunnelVision)
            getClosestTarget();
        setDestination();
            
       //handles attacks
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
            //stop playing movement audio if colliding with the target
            if (playsAudioOnWalk)
                walkAudio.Stop();

            //on initial collision the enemy attacks the tower faster
            if (attackCD == maxCD)
                attackCD = chargeCD;
            attacking = true;
            damageScript = collision.gameObject.GetComponent<EnemyTakeDamage>();
        }

        //detects & triggers traps
        if((collision.gameObject.layer == 15 || collision.gameObject.layer == 9) && targetTag == "PlayerTower")
        {
            
            ProjectileScript trap = collision.gameObject.GetComponent<ProjectileScript>();
            //doesn't trigger the trap if it's not small for a small trap or if the trap isnt active
            if (!trap.active)
                return;
            if (!small && trap.small)
                return;

            //triggers the trap
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

    //deals with the walking audio
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
            
            //re asses targetingspawns after each attack, simulates soldiers distracting enemies
            if (Random.Range(0, 100) >= 100 - allySpawnTargetWeight)
                targetingSpawns = true;
            else
                targetingSpawns = false;

            //if the enemy is a worm it will attack before having a chance to run away temporarily
            if (worm && Random.Range(0,6) >= 3)
            {
                //set a patrol point at a random vector
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

    //deals with setting the target location of an enemy 
    private void setDestination()
    {
        //if a worm is currently running away, count the cooldown until it starts attacking again
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
                //set a patrol point at a random vector
                float range = parentTower.GetComponent<BasicTowerScript>().range;
                Vector3 patrolPoint = new Vector3(Random.Range(-range, range), Random.Range(-range, range)) + parentTower.transform.position;
                destination = Instantiate(patrolPointEmpty, patrolPoint, Quaternion.identity);
                pathfinder.target = destination.transform;
            }
            else
                pathfinder.target = destination.transform;
        }

        //special movement stuff for worms
        if (worm)
        {
            //makes a patrol point past the target for the worm to follow
            Vector3 vector = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
            Vector3 patrolPoint = vector + pathfinder.target.transform.position;
            destination = Instantiate(patrolPointEmpty, patrolPoint, Quaternion.identity);
            pathfinder.target = destination.transform;
        }
           
    }
    
}
