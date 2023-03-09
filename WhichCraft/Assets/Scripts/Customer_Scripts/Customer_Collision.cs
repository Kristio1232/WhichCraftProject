using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Collision : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject player;
    public GameObject customer;
    public SpriteRenderer sprite;
    public bool customerOnCounter;

    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 2f;
    private int waypointIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        customerOnCounter = false;
        sprite = GetComponent<SpriteRenderer>();
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), customer.GetComponent<Collider2D>(), true);
    }

    // Update is called once per frame
    void Update()
    {
        if (customerOnCounter)
        {
            MoveToExit();
        }
    }

    private void MoveToExit()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {

            // Move Customer from current waypoint to the next one
            // using MoveTowards method
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
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("CustomerStops"))
        {
            Debug.Log("Customer Stops Here");
            anim.SetBool("Idle", true);
            customerOnCounter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
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
