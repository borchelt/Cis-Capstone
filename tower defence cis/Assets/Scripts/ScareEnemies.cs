using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareEnemies : MonoBehaviour
{
    public GameObject[] targetList;
    public Vector2 location;
    public bool active;
    public float range;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.parent.GetComponent<ProjectileScript>().active)
        {
            getClosestTarget();
        }
    }

    //get the closest target
    private void getClosestTarget()
    {
        //list of all possible targets
        targetList = GameObject.FindGameObjectsWithTag("enemy");

        //setting up a for each loop
        location = transform.position;

        //for each possible target, check if it is closer than the last target and update the current target to be the closest one
        foreach (GameObject enemy in targetList)
        {
            float distance = Vector2.Distance(enemy.transform.position, location);
            if (distance < range)
            {
                if (enemy.GetComponent<EnemyMovement>() != null)
                {
                    enemy.GetComponent<EnemyMovement>().tunnelVision = true;
                    enemy.GetComponent<EnemyMovement>().target = gameObject;
                }

            }
        }

    }

    private void OnDestroy()
    {
        foreach (GameObject enemy in targetList)
        {
            float distance = Vector2.Distance(enemy.transform.position, location);
            if (distance < range*2)
            {
                enemy.GetComponent<EnemyMovement>().tunnelVision = false;

            }
        }
    }
}
