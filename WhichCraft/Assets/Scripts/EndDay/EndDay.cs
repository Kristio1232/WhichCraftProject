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

    //timer
  //  public float timer;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        Vector2 position1 = new Vector2(174.68f, 216.88f);
        Vector2 position2 = new Vector2(173.65f, 216.15f);
        Vector2 position3 = new Vector2(175f, 215.36f);

        //Daily goals
        yield return new WaitForSeconds(0.5f);
        if(Game_Controller.potionPass == true)
        {
            
            Instantiate(check, position1, Quaternion.identity);
        }
        else if (Game_Controller.potionPass == false)
        {
            Instantiate(cross, position1, Quaternion.identity);
        }

        yield return new WaitForSeconds(0.5f);
        if(Game_Controller.moneyPass == true)
        {
            Instantiate(check, position2, Quaternion.identity);
        }
        else if (Game_Controller.moneyPass == false)
        {
            Instantiate(cross, position2, Quaternion.identity);
        }

        yield return new WaitForSeconds(0.5f);
        if(Game_Controller.happyPass == true)
        {
            Instantiate(check, position3, Quaternion.identity);
        }
        else if (Game_Controller.happyPass == false)
        {
            Instantiate(cross, position3, Quaternion.identity);
        }

        yield return new WaitForSeconds(0.5f);
        //Customer served
        customer_Served = Game_Controller.custServed;  
        Display_customerServed.text = customer_Served.ToString(); 
       

        //Satisfaction
        yield return new WaitForSeconds(0.5f);
        if (customer_Served == 0)
        {
            customer_Served = 1;
            avgSatisfaction = Game_Controller.satis / customer_Served;
            Display_avgSatissfaction.text = avgSatisfaction.ToString();
        }
        else 
        {
             avgSatisfaction = Game_Controller.satis / customer_Served;
             Display_avgSatissfaction.text = avgSatisfaction.ToString();
        }


        //timeLeft
        yield return new WaitForSeconds(0.5f);
        timeLeft = TimerController.timeTransfer;

        timeLeft += 1;
        float minutes = Mathf.FloorToInt(timeLeft / 60);
        float seconds = Mathf.FloorToInt(timeLeft % 60);

        Display_timeLeft.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        
        //bonus coin system 
        yield return new WaitForSeconds(1);
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
    //    timer = 0;
        SceneManager.LoadScene("PotionStore");
    }

    public void quit (string Quit)
    {
     //   timer = 0;
        Application.Quit();
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

