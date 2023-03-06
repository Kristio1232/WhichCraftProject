using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;
using UnityEngine.UI;

public class EnchantController : MonoBehaviour
{
    public Image bar;
    public float fillAmount = 0.02f;
    public float timeLeft;
    public bool timerOn = false;
    public AudioSource buttonSound;
    public TMP_Text timeText;

    private const float TICK_BAR_AMOUNT = 0.002f;

    // Start is called before the first frame update
    void Start()
    {
        bar.fillAmount = 0f;
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
 
        if (timerOn)
        {
      
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);

                if(bar.fillAmount == 1)
                {
                    SceneManager.LoadScene("MiniGame1_enchant_WinMenu");
                    bar.fillAmount = 0;
                    
                }
            }
            else
            {
                Debug.Log("Time is Up!");
                timerOn = false;
                timeLeft = 0;
                SceneManager.LoadScene("MiniGame1_enchant_LoseMenu");
                bar.fillAmount = 0;
            }
        }
    }

    public void EnchantButtonClick ()
    {
        bar.fillAmount += fillAmount;
        buttonSound.Play();
    }

    public void updateTimer(float currentTime)
    {
        currentTime += 1;

       // float seconds = Mathf.FloorToInt(currentTime % 60);

        timeText.text = timeLeft.ToString("0.#");
    }

    public void decrementBar(float amount)
    {
        bar.fillAmount = bar.fillAmount - amount;
    }

    public void updateBar(float currentBarAmount)
    {
        if (currentBarAmount > 0)
        {
            currentBarAmount -= 0.005f;
        }
    }
}
