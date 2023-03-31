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

    //order thought bubbles
    public GameObject order145;
    public GameObject order256;
    public GameObject order346;
    public GameObject order156;
    public GameObject order345;
    public GameObject order246;

    //instances of thought bubble order "_ _ _"
    private GameObject instance_145;
    private GameObject instance_256;
    private GameObject instance_346;
    private GameObject instance_156;
    private GameObject instance_345;
    private GameObject instance_246;



    //Potion Code pattern 
    // 2 beakers = code numbers 1, 2, 3
    // 3 ingredients = code numbers 4, 5, 6 


    // Random money and potionCode
    void Start()
    {
        money = Random.Range(15, 101);
        if (Random.Range(1, 10000) == 1){
            money  = Random.Range(1000, 10000);
        }
        
        int ran = Random.Range(1, 7);
        switch (ran)
            {
                case 1:
                    potionCode = "145"; //might need to change the codes based on art
                  //  thoughtBubble.SetActive(true);
                    break;
                
                case 2:
                    potionCode = "256";
                    break;
                
                case 3:
                    potionCode = "346";
                    break;
                
                case 4:
                    potionCode = "156";
                    break;
                
                case 5:
                    potionCode = "345";
                    break;
                
                case 6:
                    potionCode = "246";
                    break;

            }

       Debug.Log("Customer potionCode" + potionCode);
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

            StartCoroutine(DisplayPotionCode(1f));
        }

    }

    private IEnumerator DisplayPotionCode(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        if (potionCode == "145")
        {
            instance_145 = Instantiate(order145);
            Debug.Log("Created Thought Bubble instance_145");
            Destroy(instance_145, timeLeft);
        }
        else if (potionCode == "256")
        {
            instance_256 = Instantiate(order256);
            Debug.Log("Created Thought Bubble instance_256");
            Destroy(instance_256, timeLeft);
        }
        else if (potionCode == "346")
        {
            instance_346 = Instantiate(order346);
            Debug.Log("Created Thought Bubble instance_346");
            Destroy(instance_346, timeLeft);
        }
        else if (potionCode == "156")
        {
            instance_156 = Instantiate(order156);
            Debug.Log("Created Thought Bubble instance_156");
            Destroy(instance_156, timeLeft);
        }
        else if (potionCode == "345")
        {
            instance_345 = Instantiate(order345);
            Debug.Log("Created Thought Bubble instance_345");
            Destroy(instance_345, timeLeft);

        }
        else if (potionCode == "246")
        {
            instance_246 = Instantiate(order246);
            Debug.Log("Created Thought Bubble instance_246");
            Destroy(instance_246, timeLeft);
        }
    }





}
