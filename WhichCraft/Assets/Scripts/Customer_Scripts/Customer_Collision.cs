using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Collision : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject player;
    public GameObject customer;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), customer.GetComponent<Collider2D>(), true);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }
        else
        {
            anim.SetBool("Idle", false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {


    }
}
