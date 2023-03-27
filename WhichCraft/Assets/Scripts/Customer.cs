using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    //Movement Variables
    public int moveSpeed;
    private Transform waypoint;
    public float timeLeft = 40f;

    //Selling Potion Info
    private int money;
    private string potionCode;
    private double satisfaction;
    // Start is called before the first frame update
    // Random money and potionCode
    void Start()
    {
        satisfaction = 1.00;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setPosition(Transform waitPoint)
    {
        this.waypoint = waitPoint;
        //Debug.Log(this.waypoint);
    }
    public void MoveToWayPoint(Transform waitPoint)
    {
        transform.position = Vector2.MoveTowards(transform.position,
         waitPoint.transform.position, moveSpeed * Time.deltaTime);
    }
}
