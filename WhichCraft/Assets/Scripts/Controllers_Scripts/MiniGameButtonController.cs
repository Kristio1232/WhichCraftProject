using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameButtonController : MonoBehaviour
{
    public GameObject MiniGameWinMenu;
    public GameObject MiniGame;
    public GameObject MiniGameLoseMenu;
    public GameObject player;
    public GameObject controller;
    public bool notification_on;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void exitMiniGameWinMenu()
    {
        MiniGameWinMenu.SetActive(false); 
        player.GetComponent<Player>().setPotionDone(true);
        player.GetComponent<Player>().emptyTable();
        controller.GetComponent<Game_Controller>().setMiniGameActive(false);
        notification_on = true;
    }
    
    public void tryAgainMenu()
    {
        MiniGame.SetActive(true);
        MiniGameLoseMenu.SetActive(false);
    }

    public void exitMiniGameLoseMenu()
    {
        MiniGameLoseMenu.SetActive(false);
        player.GetComponent<Player>().setPotionDone(false);
        player.GetComponent<Player>().emptyInvetoryOut();
        controller.GetComponent<Game_Controller>().setMiniGameActive(false);
    }
}
