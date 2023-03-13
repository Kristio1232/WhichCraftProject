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

    public int posX , posY;
    public Button potionButton;
    public GameObject MiniGame;

    // Start is called before the first frame update
    void Start()
    {
        bar.fillAmount = 0f;
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (MiniGame.activeSelf)
        {
            timerOn = true;
        }
        else
        {
            timerOn = false;
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
                    bar.fillAmount = 0;
                }
            }
            else
            {
                Debug.Log("Time is Up!");
                timerOn = false;
                MiniGame.SetActive(false);
                bar.fillAmount = 0;
                timeLeft = 10;
            }
        }
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
        posX = Random.Range(75, 600);
        posY = Random.Range(100, 250);
        buttonToMove.transform.position = new Vector2(posX, posY);
    }

    public void decrementBar(float amount)
    {
        bar.fillAmount = bar.fillAmount - amount;
    }
}
