using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openEndDay()
    {
        SceneManager.LoadScene("EndDay");
    }

    public void replay()
    {
        SceneManager.LoadScene("PotionStore");
    }

    public void quit (string Quit)
    {
        Application.Quit();
    }
}

