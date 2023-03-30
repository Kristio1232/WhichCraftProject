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
            Debug.Log("Player in Potion is Active");
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
        showNotification.SetActive(false);
    }
    
}
