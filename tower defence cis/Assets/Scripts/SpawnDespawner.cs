using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDespawner : MonoBehaviour
{
    //despawns objects after a while
    public float time;
    public float stuckTime;
    public float countdown;
    Vector3 position;
    Vector3 oldPosition;

    // Start is called before the first frame update
    void Start()
    {
        countdown = stuckTime;
        oldPosition = transform.position;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkStuck();
        timer();
        checkDeath();
    }

    //checks if the object hasnt moved
    void checkStuck()
    {
        position = transform.position;

        if (position == oldPosition)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            countdown = stuckTime;
        }

        oldPosition = transform.position;
    }

    //increments the despawn timer
    void timer()
    {
        time -= Time.deltaTime;
    }

    //if either the stuck timer or normal timer reaches 0, the entitiy despawns 
    void checkDeath()
    {
        if (time <= 0)
            Destroy(gameObject);
        if (countdown <= 0)
            Destroy(gameObject);
    }

}
