using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    }

    public void OpenCookbook()
    {
        isOpen = true;
        Debug.Log("Open Cookbook menu.");
        cookBook.SetActive(true);

    }
}
