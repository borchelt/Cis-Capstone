using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BasicTowerScript : MonoBehaviour
{

    //audio 
    public bool usingAudio;
    public AudioSource audio;

    //placement variables 
    public bool active = true;
    public bool overlapping = false;
    public int cost;
    //target to shoot at
    public string targetTag;
    public GameObject[] targetList;
    public GameObject target;
    public GameObject projectile;
    public GameObject shooter;

    //vectors for shooting
    public float range;
    public float projectileSpeed;
    public float fireRate;
    public float cooldown;
    public int projectileLimit;
    bool onCD;
    public int projectileCount;
    public float spread;
    Vector2 targetLocation;
    Vector2 location;
    Vector2 targetVector;
    public bool prefire;

    //this mask determines what the tower can see through: basic towers cant see through walls, so the mask includes walls. 
    //Mage towers can see through walls, so the mask includes nothing.
    public LayerMask mask;


    // Start is called before the first frame update
    void Start()
    {
        onCD = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(active)
        {
            getClosestTarget();

            if (onCD)
                HandleCooldown();
            else if (target != null || prefire == true)
                fireProjectile();
        }

           
    }

    //gets the closest enemy
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

    //fires a projectile
    private void fireProjectile()
    {
        //checks for number of active projectiles
        if (shooter.transform.childCount >= projectileLimit)
            return;

        //fires directly up if no targets in range and prefire used
        if (prefire && target == null)
        {
            targetLocation = transform.up;
        }
        else
        {
            //get the location of the target
            targetLocation = target.transform.position;
        }

        //get self location
        location = shooter.transform.position;

        //casts a ray to check if the target is behind anything (usually a wall)
        RaycastHit2D aimRay = Physics2D.Raycast(transform.position, targetLocation - location, Vector2.Distance(targetLocation, location), mask);
        Debug.DrawRay(transform.position, targetLocation - location);

        //if the ray collides with something, dont attack
        if (aimRay.collider !=  null && aimRay.collider.tag != targetTag && prefire == false)
        {
            return;
        }

        //if the target it out of range, dont attack
        if( Vector2.Distance(targetLocation, location) > range && prefire == false)
        {
            return;
        }
        //Debug.Log("targeted");

        //for each projectile count, shoot a projectile
        for(int i = projectileCount; i>0 ;i--)
        {
            //Debug.Log("shot");
            //get the projectile rigidbody for movement 
            GameObject proj = Instantiate(projectile, shooter.transform);

            //proj.transform.parent = null;
            Rigidbody2D projRB = proj.GetComponent<Rigidbody2D>();

            //set the fire direction towards the target location
            targetVector = (targetLocation - location);
            float relativeSpread = spread;

            //this section makes sure the projectiles arent offset if multiple are shot 
            bool even;
            int modnum;
            if (projectileCount % 2 == 0)
            {
                even = true;
                modnum = -1;
            }

            else
            {
                even = false;
                modnum = 1;
            }

            //this section sets the rotation of projectiles in the case of multiple being shot
            if (i == 1 && !even)
            {
                relativeSpread = 0;
            }

            else if (i%2==0)
            {
                relativeSpread = spread * (i + modnum);
                Debug.Log(relativeSpread);
            }
            else
            {
                relativeSpread = (spread * i) * -1;
                Debug.Log(relativeSpread);
            }

            
            //rotates the target to introduce spread
            targetVector = Quaternion.AngleAxis(relativeSpread, Vector3.forward) * targetVector;


            //face the target
            proj.transform.up = (targetVector);

            //fire projectile towards the target
            projRB.AddForce(targetVector.normalized * projectileSpeed * Time.fixedDeltaTime / 2);

            onCD = true;
            cooldown = fireRate;
        }

        //plays audio on fire
        if(usingAudio)
        {
            audio.Play();
        }
        

        
    }

    //handles the cooldown on firing projectiles
    private void HandleCooldown()
    {
        //Debug.Log("cd")   
        if (cooldown > 0)
            cooldown -= Time.deltaTime;
        else
            onCD = false;
    }

    //checks for overlapping objects during placement 
    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("collision: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "wall" || (collision.gameObject.tag == "PlayerTower" && collision.gameObject.layer != 10) || collision.gameObject.tag == "trap" || collision.gameObject.tag == "noPlace")
        {
            overlapping = true;

        }

    }

    //updates if no longer colliding with an object
    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "wall" || (collision.gameObject.tag == "PlayerTower" && collision.gameObject.layer != 10) || collision.gameObject.tag == "trap" || collision.gameObject.tag == "noPlace")
        {
            overlapping = false;

        }

    }
}
