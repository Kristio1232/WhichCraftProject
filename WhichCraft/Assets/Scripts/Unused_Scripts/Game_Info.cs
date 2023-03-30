using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Game_Info : MonoBehaviour
{
    private static List<CustomerTemp> customers = new List<CustomerTemp>();
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
        customers.Add(new CustomerTemp());
        size++;
        Debug.Log("Adds Customer");
    }

    public void giveCustomerPotion()
    {
        if (size > 0 && player.GetComponent<Player>().getPotionDone() )
        {
            Debug.Log("Potion Code" + customers[0].potionCode);
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

public class CustomerTemp
    {
        public string potionCode;
        public int money;
        public CustomerTemp()
        {
            int randint = Random.Range(1, 5);
            money = Random.Range(10, 100);
            switch (randint)
            {
                case 1:
                    potionCode = "145";
                    break;
                
                case 2:
                    potionCode = "256";
                    break;
                
                case 3:
                    potionCode = "346";
                    break;

                case 4:
                    potionCode = "345";
                   break;
                
                case 5:
                    potionCode = "256";
                    break;
            }

            
        }
    }