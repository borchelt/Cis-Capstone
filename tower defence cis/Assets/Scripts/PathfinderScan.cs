using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PathfinderScan : MonoBehaviour
{

    public AstarPath path;

    // Start is called before the first frame update
    void Start()
    {
        path = GetComponent<AstarPath>();
    }

    // Update is called once per frame
    void Update()
    {
        path.Scan();
    }
}
