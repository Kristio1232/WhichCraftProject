using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Game_Info : MonoBehaviour
{
    private static List<Customer> customers = new List<Customer>();
    private int size = 0;
    public GameObject player;
    public GameObject ThoughtBubble_Smile;
    public GameObject ThoughtBubble_Angry;
    public GameObject thoughtBubble_HeatPotion;
    public int points = 0;
    public TMP_Text scoreDispaly;
    public static bool match = false;
 
    public void addCustomer()
    {
        customers.Add(new Customer());
        size++;
        Debug.Log("Adds Customer");
    }

    public void giveCustomerPotion()
    {
        if (size > 0 && player.GetComponent<Player>().getPotionDone() )
        {
            
            string playerCode = player.GetComponent<Player>().getSelectedItems();
            double satisfaction = 1;
            Destroy(player.GetComponent<Player>().potionMade, 3);
            for (int i = 0; i < playerCode.Length; i++)
            {
                if (!playerCode[i].Equals(customers[0].potionCode[i])){
                    satisfaction -= 0.3;
                }
            }
            Customer_Collision.sat =  satisfaction;
            Debug.Log("printing satisfaction " + satisfaction);
            points += (int) (customers[0].money * satisfaction);
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
public class Customer
    {
        public string potionCode;
        public int money;
        public Customer()
        {
            int randint = Random.Range(1, 1);
            money = Random.Range(10, 100);
            switch (randint)
            {
                case 1:
                    potionCode = "134";
                    break;
            }
        }
    }