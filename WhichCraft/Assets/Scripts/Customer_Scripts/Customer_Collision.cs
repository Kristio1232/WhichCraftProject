using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Collision : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

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
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {


    }
}
