using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CauldronController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isOpen;
    public GameObject player;
    public GameObject miniGame;
    
    public GameObject cauldronFull;
    /*
    public GameObject RedIngredient;
    public GameObject YellowIngredient;
    public GameObject EmptyVial;
    */
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Player>().getNumberOfIngredient() == 3 && !player.GetComponent<Player>().getPotionDone())
        {
            cauldronFull.SetActive(true);
        }
        else
        {
            cauldronFull.SetActive(false);
        }
       
    }

    public void OpenCauldron()
    {
        int num = player.GetComponent<Player>().getNumberOfIngredient();
        if (num == 3 && !player.GetComponent<Player>().getPotionDone())
        {
            isOpen = true;
            Debug.Log("Open Caukdron menu.");
            miniGame.SetActive(true);
        }
    }
}
