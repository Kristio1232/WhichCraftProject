using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Collision : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject player;
    public GameObject customer;
    public GameObject customerStopsHere;
    public GameObject customerLeavesHere;
    public GameObject customerEnteringHere;
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

/////////////My work///////////////////
    public static int beakerCode;
    public static int ingrideientCode;
    public static int potionCode;
    public static string code;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), customer.GetComponent<Collider2D>(), true);
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
            }
            else
            {
                customerStopsHere.SetActive(false);
                customerLeavesHere.SetActive(true);
                MoveToExit();
            }
        }

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
                Instantiate(customer, position, Quaternion.identity);


            }
          
            Destroy(customer, 10f);

            customerStopsHere.SetActive(true);
            customerLeavesHere.SetActive(false);
            
        }

        if (other.CompareTag("CustomerGoesIn"))
        {
            Debug.Log("Customer Comes In!");
            anim.SetBool("WalkIn", true);
            sprite.flipX = true;
        }

        if (other.CompareTag("CustomerStops"))
        {
            beakerCode = Random.Range(1, 3);
            ingrideientCode = Random.Range(3, 6);
            code = beakerCode.ToString() + ingrideientCode.ToString();
            potionCode = int.Parse(code);
          
            Debug.Log("Customer Stops Here");
            Debug.Log("BEAKER CODE "  + beakerCode);
            Debug.Log("iNGRIDIENT CODE "  + ingrideientCode);
            Debug.Log("CODE IN INT "  + potionCode);

           
            anim.SetBool("Idle", true);
            anim.SetBool("WalkIn", false);
        }

        if (other.CompareTag("CustomerGoesOut"))
        {
            Debug.Log("Customer is Leaving");
            anim.SetBool("Idle", false);
            anim.SetBool("WalkOut", true);
            sprite.flipX = false;
        }

    }

/*    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Customer is Leaving");
        anim.SetBool("Idle", false);
        anim.SetBool("WalkOut", true);
        sprite.flipX = false;
    }*/

    public void updateTimer(float currentTime)
    {
        currentTime += 1;
        float seconds = Mathf.FloorToInt(currentTime % 60);
    }
}
