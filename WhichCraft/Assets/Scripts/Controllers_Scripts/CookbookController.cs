using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookbookController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isOpen;
    public GameObject cookBook;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            CloseCookbook();
        }

    }

    public void OpenCookbook()
    {
        isOpen = true;
        Debug.Log("Open Cookbook menu.");
        cookBook.SetActive(true);

    }
    public void CloseCookbook()
    {
        isOpen = false;
        Debug.Log("Closed Cookbook menu.");
        cookBook.SetActive(false);
    }
}
