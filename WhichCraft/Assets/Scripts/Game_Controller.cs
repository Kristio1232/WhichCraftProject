using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour
{
    //Customer Array Info
    private static List<GameObject> customers = new List<GameObject>();
    private int size = 0;
    public GameObject[] customerPrefab;
    public Transform[] waitPoints;
    //Player Info
    public GameObject player;

    //Points
    public int points = 0;
    public TMP_Text scoreDispaly;

    //Spawn Variables
    private float timeBtwSpawns;
    public float spawnRate;
    public GameObject[] obstacleTemplate;
    public Transform spawnPoint;

    //Unused
    /*
    public GameObject ThoughtBubble_Smile;
    public GameObject ThoughtBubble_Angry;
    public GameObject thoughtBubble_HeatPotion;
    */

    void Start()
    {
        timeBtwSpawns = 0;
    }

    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            int randomObstacle = Random.Range(0, obstacleTemplate.Length);

            Vector2 position = new Vector2(spawnPoint.position.x, spawnPoint.position.y);
            addCustomer(Instantiate(obstacleTemplate[randomObstacle], position, Quaternion.identity)); ;
            timeBtwSpawns = spawnRate;
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

    private void customerUpdateFunction()
    {
        //Customer Control code
        int counter = 0;

        foreach (var shopper in customers)
        {
            counter++;

            Transform waitPoint = null;

            if (shopper.GetComponent<Customer>().timeLeft <= 0)
            {
                waitPoint = waitPoints[0];
                shopper.GetComponent<Customer>().setPosition(waitPoint);
                customers.Remove(shopper);
                size--;
                break;
            }
            else
            {
                switch (counter)
                {
                    case 1:
                        waitPoint = waitPoints[1];
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
        //Debug.Log("Adds Customer");
    }

    public void giveCustomerPotion()
    {
        if (size > 0 && player.GetComponent<Player>().getPotionDone())
        {
            scoreDispaly.text = points.ToString();
            player.GetComponent<Player>().emptyInvetoryOut();
            removeFirst();
        }
    }

    public void removeFirst()
    {
        customers.RemoveAt(0);
        size--;
    }

}