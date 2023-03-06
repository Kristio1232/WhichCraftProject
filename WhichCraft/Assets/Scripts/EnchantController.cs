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
                }
            }
            else
            {
                Debug.Log("Time is Up!");
                timerOn = false;
                timeLeft = 0;
                SceneManager.LoadScene("MiniGame1_enchant_LoseMenu");

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

        float seconds = Mathf.FloorToInt(currentTime % 60);

        timeText.text = timeLeft.ToString("0.#");
    }

    public void decrementBar(float amount)
    {
        bar.fillAmount = bar.fillAmount - amount;
    }
}
