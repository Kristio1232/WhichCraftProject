using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndDay : MonoBehaviour
{
    //fetching info
  //  public GameObject gameController;
    
    //varaibles
    public int customer_Served;
    public int avgSatisfaction;


    //Display info
    public TMP_Text Display_customerServed;
    public TMP_Text Display_avgSatissfaction;


    // Start is called before the first frame update
    void Start()
    {
        //Customer served
        customer_Served = Game_Controller.custServed;
        Display_customerServed.text = customer_Served.ToString(); 

        //Satisfaction
        avgSatisfaction = Game_Controller.satis / customer_Served;
        Display_avgSatissfaction.text = avgSatisfaction.ToString();



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

