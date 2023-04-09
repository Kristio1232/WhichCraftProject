using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndDay : MonoBehaviour
{
    //prefabs
    public GameObject check;
    public GameObject cross;
    
    //varaibles
    public int customer_Served;
    public int avgSatisfaction;
    public float timeLeft;
    public int bonusCoins;


    //Display info
    public TMP_Text Display_customerServed;
    public TMP_Text Display_avgSatissfaction;
    public TMP_Text Display_timeLeft;
    public TMP_Text Display_bonusCoins;


    // Start is called before the first frame update
    void Start()
    {
        //Customer served
        customer_Served = Game_Controller.custServed;
        Display_customerServed.text = customer_Served.ToString(); 

        //Satisfaction
        avgSatisfaction = Game_Controller.satis / customer_Served;
        Display_avgSatissfaction.text = avgSatisfaction.ToString();

        //timeLeft
        timeLeft = TimerController.timeTransfer;

        timeLeft += 1;
        float minutes = Mathf.FloorToInt(timeLeft / 60);
        float seconds = Mathf.FloorToInt(timeLeft % 60);

        Display_timeLeft.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        
        if(minutes >= 3 && customer_Served >= 4 && avgSatisfaction >=60 && Game_Controller.potionPass == true && Game_Controller.moneyPass == true && Game_Controller.happyPass == true)
        {
            bonusCoins = 70;
            Display_bonusCoins.text = bonusCoins.ToString();
        }
        else if(minutes >= 2 && Game_Controller.potionPass == true && Game_Controller.moneyPass == true && Game_Controller.happyPass == true)
        {
            bonusCoins = 30;
            Display_bonusCoins.text = bonusCoins.ToString();
        }
        else if(minutes >= 1 && Game_Controller.potionPass == true && Game_Controller.moneyPass == true && Game_Controller.happyPass == true)
        {
            bonusCoins = 10;
            Display_bonusCoins.text = bonusCoins.ToString();
        }
        else{
             bonusCoins = 0;
            Display_bonusCoins.text = bonusCoins.ToString();
        }

        if(Game_Controller.potionPass == true)
        {
            Vector2 position = new Vector2(-2.41f, 1.31f);
            Instantiate(check, position, Quaternion.identity);
        }
        else if (Game_Controller.potionPass == false)
        {
            Vector2 position = new Vector2(-2.41f, 1.31f);
            Instantiate(cross, position, Quaternion.identity);
        }
        if(Game_Controller.moneyPass == true)
        {
            Vector2 position = new Vector2(-3.41f, 0.37f);
            Instantiate(check, position, Quaternion.identity);
        }
        else if (Game_Controller.moneyPass == false)
        {
            Vector2 position = new Vector2(-3.41f, 0.37f);
            Instantiate(cross, position, Quaternion.identity);
        }
        if(Game_Controller.happyPass == true)
        {
            Vector2 position = new Vector2(-2.08f, -0.4f);
            Instantiate(check, position, Quaternion.identity);
        }
        else if (Game_Controller.happyPass == false)
        {
            Vector2 position = new Vector2(-2.08f, -0.4f);
            Instantiate(cross, position, Quaternion.identity);
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openEndDay()
    {
        SceneManager.LoadScene("EndDay");
    }

    public void replay()
    {
        SceneManager.LoadScene("PotionStore");
    }

    public void quit (string Quit)
    {
        Application.Quit();
    }
}
