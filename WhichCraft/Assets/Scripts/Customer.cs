using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    //Movement Variables
    public float moveSpeed = 2f;
    private Transform waypoint;
    public bool timerOn;
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
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
                MoveToWayPoint(waypoint);
            }
            else
            {
                //Customer Leaves
                MoveToWayPoint(waypoint);
            }

        }
    }
    public void setPosition(Transform waitPoint)
    {
        this.waypoint = waitPoint;
        Debug.Log(this.waypoint);
    }
    public void MoveToWayPoint(Transform waitPoint)
    {
        transform.position = Vector2.MoveTowards(transform.position,
         waitPoint.transform.position, moveSpeed * Time.deltaTime);
    }

    public void updateTimer(float currentTime)
    {
        currentTime += 1;
        float seconds = Mathf.FloorToInt(currentTime % 60);
    }
}
