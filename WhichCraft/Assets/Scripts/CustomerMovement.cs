using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed;
    Animator anim;
    private Vector3 directionVector;
    private Transform myTransform;
    private Rigidbody2D myRigidbody;
    public Collider2D bounds;
   

    void Start()
    {
        anim = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        goLeftDirection();
    }

    // Update is called once per frame
    void Update()
    {

     //   if (!playerInRange)
      //  {
            Move();
      //  }
        
    }

    private void Move()
    {

        Vector3 temp = myTransform.position + directionVector * moveSpeed * Time.deltaTime;
        if (bounds.bounds.Contains(temp)) { 
        myRigidbody.MovePosition(temp);
         }
        else
        {
            //Stay Idle
            goLeftDirection();
        }
    }

    void goLeftDirection()
    {
        directionVector = Vector3.left;
        UpdateAnimation();
    }
    void goRightDirection()
    {
        directionVector = Vector3.right;
        UpdateAnimation();
    }

    void goDownDirection()
    {
        directionVector = Vector3.down;
        UpdateAnimation();
    }

    void goUpDirection()
    {
        directionVector = Vector3.up;
        UpdateAnimation();
    }
    
    void UpdateAnimation()
    {
        anim.SetFloat("MoveX", directionVector.x);
        anim.SetFloat("MoveY", directionVector.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 temp = directionVector;
        //Stay Idle Code
        goLeftDirection();
        int i = 0;
        while(temp == directionVector && i == 100)
        {
            i++;
            //Stay Idle Code
            goLeftDirection();
        }
    }
}
