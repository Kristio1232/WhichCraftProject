using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anim;
    public float moveSpeed;
    public bool canMove;
    public static bool interact = false;
    public static bool allowInteract = false;
    public Transform target;

    private CharacterController controller;
    private Vector3 moveDirection;
    private int current;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        canMove = false;
    }

    public void walk()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {

        }
    }
}
