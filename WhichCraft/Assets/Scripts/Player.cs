using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int movementSpeed = 5;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public GameObject bottleSelect;
    public GameObject ingredientSelect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

        
       
    }
    
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "bottle") 
        { 
            Debug.Log("Bottle"); 
        }

        if (collision.tag == "ingredient")
        {
            Debug.Log("ingredient");
        }


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "bottle")
        {
            Debug.Log("BottleStay");
        }
        if (collision.tag == "ingredient")
        {
            Debug.Log("ingredientStay");
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "bottle")
        {
            Debug.Log("BottleLeave");
        }
        if (collision.tag == "ingredient")
        {
            Debug.Log("ingredientLeave");
        }


    }
}
