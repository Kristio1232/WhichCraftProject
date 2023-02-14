using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WhichCraftDemo_Script : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("EndlessRunner"); //this will have the name of your main game scene
    }
    public void ClickBlue()
    {
        SceneManager.LoadScene("Blue1");
    }

    public void ClickYellow()
    {
       
    }

    public void ClickRed()
    {
        SceneManager.LoadScene("Blue1Red2");
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    public void ClickedReset()
    {
        SceneManager.LoadScene("WhichCraftDemo");
    }

    public void ClickedCombine()
    {
        SceneManager.LoadScene("Blue1Red2_Combine");
    }
}
