using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMovement1 : MonoBehaviour
{

    

    //rigidbody for movement
    public Rigidbody2D rb;

    //target to move at 
    public GameObject target;

    //vectors for movement
    Vector2 targetLocation;
    Vector2 location;
    Vector2 targetVector;
    AIDestinationSetter pathfinder;

    //for calculating wave spawns
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        pathfinder = GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        setDestination();
    }




    //checks if the target is within the tower's range if an ally unit, if not within range, it creates a random point to move to to simulate patroling 
    private void setDestination()
    {
        pathfinder.target = target.transform;
    }
    
}
