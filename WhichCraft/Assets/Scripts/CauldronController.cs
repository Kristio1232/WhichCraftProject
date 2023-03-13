using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    }

    public void OpenMiniGame()
    {
        isOpen = true;
        Debug.Log("Open Minigame.");
        miniGame.SetActive(true);

    }
}
