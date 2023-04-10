using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;
using UnityEngine.UI;

public class EnchantController2 : MonoBehaviour
{
    public Image bar;
    public float fillAmount = 0.02f;

    public float timeLeft;
    public bool timerOn = false;
    public AudioSource buttonSound;
    public TMP_Text timeText;

    public float posX, posY = 0;
    public Button potionButton;
    public GameObject MiniGame;
    public GameObject MiniGameWinMenu;
    public GameObject MiniGameLoseMenu;

    public GameObject controller;

    // Start is called before the first frame update
    void Start()
    {
        bar.fillAmount = 0f;
        timerOn = true;
     
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(timerOn);
        //Debug.Log("Active Mini" + MiniGame.activeSelf);
        if (MiniGame.activeSelf)
        {
            controller.GetComponent<Game_Controller>().setMiniGameActive(true);
            timerOn = true;
        }
        else
        {
            timerOn = false;
            //controller.GetComponent<Game_Controller>().setMiniGameActive(false);
            resetTime();
        }

        if (timerOn)
        {

            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);

                if (bar.fillAmount == 1)
                {
                    MiniGame.SetActive(false);
                    MiniGameWinMenu.SetActive(true);
                    bar.fillAmount = 0;
                    resetTime();
                }
            }
            else
            {
                Debug.Log("Time is Up!");
                timerOn = false;
                MiniGame.SetActive(false);
                MiniGameLoseMenu.SetActive(true);
                bar.fillAmount = 0;
                resetTime();
            }
        }
    }

    public void FixedUpdate()
    {

    }

    public void resetTime()
    {
        timeLeft = 10;
    }

    public void EnchantButtonClick()
    {
        bar.fillAmount += fillAmount;
        buttonSound.Play();
        changePosition(potionButton);
    }

    public void updateTimer(float currentTime)
    {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime % 60);

        timeText.text = timeLeft.ToString("0.#");
    }

    public void changePosition(Button buttonToMove)
    {
        //   posX = Random.Range(600,1100); //100 min, 500 max

        //   posY = Random.Range(400,800); //70 min, 250 max

        posX = Random.Range(200f,500f); //100 min, 500 max

        posY = Random.Range(100f,250f); //70 min, 250 max
        buttonToMove.transform.position = new Vector2(posX, posY);
    }

    public void decrementBar(float amount)
    {
        bar.fillAmount = bar.fillAmount - amount;
    }
}
