using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float speed;
    [SerializeField] float detectionRange;

    private int currentWaypointIndex = 0;
    [SerializeField] Transform player;
    private bool isChasingPlayer = false;
    private Vector3 previousWaypointDirection;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        previousWaypointDirection = waypoints[0].forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasingPlayer)
        {
            ChasePlayer();
        }
        else
        {
            FollowWaypoints();
        }
    }



    bool CanSeePlayer()
    {
        RaycastHit hit;
        Vector3 direction = player.position - transform.position;

        if (Physics.Raycast(transform.position, direction, out hit, detectionRange))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                return true;
            }
        }

        return false;
    }

    void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (!CanSeePlayer())
        {
            isChasingPlayer = false;
        }
    }





    void FollowWaypoints()
    {
        if (waypoints.Length == 0)
        {
            return;
        }

        Transform currentWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = currentWaypoint.forward;

        // Check if the current waypoint has a different direction than the previous waypoint
        if (Vector3.Dot(direction, previousWaypointDirection) < 0.5f)
        {
            currentWaypointIndex = Random.Range(0, waypoints.Length);
            currentWaypoint = waypoints[currentWaypointIndex];
            direction = currentWaypoint.forward;
        }

        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentWaypoint.position) < 0.1f)
        {
            previousWaypointDirection = direction;
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

        if (CanSeePlayer())
        {
            isChasingPlayer = true;
        }
    }
}
