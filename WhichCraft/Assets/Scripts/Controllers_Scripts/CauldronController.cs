using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isOpen;
    public GameObject miniGame;
    public GameObject RedIngredient;
    public GameObject YellowIngredient;
    public GameObject EmptyVial;
    public GameObject cauldronFull;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (RedIngredient.activeSelf && YellowIngredient.activeSelf && EmptyVial.activeSelf)
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
        if (RedIngredient.activeSelf && YellowIngredient.activeSelf && EmptyVial.activeSelf)
        {
            isOpen = true;
            Debug.Log("Open Cauldron.");
            miniGame.SetActive(true);
            
        }
    }
}
