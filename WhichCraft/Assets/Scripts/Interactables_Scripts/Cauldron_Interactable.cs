using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cauldron_Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public GameObject autoCloseObject;
    public GameObject showNotification;
    public GameObject RedIngredient;
    public GameObject YellowIngredient;
    public GameObject EmptyVial;

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
        if (RedIngredient.activeSelf && YellowIngredient.activeSelf && EmptyVial.activeSelf && collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            showNotification.SetActive(true);
            Debug.Log("Player in Cauldron Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
        showNotification.SetActive(false);
        autoCloseObject.SetActive(false);
    }

}
