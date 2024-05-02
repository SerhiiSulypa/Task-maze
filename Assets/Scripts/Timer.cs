using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public PlayerMovement _player;
    [Space]
    public Text timerText;
    public float TimeInSeconds;

    [NonSerialized] public float currentTime;
    [NonSerialized] public bool isRunning = false;

    void Start()
    {
        currentTime = TimeInSeconds;
        UpdateTimerText();
        isRunning = true;
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();

            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isRunning = false;
                _player._lose(timerText);
            }
        }
    }



    public void UpdateTimerText()
    {
        string minutes = Mathf.Floor(currentTime / 60).ToString("00");
        string seconds = (currentTime % 60).ToString("00");

        timerText.text = ("Time left: ") + minutes + ":" + seconds;

    }
}

