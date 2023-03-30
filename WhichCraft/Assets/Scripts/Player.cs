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
    public GameObject redPref;
    public GameObject yellowPref;
    public GameObject bluePref;
    public GameObject bottlePref;

    private GameObject red;
    private GameObject yellow;
    private GameObject blue;
    private GameObject empBottle;

    public GameObject obstacleTemplate;
    public Transform spawnPoints;
    public GameObject potionMade;
    // item spawn pos
    public Transform[] itemSpawns;
    

    


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
        /*
        if (!r && potionMade == null && !red)
        {

            
            Vector2 position = new Vector2(itemSpawns[numberOfIngredient].position.x, itemSpawns[numberOfIngredient].position.y);
            red = Instantiate(redPref, position, Quaternion.identity);
        }*/
       
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

    //Potion Code pattern 
    // 2 beakers = code numbers 1, 2, 3
    // 3 ingredients = code numbers 4, 5, 6 

    bool isBeaker = false; // false is default variable

    public void getBeakerOne()
    {
        
        if (f && numberOfIngredient < 3)
           {
            SelectedItems = SelectedItems + 1;
            f = false;
            Vector2 position = new Vector2(itemSpawns[numberOfIngredient].position.x, itemSpawns[numberOfIngredient].position.y);
            empBottle = Instantiate(bottlePref, position, Quaternion.identity);
            isBeaker = true; // sets to true
            numberOfIngredient++;
        }
        
        
        Debug.Log("beaker one code " + SelectedItems);
    }

    public static void getBeakerTwo()
    {  
        
        if (f == true)
        {
            SelectedItems = SelectedItems + 2;
            f = false;
        }
        Debug.Log("beaker two code " + SelectedItems);
    }


        public static void getBeakerThree()
    {  
       
        if (f == true)
        {
            SelectedItems = SelectedItems + 3;
            f = false;
        }
        Debug.Log("beaker three code " + SelectedItems);
    }

    public void RedIngredient()
    {
        if (r && numberOfIngredient < 3 && ( numberOfIngredient < 2 || isBeaker ))
        {
            SelectedItems = SelectedItems + 4;
            r = false;
            Vector2 position = new Vector2(itemSpawns[numberOfIngredient].position.x, itemSpawns[numberOfIngredient].position.y);
            red = Instantiate(redPref, position, Quaternion.identity);
            numberOfIngredient++;
        }
        Debug.Log("Red code" + SelectedItems);
    }

    public void YellowIngredient()
    {
        if (y && numberOfIngredient < 3 && (numberOfIngredient < 2 || isBeaker))
        {
            SelectedItems = SelectedItems + 5;
            y = false;
            Vector2 position = new Vector2(itemSpawns[numberOfIngredient].position.x, itemSpawns[numberOfIngredient].position.y);
            yellow = Instantiate(yellowPref, position, Quaternion.identity);
            numberOfIngredient++;
        }
        Debug.Log("Yellow code" + SelectedItems);
    }

    public void BlueIngridient()   
    {
        if (b && numberOfIngredient < 3 && (numberOfIngredient < 2 || isBeaker))
        {
            SelectedItems = SelectedItems + 6;
            b = false;
            Vector2 position = new Vector2(itemSpawns[numberOfIngredient].position.x, itemSpawns[numberOfIngredient].position.y);
            blue = Instantiate(bluePref, position, Quaternion.identity);
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
        if (potionMade != null){
        
            Destroy(potionMade);
        }
    }

}

