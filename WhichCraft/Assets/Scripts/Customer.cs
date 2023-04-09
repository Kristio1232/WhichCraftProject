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
    public float timeLeft = 60f;

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

    public GameObject order356; //missing
    public GameObject order146; //missing
    public GameObject order245; //missing
    public GameObject smile;
    public GameObject sad;
    public GameObject bubble;
    //instances of thought bubble order "_ _ _"
    /*
    private GameObject instance_145;
    private GameObject instance_256;
    private GameObject instance_346;
    private GameObject instance_156;
    private GameObject instance_345;
    private GameObject instance_246;

    private GameObject instance_356; //missing
    private GameObject instance_146; //missing
    private GameObject instance_245; //missing
*/
    public bool display;


    //Potion Code pattern 
    // 2 beakers = code numbers 1, 2, 3
    // 3 ingredients = code numbers 4, 5, 6 


    // Random money and potionCode
    void Start()
    {
        anim.SetBool("WalkOut", true);
        money = Random.Range(15, 101);
        if (Random.Range(1, 10000) == 1){
            money  = Random.Range(1000, 10000);
        }
        
        int ran = Random.Range(1, 10);
        switch (ran)
            {
                case 1:
                    potionCode = "145"; 
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
                
                case 7:
                    potionCode = "356";
                    break;
                
                case 8:
                    potionCode = "146";
                    break;
                
                case 9:
                    potionCode = "245";
                    break;

            }

       Debug.Log("Customer potionCode" + potionCode);
    }

    
    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if (this.timeLeft > 0)
            {
                this.timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);

                anim.SetBool("Idle", false);
                anim.SetBool("WalkOut", true);
                
                MoveToWayPoint(waypoint);

            }
            else
            {
                MoveToWayPoint(waypoint);
                //anim.SetBool("Idle", false);
                //anim.SetBool("WalkOut", true);
                sprite.flipX = false;
            }
            if (bubble){
                //Debug.Log(transform.position.x);
                Vector2 position = new Vector2(transform.position.x +1, transform.position.y +1);
                bubble.transform.position = position;
            }
        }
    }

    public float customerTimer()
    {
        return this.timeLeft;
    }

    public void setTimerToZero()
    {
        this.timeLeft = -1;
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
        /*
        if (other.CompareTag("CustomerGoesIn"))
        {
            Debug.Log("Customer Comes In!");
            anim.SetBool("WalkIn", true);
            sprite.flipX = true;
        }
    */
        if (other.CompareTag("CustomerStops"))
        {
            Debug.Log("Customer Stops Here");
            anim.SetBool("Idle", true);
            anim.SetBool("WalkIn", false);
            sprite.flipX = true;
            if (!bubble){
                BubbleSet();
            }
        }

    }
    public void BubbleSet(GameObject newBubble){
        Debug.Log("Runs " +newBubble);
        bubble = Instantiate(newBubble);
        Vector2 position = new Vector2(transform.position.x +1, transform.position.y +1);
        bubble.transform.position = position;
        Debug.Log("New bubble " + bubble);
    }
    private void BubbleSet(){
        if (potionCode == "145")
        {
            bubble = Instantiate(order145);
            //Destroy(bubble, this.timeLeft);
        }
        else if (potionCode == "256")
        {
            bubble = Instantiate(order256);
            //Destroy(instance_256, this.timeLeft);
        }
        else if (potionCode == "346")
        {
            bubble = Instantiate(order346);
            
            //Destroy(instance_346, this.timeLeft);
        }
        else if (potionCode == "156" )
        {
            bubble = Instantiate(order156);
            
            //Destroy(instance_156, this.timeLeft);
        }
        else if (potionCode == "345" )
        {
            bubble = Instantiate(order345);
          
            //Destroy(instance_345, this.timeLeft);

        }
        else if (potionCode == "246" )
        {
            bubble = Instantiate(order246);
          
            //Destroy(instance_246, timeLeft);
        }

        //**NEW ADDITION**
        else if (potionCode == "356" )
        {
            bubble = Instantiate(order356);
          
            //Destroy(instance_356, timeLeft);
        }
        else if (potionCode == "146" )
        {
            bubble = Instantiate(order146);
           
            //Destroy(instance_146, timeLeft);
        }
        else if (potionCode == "245" )
        {
            bubble = Instantiate(order245);
            
            //Destroy(instance_245, timeLeft);
        }
    }
    /*
    private IEnumerator DisplayPotionCode(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        if (potionCode == "145" && display == false)
        {
            bubble = Instantiate(order145);
            Debug.Log("Created Thought Bubble instance_145");
            display = true;
            Destroy(bubble, this.timeLeft);
        }
        else if (potionCode == "256" && display == false)
        {
            bubble = Instantiate(order256);
            Debug.Log("Created Thought Bubble instance_256");
            display = true;
            Destroy(instance_256, this.timeLeft);
        }
        else if (potionCode == "346" && display == false)
        {
            instance_346 = Instantiate(order346);
            Debug.Log("Created Thought Bubble instance_346");
            display = true;
            Destroy(instance_346, this.timeLeft);
        }
        else if (potionCode == "156" && display == false)
        {
            instance_156 = Instantiate(order156);
            Debug.Log("Created Thought Bubble instance_156");
            display = true;
            Destroy(instance_156, this.timeLeft);
        }
        else if (potionCode == "345" && display == false)
        {
            instance_345 = Instantiate(order345);
            Debug.Log("Created Thought Bubble instance_345");
            display = true;
            Destroy(instance_345, this.timeLeft);

        }
        else if (potionCode == "246" && display == false)
        {
            instance_246 = Instantiate(order246);
            Debug.Log("Created Thought Bubble instance_246");
            display = true;
            Destroy(instance_246, timeLeft);
        }

        //**NEW ADDITION**
        else if (potionCode == "356" && display == false)
        {
            instance_356 = Instantiate(order356);
            Debug.Log("Created Thought Bubble instance_356");
            display = true;
            Destroy(instance_356, timeLeft);
        }
        else if (potionCode == "146" && display == false)
        {
            instance_146 = Instantiate(order146);
            Debug.Log("Created Thought Bubble instance_146");
            display = true;
            Destroy(instance_146, timeLeft);
        }
        else if (potionCode == "245" && display == false)
        {
            instance_245 = Instantiate(order245);
            Debug.Log("Created Thought Bubble instance_245");
            display = true;
            Destroy(instance_245, timeLeft);
        }
    }
*/
    public void DestroyAllPre()
    {
        Debug.Log("Destroying method running");
        if (bubble){
            Destroy(bubble);
        }
        /*
        if(potionCode == "145")
        {
            Destroy(instance_145);
            display = false;
        }
          if(potionCode == "256")
        {
            Destroy(instance_256);
            display = false;
        }
          if(potionCode == "346")
        {
            Destroy(instance_346);
            display = false;
        }
          if(potionCode == "156")
        {
            Destroy(instance_156);
            display = false;
        }
          if(potionCode == "345")
        {
            Destroy(instance_345);
            display = false;
        }
          if(potionCode == "246")
        {
            Destroy(instance_246);
            display = false;
        }
          //**NEW ADDITION
          if(potionCode == "356")
        {
            Destroy(instance_356);
            display = false;
        }
        if (potionCode == "146")
        {
            Destroy(instance_146);
            display = false;
        }
        if (potionCode == "245")
        {
            Destroy(instance_245);
            display = false;
        }*/
        //**
    }

}
