using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isOpen;
    public GameObject player;
    public GameObject miniGame;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenCauldron()
    {
        int num = player.GetComponent<Player>().getNumberOfIngredient();
        if (num == 2)
        {
            isOpen = true;
            Debug.Log("Open Caukdron menu.");
            miniGame.SetActive(true);
        }
    }
}
