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
    public GameObject CookBookMenu;

    public GameObject bottleFrame;
    public GameObject ingredientFrame;
    //inventory  Objects
    public GameObject red;
    public GameObject yellow;
    public GameObject blue;
    public GameObject bottleSprite;

    public GameObject obstacleTemplate;
    public Transform spawnPoints;
    public GameObject potionMade;
    // item spawn pos
    public Transform[] itemSpawns;
    public int itemPos = 0;

    


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
        if (panelOn && Input.GetKey("space"))
        {
            panelOn = false;
            ingredientPanel.SetActive(panelOn);
            bottlePanel.SetActive(panelOn);
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
        // --------------------------------- Start of spawning system --------------------------
        if (potionDone && potionMade == null)
        {
            Vector2 position = new Vector2(spawnPoints.position.x, spawnPoints.position.y);
            potionMade = Instantiate(obstacleTemplate, position, Quaternion.identity);
            // instantiate 2 ings and 1 bott
            // use transform from an empty game obj to store pos of the ingredients and bottle
        }

        if (!r && potionMade == null)
        {

            red.SetActive(true); // 
        }
        else
        {
            red.SetActive(false); // 
        }
        if (!y && potionMade == null)
        {
            yellow.SetActive(true); //
        }
        else
        {
            yellow.SetActive(false); //
        }
        if (!f && potionMade == null)
        {
            bottleSprite.SetActive(true); // 
        }
        else
        {
            bottleSprite.SetActive(false); // 
        }
        // ----------------------------------- end of ingr and bott spawn --------------------------------------------------
        if (MiniGame.activeSelf || MiniGameLoseMenu.activeSelf || MiniGameWinMenu.activeSelf || CookBookMenu.activeSelf)
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

            if (Input.GetKey("e"))
            {
                panelOn = true;
                bottlePanel.SetActive(panelOn);
            }

            else if (Input.GetKey("e") && panelOn)
            {
                panelOn = false;
                bottlePanel.SetActive(panelOn);
            }

        }

        if (collision.tag == "ingredient")
        {
            if (Input.GetKey("e"))
            {
                panelOn = true;
                ingredientPanel.SetActive(panelOn);
            }
            /* if (Input.GetKey("e") && panelOn)
             {
                 panelOn = false;
                 ingredientPanel.SetActive(panelOn);
             }*/

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
        //testtube.SetActive(true);
        if (f == true)
        {
            SelectedItems = SelectedItems + 1;
            f = false;
        }
        Debug.Log("beaker code " + SelectedItems);
    }

    public static void RedIngredient()
    {
        if (r == true && numberOfIngredient < 2)
        {
            SelectedItems = SelectedItems + 3;
            r = false;
            numberOfIngredient++;
        }
        Debug.Log("Red code" + SelectedItems);
    }

    public static void YellowIngredient()
    {
        if (y == true && numberOfIngredient < 2)
        {
            SelectedItems = SelectedItems + 4;
            y = false;
            numberOfIngredient++;
        }
        Debug.Log("Yellow code" + SelectedItems);
    }

    public static void BlueIngridient()
    {
        if (b == true && numberOfIngredient < 2)
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

    public void emptyInvetoryOut()
    {
        emptyInvetory();
        if (potionMade != null)
        {
            Destroy(potionMade);
        }
    }
    //need to reset all varaibles to true 
    //need to set the match system 
    //need to set the appear system
}
