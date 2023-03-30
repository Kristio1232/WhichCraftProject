using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    //Movement Variables
    public Animator anim;
    public SpriteRenderer sprite;
    public float moveSpeed = 2f;
    private Transform waypoint;
    public bool timerOn;
    public float timeLeft = 40f;

    //Selling Potion Info
    public int money;
    public string potionCode;
    private double satisfaction;
    
    // Start is called before the first frame update
    // Random money and potionCode
    void Start()
    {
        money = Random.Range(15, 101);
        if (Random.Range(1, 10000) == 1){
            money  = Random.Range(1000, 10000);
        }
        int ran = Random.Range(1, 4);
        potionCode += ran;
        ran = Random.Range(4, 7);
        potionCode += ran;
        int temp = ran;
        while (ran == temp){
            ran = Random.Range(4, 7);
        }
        potionCode += ran;
        //Debug.Log(potionCode);
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

                anim.SetBool("Idle", false);
                anim.SetBool("WalkOut", true);
                sprite.flipX = false;
            }

        }
    }
    public void setPosition(Transform waitPoint)
    {
        this.waypoint = waitPoint;
       // Debug.Log(this.waypoint);
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

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("CustomerGoesIn"))
        {
            Debug.Log("Customer Comes In!");
            anim.SetBool("WalkIn", true);
            sprite.flipX = true;
        }

        if (other.CompareTag("CustomerStops"))
        {
            Debug.Log("Customer Stops Here");
            anim.SetBool("Idle", true);
            anim.SetBool("WalkIn", false);
            sprite.flipX = true;
        }

    }


}
