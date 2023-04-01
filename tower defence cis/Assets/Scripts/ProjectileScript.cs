using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    //setting up variables
    public bool active = true;
    public bool overlapping = false;
    public int cost;
    EnemyTakeDamage damageScript;
    public float damage;
    public float duration;
    public string targetTag;
    public bool small;
    //list of tags that will modify projectiles. 
    //current tags:
    //tracking - tracks enemies
    //ghost - can go through walls
    //static - locks projectile in place
    //instant - projectile teleports to the closest target, only works with tracking turned on.
    //exploding - projectile explodes into aoe on impact, dealing damage to enemies within its aoe x amount of times (x = ticks ) at y speed (y = tickrate)
    //note: for some unknown reason, exploding only works while tracking is also enabled. To turn on tracking without any actual tracking just set the projectile speed to 0
    //persistent - projectile doesnt dissapear on contact with an enemy 
    public List<string> tags = new List<string>();

    Rigidbody2D rb;

    //this stuff is for the tracking and instant tags
    Vector2 targetLocation;
    Vector2 location;
    Vector2 targetVector;
    public GameObject[] targetList;
    public GameObject target;
    public int speed;
    bool hasTeleported = false;

    //this stuff is for the exploding tag
    public float aoe;
    public int ticks;
    public float tickRate;
    public float cd;
    bool exploded;
    public GameObject spriteHandler;
    SpriteRenderer explosionSprite;
    public Sprite explosion;
    public float initialCD;

    //this stuff is for the persistent tag
    public float collisions;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //setting up explosion sprite stuff
        if (spriteHandler != null)
        {
            explosionSprite = spriteHandler.GetComponent<SpriteRenderer>();
            explosionSprite.enabled = false;
        }
    }

    //when hitting something, check if its an enemy or a wall and respond accordingly 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (exploded)
            return;

        if (collision.gameObject.tag == targetTag)
        {
            damageScript = collision.gameObject.GetComponent<EnemyTakeDamage>();
            damageScript.takeDamage(damage);
            checkDestroy();
        }

        if (collision.gameObject.layer == 8 && !tags.Contains("ghost"))
            checkDestroy();

    }

    

    private void FixedUpdate()
    {

        if(active)
        {
            //counting down until the projectile despawns
            duration -= Time.deltaTime;
            if (duration <= 0)
                checkDestroy();
            //if the projectile has exploded start using the explosion handler 
            if (exploded)
                explosionHandler();

            //use the tracking specific functions if the projectile is tracking
            if (tags.Contains("tracking"))
            {
                getClosestTarget();
                movement();
            }

            //if static freeze position
            if (tags.Contains("static"))
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
       
    }

    //move at the target
    private void movement()
    {

        //get the location of the target
        if(target != null)
            targetLocation = target.transform.position;

        //if instant tag, teleport to target location
        if(tags.Contains("instant") && !hasTeleported)
        {
            Debug.Log("target: "+target);
            transform.position = target.transform.position;
            hasTeleported = true;
            return;
        }
        //if instant 
        else if(tags.Contains("instant"))
        {
            return;
        }


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
        targetList = GameObject.FindGameObjectsWithTag(targetTag);
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

    //handles exploded projectiles
    private void explosionHandler()
    {
        //set up explosion size and sprite
        targetList = GameObject.FindGameObjectsWithTag(targetTag);
        spriteHandler.transform.localScale = new Vector3(aoe / 5, aoe / 5);
        explosionSprite.enabled = true;

        //if the last tick was long enough ago, do another
        if (cd <= 0)
        {
            //if no ticks left, destroy self
            if (ticks <= 0)
                Destroy(gameObject);

            cd = tickRate;

            //damage each enemy within the aoe
            foreach (GameObject enemy in targetList)
            {
                float distance = Vector2.Distance(enemy.transform.position, location);
                if (distance < aoe)
                {
                    damageScript = enemy.GetComponent<EnemyTakeDamage>();
                    damageScript.takeDamage(damage);
                    explosionSprite.color = Color.red;
                }
            }

            //subtract one from the tick count
            ticks--;

        }

        //lower the cooldown
        cd -= Time.deltaTime;
    }

    //checks if a projectile should explode instead of being destroyed
    public void checkDestroy()
    {
        if (tags.Contains("persistent") && duration > 0 && collisions > 0)
        {
            collisions -= 1;
            return;
        }
            
           

        if (tags.Contains("exploding") && !exploded)
        {
            exploded = true;
            cd = initialCD;
            explosionSprite.sprite = explosion;

        }

        else if(exploded)
        {
            return;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "wall" || (collision.gameObject.tag == "PlayerTower" && collision.gameObject.layer != 10))
        {
            overlapping = true;

        }
        else
        {
            overlapping = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("collision: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "wall" || (collision.gameObject.tag == "PlayerTower" && collision.gameObject.layer != 10))
        {
            overlapping = false;

        }

    }
}
