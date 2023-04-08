using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour
{
    // Objectives
    public GameObject smile;
    public GameObject sad;
    public Transform bubbleSpawn;
    public int potionsMade = 0; // needs to be 2
    public int happyCustomers = 0; // needs to be 2

    public static int custServed;
    public static int satis;
    ///public int numberCustomers = 0;
    public TMP_Text potionsCounter;
    public TMP_Text satisfiedCusts;
    public TMP_Text moneyEarned;

    public Button endDayButton;
    public static bool goalsPass;
    public static bool potionPass;
    public static bool moneyPass;
    public static bool happyPass;

    //Customer Array Info
    private static List<GameObject> customers;
    private int size = 0;
    public int maxSize;
    //public GameObject[] customerPrefab;
    public Transform[] waitPoints;
    public int satisfaction;

    //Player Info
    public GameObject player;

    //Points
    public int points;
    //public int storeSatisfaction;
    public TMP_Text scoreDispaly;
    public TMP_Text satisfactionDispaly;

    //Spawn Variables
    private float timeBtwSpawns;
    public float spawnRate;
    public GameObject[] obstacleTemplate;
    public Transform spawnPoint;

    //MiniGame Variables
    private bool miniGameActive;
    //Unused
    /*
    public GameObject ThoughtBubble_Smile;
    public GameObject ThoughtBubble_Angry;
    public GameObject thoughtBubble_HeatPotion;
    */

    void Start()
    {
        miniGameActive = false;
        potionsMade = 0;
        timeBtwSpawns = 0;
        points = 0;
        customers = new List<GameObject>();
    }

    void Update()
    {
        //Debug.Log(miniGameActive);

        if (!miniGameActive)
        {
            if (timeBtwSpawns <= 0)
            {
                if (size < maxSize)
                {
                    int randomObstacle = Random.Range(0, obstacleTemplate.Length);
                    Vector2 position = new Vector2(spawnPoint.position.x, spawnPoint.position.y);
                    addCustomer(Instantiate(obstacleTemplate[randomObstacle], position, Quaternion.identity)); ;
                    timeBtwSpawns = spawnRate;
                }
                else
                {
                    timeBtwSpawns = 5;
                }
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }

            //Debug.Log(size);
            if (size >= 1)
            {
                customerUpdateFunction();
            }
        }
        else
        {
            foreach (var shopper in customers)
            {
                shopper.GetComponent<Customer>().timerOn = false;
            }
        }

        if (potionsMade >= 2 && points >= 100 && happyCustomers >= 2 && endDayButton.interactable == false)
        {
            goalsPass = true;
            endDayButton.interactable = true;
        }
            
    }

    private void customerUpdateFunction()
    {
        //Customer Control code
        int counter = 0;

        foreach (var shopper in customers)
        {
            counter++;

            Transform waitPoint = null;
            shopper.GetComponent<Customer>().timerOn = true;
            if (shopper.GetComponent<Customer>().timeLeft <= 0)
            {
                waitPoint = waitPoints[0];
                shopper.GetComponent<Customer>().setPosition(waitPoint);
                shopper.GetComponent<Customer>().DestroyAllPre();
                shopper.GetComponent<Customer>().BubbleSet(sad);
                float number = (float)0.45;
                shopper.transform.localScale = new Vector3(-number, number, number);
                GameObject temp = shopper;
                customers.Remove(shopper);
                if (!temp)
                {
                    Destroy(temp.GetComponent<Customer>().bubble, 15f);
                    Destroy(temp, 15f);
                }

                size--;
                break;
            }
            else
            {
                switch (counter)
                {
                    case 1:
                        waitPoint = waitPoints[1]; //**In front of the counter**
                        break;
                    case 2:
                        waitPoint = waitPoints[2];
                        break;
                    case 3:
                        waitPoint = waitPoints[3];
                        break;
                    case 4:
                        waitPoint = waitPoints[4];
                        break;
                }
                shopper.GetComponent<Customer>().setPosition(waitPoint);
            }
        }
    }

    //public static bool match = false;
    public void addCustomer(GameObject customer)
    {
        customers.Add(customer);
        size++;
        Debug.Log("Adds Customer");
    }

    public void giveCustomerPotion()
    {
        Debug.Log("Size " + size + " Potion Done " + player.GetComponent<Player>().getPotionDone());
        if (size > 0 && player.GetComponent<Player>().getPotionDone())
        {
            potionsMade++; // adds 1 to the potions made
            custServed = potionsMade;
            if (potionsMade <= 2)
                potionsCounter.text = potionsMade.ToString() + "/2";
            
            if(potionsMade >= 2)
            {
                potionPass = true;
            }

            satisfaction = 100;

            string playerCode = player.GetComponent<Player>().getSelectedItems();
            string customerCode = customers[0].GetComponent<Customer>().potionCode;
            Debug.Log("Codes: " + playerCode + " and " + customerCode);
            if (!playerCode[0].Equals(customerCode[0]))
            {
                satisfaction -= 10;
            }
            if (!playerCode.Contains(customerCode[1]))
            {
                satisfaction -= 20;
            }
            if (!playerCode.Contains(customerCode[2]))
            {
                satisfaction -= 20;
            }
            Debug.Log("Satisfaction" + satisfaction);
            if (satisfaction >= 80)
                happyCustomers++; // adds 1 to the happy customers
            if (happyCustomers <= 2)
                {satisfiedCusts.text = happyCustomers.ToString() + "/2";}
            if (happyCustomers >= 2)
            {
                happyPass = true;
            }


            Debug.Log(customers[0].GetComponent<Customer>().money);
            points += (int)(customers[0].GetComponent<Customer>().money * (satisfaction / 100.0));

            Debug.Log(points);
            scoreDispaly.text = points.ToString();
            if (points >= 100)
              {
                    moneyEarned.text = "100/100";
                    moneyPass = true;
              }  

            else if (points <= 100)
                moneyEarned.text = points.ToString() + "/100";
            Debug.Log(happyCustomers + " " + potionsMade);
            satisfactionDispaly.text = ((int)((happyCustomers * 1.0 / potionsMade) * 100)).ToString();
            GameObject thoughtBubble = null;

            if (satisfaction >= 80)
            {
                /*
                Vector2 position = new Vector2(bubbleSpawn.position.x, bubbleSpawn.position.y);
                thoughtBubble = Instantiate(smile, position, Quaternion.identity);
                */
                //thoughtBubble = Instantiate(smile);
                customers[0].GetComponent<Customer>().DestroyAllPre();
                //Destroy(customers[0].GetComponent<Customer>().bubble);
                customers[0].GetComponent<Customer>().BubbleSet(smile);
            }
            else
            {
                /*
                Vector2 position = new Vector2(bubbleSpawn.position.x, bubbleSpawn.position.y);
                thoughtBubble = Instantiate(sad, position, Quaternion.identity);
                */
                //thoughtBubble = Instantiate(sad);
                //Destroy(customers[0].GetComponent<Customer>().bubble);
                customers[0].GetComponent<Customer>().DestroyAllPre();
                customers[0].GetComponent<Customer>().BubbleSet(sad);
            }
            /*
            if (thoughtBubble != null){
                Destroy(thoughtBubble, 2);
            }*/
            satis = satis + ((int)((happyCustomers * 1.0 / potionsMade) * 100));
            player.GetComponent<Player>().emptyInvetoryOut();
            removeFirst();
        }
    }

    public void removeFirst()
    {
        GameObject cus = customers[0];
        cus.GetComponent<Customer>().setPosition(waitPoints[0]);
        float number = (float)0.45;
        cus.transform.localScale = new Vector3(-number, number, number);
        Destroy(cus.GetComponent<Customer>().bubble, 15f);
        Destroy(cus, 15f);
        customers.Remove(cus);
        //cus.GetComponent<Customer>().DestroyAllPre();
        size--;
    }

    public void setMiniGameActive(bool value)
    {
        miniGameActive = value;
    }

}