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
    public GameObject ingredientPanel;
    public GameObject ingredient1;
    public GameObject ingredient2;
    public GameObject ingredient3;

    public GameObject bottleFrame;
    public GameObject ingredientFrame;

    private bool panelOn = false;

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
            bottleFrame.SetActive(true);
            Debug.Log("Bottle"); 
        }

        if (collision.tag == "ingredient")
        {

            ingredientFrame.SetActive(true);
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
            if (Input.GetKey("e"))
            {
                panelOn = true;
                ingredientPanel.SetActive(panelOn);
            }
           
            Debug.Log("ingredientStay");
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "bottle")
        {
            bottleFrame.SetActive(false);
            Debug.Log("BottleLeave");
        }
        if (collision.tag == "ingredient")
        {
            panelOn = false;
            ingredientPanel.SetActive(panelOn);
            ingredientFrame.SetActive(false);
            Debug.Log("ingredientLeave");
        }


    }
}
