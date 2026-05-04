using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;

    private float elapsedTime = 0f;
    private bool timerIsRunning = true;

    void Update()
    {
        if (timerIsRunning && Time.timeScale > 0f)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimer();
        }
    }

    public void UpdateTimer()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60F);
        int seconds = Mathf.FloorToInt(elapsedTime % 60F);

        timerText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        timerIsRunning = false;
    }
    public void StartTimer()
    {
        timerIsRunning = true;
    }
    public void ResetTimer()
    {
        elapsedTime = 0f;
        UpdateTimer();
    }
}
