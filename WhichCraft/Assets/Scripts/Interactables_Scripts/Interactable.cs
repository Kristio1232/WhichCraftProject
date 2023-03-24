using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public KeyCode closeKey;
    public UnityEvent interactAction;
    public GameObject autoCloseObject;
    public GameObject showNotification;

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

            if (Input.GetKeyDown(closeKey))
            {
                interactAction.Invoke();
            }
                
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            autoCloseObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            showNotification.SetActive(true);
            Debug.Log("Player in Cookbook Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
        showNotification.SetActive(false);
        autoCloseObject.SetActive(false);
    }


}
