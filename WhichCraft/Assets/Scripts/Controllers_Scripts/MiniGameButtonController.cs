using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameButtonController : MonoBehaviour
{
    public GameObject MiniGameWinMenu;
    public GameObject MiniGame;
    public GameObject MiniGameLoseMenu;
    public GameObject player;
    
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
    }
}
