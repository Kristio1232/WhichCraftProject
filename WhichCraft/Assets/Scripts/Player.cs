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

    public GameObject bottlePanel;
    public GameObject bottle;

    public GameObject MiniGame;
    public GameObject MiniGameWinMenu;
    public GameObject MiniGameLoseMenu;

    public GameObject bottleFrame;
    public GameObject ingredientFrame;
    //inventory  Objects
    public GameObject red;
    public GameObject yellow;
    public GameObject blue;
    public GameObject bottleSprite;

    private bool panelOn = false;

    public static string pcode;
    private static string SelectedItems;

    private static bool f = true;
    private static bool r = true;
    private static bool y = true;
    private static bool b = true;
    private static bool potionDone = false;
    private static int numberOfIngredient = 0;

    public static bool match = true;
    public static string Items = "";

    // Start is called before the first frame update
    void Start()
    {
        emptyInvetory();
    }
    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
        if (!r)
        {
            red.SetActive(true);
        }
        else
        {
            red.SetActive(false);
        }
        if (!y)
        {
            yellow.SetActive(true);
        }
        else
        {
            yellow.SetActive(false);
        }
        if (!f)
        {
            bottleSprite.SetActive(true);
        }
        else
        {
            bottleSprite.SetActive(false);
        }

        if(MiniGame.activeSelf || MiniGameLoseMenu.activeSelf || MiniGameWinMenu.activeSelf)
        {
            movementSpeed = 0;
        }
        else
        {
            movementSpeed = 5;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
    }

    public int getNumberOfIngredient()
    {
        return numberOfIngredient;
    }
    public bool getPotionDone()
    {
        return potionDone;
    }

    public string getSelectedItems()
    {
        return SelectedItems;
    }
    public void setPotionDone(bool value)
    {
        potionDone = value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bottle")
        {
            bottleFrame.SetActive(true);
            //Debug.Log("Bottle"); 
        }

        if (collision.tag == "ingredient")
        {
            ingredientFrame.SetActive(true);
            //Debug.Log("ingredient");
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "bottle")
        {
            if (collision.tag == "bottle")
            {
                if (Input.GetKey("e"))
                {
                    panelOn = true;
                    bottlePanel.SetActive(panelOn);
                }
                //Debug.Log("BottleStay");
            }
        }

        if (collision.tag == "ingredient")
        {
            if (Input.GetKey("e"))
            {
                panelOn = true;
                ingredientPanel.SetActive(panelOn);
            }

            //Debug.Log("ingredientStay");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "bottle")
        {
            panelOn = false;
            bottlePanel.SetActive(panelOn);
            bottleFrame.SetActive(false);
            //Debug.Log("BottleLeave");
        }
        if (collision.tag == "ingredient")
        {
            panelOn = false;
            ingredientPanel.SetActive(panelOn);
            ingredientFrame.SetActive(false);
            //Debug.Log("ingredientLeave");
        }
    }

    public static void getBeaker()
    {
        if (f == true)
        {
            SelectedItems = SelectedItems + 1;
            f = false;
        }
        Debug.Log("beaker code " + SelectedItems);
    }

    public static void RedIngredient()
    {
        if (r == true && numberOfIngredient < 2 && !f)
        {
            SelectedItems = SelectedItems + 3;
            r = false;
            numberOfIngredient++;
        }
        Debug.Log("Red code" + SelectedItems);
    }

    public static void YellowIngredient()
    {
        if (y == true && numberOfIngredient < 2 && !f)
        {
            SelectedItems = SelectedItems + 4;
            y = false;
            numberOfIngredient++;
        }
        Debug.Log("Yellow code" + SelectedItems);
    }

    public static void BlueIngridient()
    {
        if (b == true && numberOfIngredient < 2 && !f)
        {
            SelectedItems = SelectedItems + 5;
            b = false;
            numberOfIngredient++;
        }
        Debug.Log("Blue code" + SelectedItems);
    }

    public static void emptyInvetory()
    {
        f = true;
        r = true;
        y = true;
        b = true;
        SelectedItems = "";
        numberOfIngredient = 0;
        potionDone = false;
    }
    //need to reset all varaibles to true 
    //need to set the match system 
    //need to set the appear system
    public static void CheckMatch(string customerOrder)
    {
        emptyInvetory();

        Debug.Log("running check match");

        for (int i = 0; i < SelectedItems.Length; i++)
        {
            char c = SelectedItems[i];
            match = pcode.Contains(c);

            if (match == true)
            {
                Debug.Log("It is a match");
            }
            else
            {
                Debug.Log("Not a match");
            }

            //        for(int k = 0; k < pcode.Length; k++)
            //          {
            //            char m = pcode[k];
            //            if (c.equals(m))
            //            {
            //               match = true;
            //               Debug.Log("It is a match");
            //           }
            //           else
            ///          {
            //             match = false;
            //             Debug.Log("Not a match");
            //         }
            //    }
            //}
        }
    }
}