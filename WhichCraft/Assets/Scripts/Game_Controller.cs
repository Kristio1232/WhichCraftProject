using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour
{
    //Customer Array Info
    private static List<GameObject> customers;
    private int size = 0;
    public int maxSize;
    public GameObject[] customerPrefab;
    public Transform[] waitPoints;
    public int satisfaction = 100;
    public bool setNotification = true;

    
    //Player Info
    public GameObject player;

    //Points
    public int points;
    public TMP_Text scoreDispaly;

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
                GameObject temp = shopper;
                customers.Remove(shopper);
                if (!temp){
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
            satisfaction = 100;
            string playerCode = player.GetComponent<Player>().getSelectedItems();
            string customerCode = customers[0].GetComponent<Customer>().potionCode;
            Debug.Log("Codes: " + playerCode + " and " + customerCode);
            if (!playerCode[0].Equals(customerCode[0])){
                satisfaction -= 10;
            }
            if (!playerCode.Contains(customerCode[1])){
                satisfaction -= 20;
            }
            if (!playerCode.Contains(customerCode[2])){
                satisfaction -= 20;
            }
            Debug.Log("Satisfaction" + satisfaction);
            Debug.Log(customers[0].GetComponent<Customer>().money);
            points += (int) (customers[0].GetComponent<Customer>().money * (satisfaction/100.0));
            Debug.Log(points);
            scoreDispaly.text = points.ToString();
            player.GetComponent<Player>().emptyInvetoryOut();
            setNotification = false;
            removeFirst();
        }
    }

    public void removeFirst()
    {
        GameObject cus = customers[0];
        cus.GetComponent<Customer>().setPosition(waitPoints[0]);
        customers.Remove(cus);
        size--;
    }

    public void setMiniGameActive(bool value)
    {
        miniGameActive = value;
    }

}