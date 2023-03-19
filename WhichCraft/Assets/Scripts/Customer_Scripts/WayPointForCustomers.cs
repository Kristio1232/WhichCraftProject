using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointForCustomers : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;
    [SerializeField]
    private Transform startingWaypoint;
    [SerializeField]
    private Transform waypoint1;
    [SerializeField]
    private Transform waypoint2;
    [SerializeField]
    private Transform waypoint3;
    [SerializeField]
    private Transform waypoint4;


    public bool waypoint1_Occupied;
    public bool waypoint2_Occupied;
    public bool waypoint3_Occupied;
    public bool waypoint4_Occupied;
   

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector2.MoveTowards(transform.position,
 startingWaypoint.transform.position, moveSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        MoveToWayPoint1();
    }

    private void MoveToWayPoint1()
    {
        transform.position = Vector2.MoveTowards(transform.position,
         waypoint1.transform.position, moveSpeed * Time.deltaTime);

        //waypoint1_Occupied = true;
    }

    private void MoveToWayPoint2()
    {
        transform.position = Vector2.MoveTowards(transform.position,
        waypoint2.transform.position, moveSpeed * Time.deltaTime);

        //waypoint2_Occupied = true;
    }

    private void MoveToWayPoint3()
    {
        transform.position = Vector2.MoveTowards(transform.position,
        waypoint3.transform.position, moveSpeed * Time.deltaTime);

       // waypoint3_Occupied = true;
    }

    private void MoveToWayPoint4()
    {
        transform.position = Vector2.MoveTowards(transform.position,
        waypoint4.transform.position, moveSpeed * Time.deltaTime);

       // waypoint4_Occupied = true;
    }

}
