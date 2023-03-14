using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer_Collision : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject player;
    public GameObject customer;
    public GameObject customerStopsHere;
    public GameObject customerLeavesHere;
    public GameObject customerEnteringHere;
    public GameObject thoughtBubble_HeatPotion;
    public GameObject thoughtBubble_Smile;
    public GameObject ThoughtBubble_Angry;
    public GameObject EventSystem;
    public SpriteRenderer sprite;
    

    [SerializeField]
    private Transform[] exitWayPoints;

    [SerializeField]
    private Transform[] goToCounterWayPoint;

    [SerializeField]
    private float moveSpeed = 2f;
    private int waypointIndex = 0;
    private int waypointIndex2 = 0;

    public bool timerOn;
    public float timeLeft = 40f;

    public GameObject MiniGame1;

    public static double sat; 
    

    //Potion Code pattern 
    // 2 beakers = code numbers 1, 2
    // 3 ingredients = code numbers 3, 4, 5 

    public static int beakerCode;
    public static int ingrideient1Code;
    public static int ingrideient2Code;
    public static int potionCode;
    public static string code;

    // public bool bubble;

      

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), customer.GetComponent<Collider2D>(), true);
        EventSystem = GameObject.Find("EventSystem");
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
                MoveToShopCounter();


                //Timer Added to the customer time when the Mini-Game screen is active (Note: It does not exactly give 10 seconds)
                if (MiniGame1.activeSelf)
                {
                    Debug.Log("Timer added over time when Mini-game is being played.");
                    timeLeft += 0.0018f; 
                }

            }
            else
            {
                customerStopsHere.SetActive(false);
                customerLeavesHere.SetActive(true);
                MoveToExit();
            }
        }
        
     //   if ( Input.GetKeyDown("space") )
     //      {
        
     //       if (bubble == true) 
    //         { 
           
    //            thoughtBubble_HeatPotion.SetActive(true);
    //            Player.pcode = code; 
    //            Debug.Log("PLAYER CODE" + Player.pcode);
                
    //       }
    //    }
    //    else if (bubble == false)
    //    {
    //        thoughtBubble_HeatPotion.SetActive(false);
            
     //   }
      

    }

    private void MoveToShopCounter()
    {
        if (waypointIndex <= goToCounterWayPoint.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
               goToCounterWayPoint[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);
        }
    }

    private void MoveToExit()
    {
        if (waypointIndex2 <= exitWayPoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
               exitWayPoints[waypointIndex2].transform.position,
               moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Exit"))
        {
            Debug.Log("Customer Gone!");

            Vector2 position = new Vector2(transform.position.x, transform.position.y);

            if(timeLeft <= 0)
            {
                timeLeft = 30f;
                Debug.Log("Creates Customer");
                Instantiate(customer, position, Quaternion.identity);

            }
          
            Destroy(customer, 5f);

            customerStopsHere.SetActive(true);
            customerLeavesHere.SetActive(false);
            
        }

        if (other.CompareTag("CustomerGoesIn"))
        {
            Debug.Log("Customer Comes In!");
            anim.SetBool("WalkIn", true);
            sprite.flipX = true;
            EventSystem.GetComponent<Game_Info>().addCustomer();
            //bubble = false;
        }

        if (other.CompareTag("CustomerStops"))
        {
            beakerCode = Random.Range(1, 1);
            ingrideient1Code = Random.Range(3, 3);
            ingrideient2Code = Random.Range(4, 4);
            code = beakerCode.ToString() + ingrideient1Code.ToString() + ingrideient2Code.ToString();
            potionCode = int.Parse(code);
          
            Player.pcode = code;
            
            Debug.Log("Customer Stops Here");
            Debug.Log("CODE IN INT "  + potionCode);

            // bubble = true; //thought bubble will only pop up when the customer is waiting

            anim.SetBool("Idle", true);
            anim.SetBool("WalkIn", false);
            StartCoroutine(WaitToDisplay(1f));

            if (sat == 1) //just need to confirm the stat system adjust the stat number acordingly
              {
              //  thoughtBubble_HeatPotion.SetActive(false);
              //  ThoughtBubble_Smile.SetActive(true);
               }
            else 
            {
            //   thoughtBubble_HeatPotion.SetActive(false);
             //   ThoughtBubble_Angry.SetActive(true);
           }

        }

        if (other.CompareTag("CustomerGoesOut"))
        {
            Debug.Log("Customer is Leaving");
            anim.SetBool("Idle", false);
            anim.SetBool("WalkOut", true);
            sprite.flipX = false;
           // bubble = false;
            thoughtBubble_HeatPotion.SetActive(false);
         //   thoughtBubble_Smile.SetActive(true);
        }

    }

    public void updateTimer(float currentTime)
    {
        currentTime += 1;
        float seconds = Mathf.FloorToInt(currentTime % 60);
    }


    IEnumerator WaitToDisplay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        thoughtBubble_HeatPotion.SetActive(true);

    }
}
