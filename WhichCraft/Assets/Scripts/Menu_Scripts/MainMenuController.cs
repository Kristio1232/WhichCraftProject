using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Exit!");

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("InstructionScene");
    }

    public void ClickedReadyToPlay()
    {
        SceneManager.LoadScene("PotionStore");
    }

    public void Credits()
    {
        Application.OpenURL("https://docs.google.com/document/d/1_ZVIny0h1pJLApjDsKZOYXlzGbiVuDbrvTBMu4V1fjs/edit");
    }

}
