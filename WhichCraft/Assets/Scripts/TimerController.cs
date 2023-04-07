using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeLeft;
    public bool timerOn = false;
    public TMP_Text timerText;

    void Start()
    {
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            timeLeft -= Time.deltaTime;
            updateTimer(timeLeft);
        }
        if(timeLeft <= 0)
        {
            timeLeft = 0;
            timerOn = false;
            SceneManager.LoadScene("EndDay");
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
