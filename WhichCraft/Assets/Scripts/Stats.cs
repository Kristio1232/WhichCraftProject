using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    List<customer> customers = new List<customer>();

    void addCustomer()
    {
        customers.Add(new customer());
    }

    void removeFirst()
    {
        customers.RemoveAt(0);
    }

    public class customer
    {
        string potionType;

        public customer()
        {
            int randint = Random.Range(1, 1);
            switch (randint)
            {
                case 1:
                    potionType = "Health";
                    break;
                case 2:
                    potionType = "Exp";
                    break;
                case 3:
                    potionType = "Stam";
                    break;
            }
            
        }
        public String getPotion()
        {
            return potionType;
        }
    }
}