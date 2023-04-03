using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Potion_Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public GameObject autoCloseObject;
    public GameObject showNotification;
    public GameObject MiniGameWinMenu;

    //Customer thought bubble reviews
    public GameObject smile;
    public GameObject sad;

    //getting info from gamecontroller
    public GameObject gameController;

    //customer collision bool
    public bool customer_Present;

    public bool notification = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
        }    
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") &&  MiniGameWinMenu.GetComponent<MiniGameButtonController>().notification_on == true)
        {
            isInRange = true;
            showNotification.SetActive(true);
            MiniGameWinMenu.GetComponent<MiniGameButtonController>().notification_on = false;
            Debug.Log("Player in Potion is Active");
        }
        if (collision.gameObject.CompareTag("Customer"))
        {
            customer_Present = true;
            Debug.Log("Customer_Present BOOL in the collision" + customer_Present);

        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
        showNotification.SetActive(false);
        customer_Present = false;
        smile.SetActive(false);
        sad.SetActive(false);

    }

    public void review()
    {
        Debug.Log("Customer_Present BOOL in review" + customer_Present);
        showNotification.SetActive(false);

        if (gameController.GetComponent<Game_Controller>().points >= 50 && isInRange == true)
        {
            smile.SetActive(true);
            sad.SetActive(false);
           
        }
        else if(gameController.GetComponent<Game_Controller>().points < 50 && isInRange == true){
            sad.SetActive(true);
            smile.SetActive(false);
           
        }
        
  
    }                  

}
