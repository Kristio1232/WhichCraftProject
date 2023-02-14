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

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ClickBlue1()
    {
        SceneManager.LoadScene("Blue1");
    }

    public void ClickYellow1()
    {
        SceneManager.LoadScene("Yellow1");
    }

    public void ClickRed1()
    {
        SceneManager.LoadScene("Red1");
    }

    public void Blue1Red2()
    {
        SceneManager.LoadScene("Blue1Red2");
    }

    public void Blue1Yellow2()
    {
        SceneManager.LoadScene("Blue1Yellow2");
    }

    public void Red1Blue2()
    {
        SceneManager.LoadScene("Red1Blue2");
    }

    public void Red1Yellow2()
    {
        SceneManager.LoadScene("Red1Yellow2");
    }

    public void Yellow1Blue2()
    {
        SceneManager.LoadScene("Yellow1Blue2");
    }

    public void Yellow1Red2()
    {
        SceneManager.LoadScene("Yellow1Red2");
    }

    public void ClickedReset()
    {
        SceneManager.LoadScene("WhichCraftDemo");
    }

    public void ClickedCombine_Purple()
    {
        SceneManager.LoadScene("CreatedPurple");
    }

    public void ClickedCombine_Green()
    {
        SceneManager.LoadScene("CreatedGreen");
    }

    public void ClickedCombine_Orange()
    {
        SceneManager.LoadScene("CreatedOrange");
    }
}
