using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        getClosestTarget();
        movement();
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

    //move at the target
    private void movement()
    {

        //get the location of the target
        targetLocation = target.transform.position;

        //get self location
        location = transform.position;

        //set the movement direction towards the target location
        targetVector = (targetLocation - location);

        //face the target
        transform.up = (targetVector) * -1;

        //move towards the target
        rb.velocity = targetVector.normalized * speed * Time.fixedDeltaTime / 2;

    }
}
