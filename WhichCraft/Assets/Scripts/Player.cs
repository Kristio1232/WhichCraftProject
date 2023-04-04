using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int movementSpeed = 5;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public Animator anim_mc;
    public SpriteRenderer sprite_mc;
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
    public GameObject bottlePref1;
    public GameObject bottlePref2;
    public GameObject bottlePref3;

    private GameObject red;
    private GameObject yellow;
    private GameObject blue;
    private GameObject empBottle1;
    private GameObject empBottle2;
    private GameObject empBottle3;

    public GameObject obstacleTemplate;
    public GameObject greenPotion1;
    public GameObject greenPotion2;
    public GameObject greenPotion3;

    public GameObject orangePotion1;
    public GameObject orangePotion2;
    public GameObject orangePotion3;

    public GameObject purplePotion1;
    public GameObject purplePotion2;
    public GameObject purplePotion3;


    public Transform spawnPoints;
    public GameObject potionMade;


    // item spawn pos
    public Transform[] itemSpawns;

    private bool panelOn = false;

    public static string pcode;
    private static string SelectedItems;
    //public static string SelectedItems;

    private static bool f = true;
    private static bool r = true;
    private static bool y = true;
    private static bool b = true;
    private static bool potionDone = false;
    private static int numberOfIngredient = 0;

    public static bool match = true;
    public static string Items = "";



    ///temps
    public GameObject potionSprites;
    public GameObject[] poitionPref;
    public GameObject b145;
    public GameObject b256;
    public GameObject b346;
    public GameObject b156;
    public GameObject b345;
    public GameObject b246;
    public GameObject b356;
    public GameObject b146;
    public GameObject b245;
    


    //

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

        if(moveX > 0f)
        {
            sprite_mc.flipX = false;
            anim_mc.SetBool("WalkingSide", true);
            anim_mc.SetBool("WalkingUp", false);
            anim_mc.SetBool("WalkingDown", false);
        }
        else if(moveX < 0f)
        {
            sprite_mc.flipX = true;
            anim_mc.SetBool("WalkingSide", true);
            anim_mc.SetBool("WalkingUp", false);
            anim_mc.SetBool("WalkingDown", false);
        }

        if(moveY > 0f)
        {
            //move up animation
            anim_mc.SetBool("WalkingSide", false);
            anim_mc.SetBool("WalkingUp", true);
            anim_mc.SetBool("WalkingDown", false);
        }
        else if(moveY < 0f)
        {
            //move down animation
            anim_mc.SetBool("WalkingSide", false);
            anim_mc.SetBool("WalkingDown", true);
            anim_mc.SetBool("WalkingUp", false);
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        // --------------------------------- Start of spawning system --------------------------
        if (potionDone && potionMade == null)
        {
            //if (SelectedItems ) add an if statement to check ingredients to display potion

            if (potionSprites.GetComponent<PotionSpriteChange>().onDisplay_145 == true)
            {
                Vector2 position = new Vector2(spawnPoints.position.x, spawnPoints.position.y);
                potionMade = Instantiate(poitionPref[0], position, Quaternion.identity);
                //b145.SetActive(true);
                Debug.Log("b145 should be active");
                potionSprites.GetComponent<PotionSpriteChange>().onDisplay_145 = false;
                
            }
             if (potionSprites.GetComponent<PotionSpriteChange>().onDisplay_256 == true)
            {
                Vector2 position = new Vector2(spawnPoints.position.x, spawnPoints.position.y);
                potionMade = Instantiate(poitionPref[1], position, Quaternion.identity);
                //b256.SetActive(true);
                Debug.Log("b145 should be active");
                potionSprites.GetComponent<PotionSpriteChange>().onDisplay_256 = false;
                
            }
             if (potionSprites.GetComponent<PotionSpriteChange>().onDisplay_346 == true)
            {
               Vector2 position = new Vector2(spawnPoints.position.x, spawnPoints.position.y);
                potionMade = Instantiate(poitionPref[2], position, Quaternion.identity);
                //b346.SetActive(true);
                Debug.Log("b145 should be active");
                potionSprites.GetComponent<PotionSpriteChange>().onDisplay_346 = false;
                
            }
             if (potionSprites.GetComponent<PotionSpriteChange>().onDisplay_156 == true)
            {
               Vector2 position = new Vector2(spawnPoints.position.x, spawnPoints.position.y);
                potionMade = Instantiate(poitionPref[3], position, Quaternion.identity);
                //b156.SetActive(true);
                Debug.Log("b145 should be active");
                potionSprites.GetComponent<PotionSpriteChange>().onDisplay_156 = false;
                
            }
             if (potionSprites.GetComponent<PotionSpriteChange>().onDisplay_345 == true)
            {
                Vector2 position = new Vector2(spawnPoints.position.x, spawnPoints.position.y);
                potionMade = Instantiate(poitionPref[4], position, Quaternion.identity);
                //b345.SetActive(true);
                Debug.Log("b145 should be active");
                potionSprites.GetComponent<PotionSpriteChange>().onDisplay_345 = false;
                
            }
             if (potionSprites.GetComponent<PotionSpriteChange>().onDisplay_246 == true)
            {
                Vector2 position = new Vector2(spawnPoints.position.x, spawnPoints.position.y);
                potionMade = Instantiate(poitionPref[5], position, Quaternion.identity);
                //b246.SetActive(true);
                Debug.Log("b145 should be active");
                potionSprites.GetComponent<PotionSpriteChange>().onDisplay_246 = false;
                
            }
             if (potionSprites.GetComponent<PotionSpriteChange>().onDisplay_356 == true)
            {
                Vector2 position = new Vector2(spawnPoints.position.x, spawnPoints.position.y);
                potionMade = Instantiate(poitionPref[6], position, Quaternion.identity);
                //b356.SetActive(true);
                Debug.Log("b145 should be active");
                potionSprites.GetComponent<PotionSpriteChange>().onDisplay_356 = false;
                
            }
             if (potionSprites.GetComponent<PotionSpriteChange>().onDisplay_146 == true)
            {
               Vector2 position = new Vector2(spawnPoints.position.x, spawnPoints.position.y);
                potionMade = Instantiate(poitionPref[7], position, Quaternion.identity);
                //b146.SetActive(true);
                Debug.Log("b145 should be active");
                potionSprites.GetComponent<PotionSpriteChange>().onDisplay_146 = false;
                
            }
             if (potionSprites.GetComponent<PotionSpriteChange>().onDisplay_245 == true)
            {
                Vector2 position = new Vector2(spawnPoints.position.x, spawnPoints.position.y);
                potionMade = Instantiate(poitionPref[8], position, Quaternion.identity);
                //b245.SetActive(true);
                Debug.Log("b145 should be active");
                potionSprites.GetComponent<PotionSpriteChange>().onDisplay_245 = false;
                
            }
            
            
           
            
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
            empBottle1 = Instantiate(bottlePref1, position, Quaternion.identity);
            isBeaker = true; // sets to true
            numberOfIngredient++;
        }
        
        
        Debug.Log("beaker one code " + SelectedItems);
    }

    public void getBeakerTwo()
    {  
        
        if (f && numberOfIngredient < 3)
        {
            SelectedItems = SelectedItems + 2;
            f = false;
            Vector2 position = new Vector2(itemSpawns[numberOfIngredient].position.x, itemSpawns[numberOfIngredient].position.y);
            empBottle2 = Instantiate(bottlePref2, position, Quaternion.identity);
            isBeaker = true; // sets to true
            numberOfIngredient++;
        }
        Debug.Log("beaker two code " + SelectedItems);
    }


        public void getBeakerThree()
    {  
       
        if (f && numberOfIngredient < 3)
        {
            SelectedItems = SelectedItems + 3;
            f = false;
            Vector2 position = new Vector2(itemSpawns[numberOfIngredient].position.x, itemSpawns[numberOfIngredient].position.y);
            empBottle3 = Instantiate(bottlePref3, position, Quaternion.identity);
            isBeaker = true; // sets to true
            numberOfIngredient++;
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

    public void emptyInvetory()     
    {
        f = true;
        r = true;
        y = true;
        b = true;
        SelectedItems = "";
        numberOfIngredient = 0;
        potionDone = false;
        Destroy(blue);
        Destroy(red);
        Destroy(yellow);
        Destroy(empBottle1);
        Destroy(empBottle2);
        Destroy(empBottle3);

        /*b145.SetActive(false);
        b256.SetActive(false);
        b346.SetActive(false);
        b156.SetActive(false);
        b345.SetActive(false);
        b246.SetActive(false);
        b356.SetActive(false);
        b146.SetActive(false);
        b245.SetActive(false);*/

}

    public void emptyInvetoryOut()
    {
        emptyInvetory();
        if (potionMade != null){
        
            Destroy(potionMade);
            
        }
    }

    public void emptyTable()
    {
        Destroy(blue);
        Destroy(red);
        Destroy(yellow);
        Destroy(empBottle1);
        Destroy(empBottle2);
        Destroy(empBottle3);
    }



}

