using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullEnemies : MonoBehaviour
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

        //for each target in range, set it to tunnel vision and pull it towards the spell
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

    //on destroy, break the spell on enemies nearby 
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
