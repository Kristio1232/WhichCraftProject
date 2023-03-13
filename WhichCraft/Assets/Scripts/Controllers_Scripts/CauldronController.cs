using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isOpen;
    public GameObject miniGame;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("E"))
        {
            miniGame.SetActive(false);
        }
    }

    public void OpenCookbook()
    {
        isOpen = true;
        Debug.Log("Open Cookbook menu.");
        miniGame.SetActive(true);

    }
}
