using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTowerScript : MonoBehaviour
{

    //target to move at 
    public GameObject[] targetList;
    public GameObject target;
    public GameObject projectile;
    public GameObject shooter;

    //vectors for shooting
    public float range;
    public float projectileSpeed;
    public float fireRate;
    public float cooldown;
    bool onCD;
    Vector2 targetLocation;
    Vector2 location;
    Vector2 targetVector;

    // Start is called before the first frame update
    void Start()
    {
        onCD = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        getClosestTarget();

        if (onCD)
            HandleCooldown();
        else
            fireProjectile();
    }

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

    private void fireProjectile()
    {

 

        if( Vector2.Distance(target.transform.position, location) > range)
        {
            return;
        }
        //get the projectile rigidbody for movement 
        GameObject proj = Instantiate(projectile, shooter.transform);
        proj.transform.parent = null;
        Rigidbody2D projRB = proj.GetComponent<Rigidbody2D>();
        //get the location of the target
        targetLocation = target.transform.position;

        //get self location
        location = shooter.transform.position;

        //set the fire direction towards the target location
        targetVector = (targetLocation - location);

        //face the target
        proj.transform.up = (targetVector);

        //fire projectile towards the target
        projRB.AddForce(targetVector.normalized * projectileSpeed * Time.fixedDeltaTime / 2);

        onCD = true;
        cooldown = fireRate;
    }

    private void HandleCooldown()
    {
        
        if (cooldown > 0)
            cooldown -= Time.deltaTime;
        else
            onCD = false;
    }

}
