using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class WhichCraftDemo_Script : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
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
