using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which Customer walks
    // to the next one
    private int waypointIndex = 0;

    // Use this for initialization
    private void Start()
    {

        // Set position of Customer as position of the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    private void Update()
    {

        // Move Customer
        Move();
    }

    // Method that actually make Customer walk
    private void Move()
    {
        // If Customer didn't reach last waypoint it can move
        // If Customer reached last waypoint then it stops
        if (waypointIndex <= waypoints.Length - 1)
        {

            // Move Customer from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector2.MoveTowards(transform.position,
               waypoints[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);

            // If Customer reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Customer starts to walk to the next waypoint
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }
}
