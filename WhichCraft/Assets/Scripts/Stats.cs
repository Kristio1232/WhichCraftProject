using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour

{
    List<Consumer> customers = new List<Consumer>();
    
    void addCustomer()
    {
        customers.Add(new Consumer());
    }

    void removeFirst()
    {
        customers.RemoveAt(0);
    }
}

public class Consumer : MonoBehaviour
   {
        public static string potionType;
        public static int potionCode;
       // static int caseNumber;

        //Potion Code pattern 
        // 2 beakers = code numbers 1, 2
        // 3 ingredients = code numbers 3, 4, 5 


       void orderInfo()
        {
            int randint = Random.Range(1, 1);
                        
            switch (randint)
            {
                case 1:
                    potionType = "Health";
                    potionCode = 13;
                    break;
                case 2:
                    potionType = "Exp";
                    potionCode = 24;
                    break;
                case 3:
                    potionType = "Stam";
                    potionCode = 15;
                    break;
         }
            
            
        }
        public string getPotionType()
        {
            return potionType;
        }

      //  public int getPotionCode()
     //   {
     //       return potionCode;
     //   }

}

