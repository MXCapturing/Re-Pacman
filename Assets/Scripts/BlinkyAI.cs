using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BlinkyAI : MonoBehaviour
{
    public Transform target;

    public float speed;
    public float nextWaypointDistance;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath()
    {
        seeker.StartPath(transform.position, target.position + (target.transform.right * 4), OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
