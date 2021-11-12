using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PinkyAI : MonoBehaviour
{
    public Transform target;
    public Transform[] scatterPoints;
    int scatterPointNumber = 0;

    public float speed;
    public float nextWaypointDistance;
    float distance;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();

        ChangePath();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.instance.ghostState == GhostState.Chase || GameManager.instance.ghostState == GhostState.Frightened)
        {
            if (collision.CompareTag("Intersections"))
            {
                ChangePath();
            }
        }
    }

    public void ChangePath()
    {
        switch (GameManager.instance.ghostState)
        {
            case GhostState.Chase:
                seeker.StartPath(transform.position, target.position + (target.right * 4), OnPathComplete);
                scatterPointNumber = 0;
                break;

            case GhostState.Scatter:
                seeker.StartPath(transform.position, scatterPoints[scatterPointNumber].position, OnPathComplete);
                scatterPointNumber++;
                if (scatterPointNumber >= scatterPoints.Length)
                {
                    scatterPointNumber = 0;
                }
                break;

            case GhostState.Frightened:
                Vector3 fleeDir = transform.position - target.position;
                seeker.StartPath(transform.position, fleeDir, OnPathComplete);
                break;
        }
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
    void FixedUpdate()
    {
        if (path != null)
        {
            if (currentWaypoint >= path.vectorPath.Count)
            {
                reachedEndOfPath = true;
            }
            else
            {
                reachedEndOfPath = false;
            }

            //Vector2 direction = (path.vectorPath[currentWaypoint] - transform.position).normalized;
            float stepScatter = speed * Time.deltaTime;

            if (reachedEndOfPath)
            {
                ChangePath();
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, path.vectorPath[currentWaypoint], stepScatter);
                distance = Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]);
            }
        }
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
