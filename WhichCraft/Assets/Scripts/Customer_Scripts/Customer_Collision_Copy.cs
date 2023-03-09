using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Collision_Copy : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject player;
    public GameObject customer;
    public GameObject customerStopsHere;
    public SpriteRenderer sprite;
    public bool customerLeaving;

    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 2f;
    private int waypointIndex = 0;

    public bool timerOn;
    public float timeLeft = 40f;

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
            }
            else
            {
                timeLeft = 0;
                customerStopsHere.SetActive(false);
                MoveToExit();
            }
        }

    }

    private void MoveToExit()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
               waypoints[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Exit"))
        {
            Debug.Log("Customer Gone!");
            Destroy(gameObject);
            customerStopsHere.SetActive(true);
            timeLeft = 30f;
        }

        if (other.CompareTag("CustomerStops"))
        {
            Debug.Log("Customer Stops Here");
            anim.SetBool("Idle", true);
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Customer is Leaving");
        anim.SetBool("Idle", false);
        anim.SetBool("WalkOut", true);
        sprite.flipX = false;
    }

    public void updateTimer(float currentTime)
    {
        currentTime += 1;
        float seconds = Mathf.FloorToInt(currentTime % 60);
    }
}
